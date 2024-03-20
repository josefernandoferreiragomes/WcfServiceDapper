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