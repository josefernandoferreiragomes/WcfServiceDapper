# Customer web site example (SQL Server, .Net Framework 4.8, .Net Core 8, Dapper, API, WebAPI)

## Requirements
	WCF
		4.8
		Dapper
	API
		Core 8
		4.8 upgraded to Standard 2.0 !!! Deprecated
		Delegate
	Site
		4.8
	Site
		Core 8

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
	https://devblogs.microsoft.com/dotnet/corewcf-1-1-0-and-project-templates/
	PM> dotnet new --install CoreWCF.Templates
	https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-wcf

### Further reading
	WCFClient details
	https://devblogs.microsoft.com/dotnet/wcf-client-60-has-been-released/
	https://www.mytechramblings.com/posts/modernize-wcf-legacy-app-using-corewcf/
	https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/

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

### Free public APIs for testing purposes
	https://apipheny.io/free-api/
