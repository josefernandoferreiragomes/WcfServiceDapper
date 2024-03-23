# .Net Framework, Dapper

### Connect to SQL Server Database
	https://www.learndapper.com/database-providers

### Generate WCF Proxy
	Start WCF Service
	Open VS Dev Command Prompt
	Navigate to library folder
	write the command:
	svcutil http://localhost:62341/Customers.svc /out:CustomersProxy.cs

	References:
	https://www.codeproject.com/Articles/786601/Ways-to-generate-proxy-for-WCF-Service

### Generate WCF Proxy Core
	dotnet tool install --global dotnet-svcutil
	dotnet-svcutil http://localhost:62341/Customers.svc?wsdl --outputFile CustomersProxyCore.cs	

	https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-svcutil-guide?tabs=dotnetsvcutil2x

	https://learn.microsoft.com/en-us/answers/questions/1301834/how-to-use-net-6-0-library-in-net-framework-4-7-2

### Migrate to .NET Standard 2.0
	https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-migrate-from-dotnet-framework-to-dotnet-standard

	Install Extension .NET Upgrade Assistant
	https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer
	https://developercommunity.visualstudio.com/t/the-net-portability-analyzer-missing-vs2022net6-su/1674326

	API Standard 2.0
	install System.ServiceModel.Primitives 4.4.4

### Use .net Standard 2.0 in CustomerSiteCore
	https://learn.microsoft.com/en-us/dotnet/core/porting/
	Install-Package System.Private.ServiceModel -Version 4.7.0
	https://stackoverflow.com/questions/73316508/error-platformnotsupportedexception-configuration-files-are-not-supported-or-h
	
	https://github.com/dotnet/standard/issues/781

### WCFClient details for further reading
	https://devblogs.microsoft.com/dotnet/wcf-client-60-has-been-released/
	https://www.mytechramblings.com/posts/modernize-wcf-legacy-app-using-corewcf/


## Requirements
	WCF
		4.8
		Dapper
	API
		4.8 upgraded to Standard 2.0
	Site
		4.8
	Site
		Core 8