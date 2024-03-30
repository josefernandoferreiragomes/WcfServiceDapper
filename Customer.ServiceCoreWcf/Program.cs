using Customer.DataLayerCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

//Add service client to DI
builder.Services.AddSingleton<ICustomerWorker, CustomerWorker>();

//default url : http://localhost:5153/CustomerServiceCore.svc
var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<CustomerServiceCore>();
    serviceBuilder.AddServiceEndpoint<CustomerServiceCore, ICustomerServiceCore>(new BasicHttpBinding(), "/CustomerServiceCore.svc");
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;
});

app.Run();
