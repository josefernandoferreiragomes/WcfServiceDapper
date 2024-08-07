# PoC migration of .NET 4.8 WCF, API and WebSite to .NET 8

### Simplified Customer web site example (SQL Server, .Net Framework 4.8, .Net Core 8, Dapper, API, WebAPI)

## Features
	Legacy WCF
		.NET 4.8
		Dapper
	WCF
		.NET 8
		Dapper
	Library
		.NET 8
		.NET 4.8
	API
		.NET 8
		.NET 4.8 upgraded to .NET Standard 2.0 !!! Deprecated
		Delegate
		Func
		Generics
	Legacy Site
		.NET 4.8
	Site
		.NET 8
		Dependency Injection

## Project setup	

### Make sure to have installed .NET 4.8 and .NET 8
### The startup projects for running with ctrl+F5 should be:
![StartupProjects](StartupProjects.png)
### It should run out right of the box

## Walkthrough of the migration made from .NET 4.8 to .NET 8

### 1. Create examples of: 
	Customers Database, in SQLLocalDB 
	DAL, in .net framework  
	WCF Service, in .net framework 
	Library containing WCF proxy, in .net framework  
	API library, in .net framework 
	Web site, in .net framework 
	Web site, in .net core 

### 2. Attempt to migrate API to .Net Standard 2.0, but it didn't work for .Net Core Web Site 
	Created a new .net Standard 2.0 API library project 
	Copied code files from legacy project 
	.Net framework web site consumed the new API, and it worked 
	Tried to consume new API from .Net Core Web site, but the proxy inside the library is not compatible. As it is not possible to consume .net framework proxy from .net core, neither possible to consume .net core proxy from .net framework, which was confirmed by googling about the problem. 

### 3 migrate Library and API to .net core 
	Create new .Net Core Library project 
	Generate proxy using dotnet-svcutil 
	Create new .Net Core API project, to be consumed by . Net Core website, through project reference 
	Create new Web API 
	In .net framework web site, create new gRPC API client, to consume the new Web API 

### 4 migrate WCF service to CoreWCF 
	Create new .net core DAL project 
	Copy DAL code files from legacy WCF service to the new project 
	Add nuget packages for Dapper and other dependencies 
	Install CoreWCF project template 
	Create new CoreWCF project
	Copy service interface and service class from legacy WCF to new project 
	Add reference to DataLayer Core project 
	Add startup code to read appsettings.json 
	Copy connection strings from legacy WCF web.config to new appsettings.json 
	In Library core, generate new proxy, using dotnet-svcutil for consumption of new CoreWCF  
	In framework web site, update API Client code 

### Generate compatibiliy web api client code
	Install NSwag in Legacy Library with NuGet
	Create new nswag docuemnt, using command: nswag new
	Generate client code using web api core url: http://localhost:5015/swagger/v1/swagger.json
	 navigate to folder:
	  c:\...\WcfServiceDapper\CustomerLibrary>
	 command:
	  nswag openapi2csclient /input:http://localhost:5015/swagger/v1/swagger.json /classname:ClientApiClient /namespace:Customer.Library /output:ClientApiClient.cs
	 Problems related to .net framework nswag version:
	 https://developercommunity.visualstudio.com/t/httpclient-not-smart-about-combining-baseaddress-w/1592519

### Generate WCF Proxy (Framework)
#### !!! Deprecated !!!
	Start WCF Service
	Open VS Dev Command Prompt
	Navigate to library folder
	write the command:
	svcutil http://localhost:62341/Customers.svc /out:CustomersProxy.cs

	References:
	https://www.codeproject.com/Articles/786601/Ways-to-generate-proxy-for-WCF-Service

### Migrate to .NET Standard 2.0
#### !!! Does not solve the problem !!! Deprecated
	https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-migrate-from-dotnet-framework-to-dotnet-standard

	Install Extension .NET Upgrade Assistant
	https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer
	https://developercommunity.visualstudio.com/t/the-net-portability-analyzer-missing-vs2022net6-su/1674326

	API Standard 2.0
	install System.ServiceModel.Primitives 4.4.4

### Use .net Standard 2.0 in CustomerSiteCore
#### !!! Does not solve the problem !!! Deprecated
	https://learn.microsoft.com/en-us/dotnet/core/porting/
	Install-Package System.Private.ServiceModel -Version 4.7.0
	https://stackoverflow.com/questions/73316508/error-platformnotsupportedexception-configuration-files-are-not-supported-or-h
	
	https://github.com/dotnet/standard/issues/781

### Further reading
	WCFClient details
	https://devblogs.microsoft.com/dotnet/wcf-client-60-has-been-released/
	https://www.mytechramblings.com/posts/modernize-wcf-legacy-app-using-corewcf/
	https://medium.com/@palchouhan/upgrading-a-wcf-service-to-net-6-with-corewcf-cf3a4f569b61
	https://aws.amazon.com/blogs/modernizing-with-aws/wcf-service-to-corewcf/
	https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
	https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/how-to-declare-instantiate-and-use-a-delegate?source=recommendations
	https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-delegates

### Free public APIs for testing purposes
	https://apipheny.io/free-api/

## Sources

### Connect to SQL Server Database with Dapper and DapperExtensions
	https://www.learndapper.com/database-providers
	https://github.com/tmsmith/Dapper-Extensions

### Generate WCF Proxy Core
	install dotnet-svcutil:
	dotnet tool install --global dotnet-svcutil

	execute the command in project context and located in project folder
	dotnet-svcutil http://localhost:62341/Customers.svc?wsdl --outputFile CustomersProxyCore.cs	

	https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-svcutil-guide?tabs=dotnetsvcutil2x

	https://learn.microsoft.com/en-us/answers/questions/1301834/how-to-use-net-6-0-library-in-net-framework-4-7-2

### Expose Web API in Core 8 to be consumed by Framework Web Site
	If you can not convert your Framework to net Core and you need to call the Core code, 
	then host the net Core as a webapi, and call via httpclient() from the Framework code
	
	https://learn.microsoft.com/en-us/answers/questions/1301834/how-to-use-net-6-0-library-in-net-framework-4-7-2

### Read appsettings.json
	https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
	https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0	

### CoreWCF
	https://github.com/CoreWCF/samples/tree/main/Scenarios/Logging-and-Dependency-Injection
	https://github.com/CoreWCF/CoreWCF/blob/main/Documentation/Walkthrough.md
	https://devblogs.microsoft.com/dotnet/corewcf-1-1-0-and-project-templates/
	PM> dotnet new --install CoreWCF.Templates
	https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-wcf
	Proxy:
	cmd admin, on LibraryCore folder:
	dotnet-svcutil http://localhost:5153/CustomerServiceCore.svc  --namespace "*,CustomerServiceCoreProxy" --outputFile "CustomerServiceCoreProxy.cs"

