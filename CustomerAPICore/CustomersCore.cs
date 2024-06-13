using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{
    public class CustomersCore
    {
        private IConfiguration _customerServiceConfiguration;
        private BasicHttpBinding _basicHttpBinding;      
        private EndpointAddress _customerServiceCoreEndpointAddress;
        private Customer.LibraryCore.ServiceReferenceCore.CustomerServiceCoreClient _CustomerServiceCoreClient;

        public CustomersCore(IConfiguration configuration)
        {
            _customerServiceConfiguration = configuration;            
            var customerServiceSectionCore = _customerServiceConfiguration["CustomerServiceClientCore"];            
            _customerServiceCoreEndpointAddress = new EndpointAddress(customerServiceSectionCore);
            _basicHttpBinding = new BasicHttpBinding();
            _CustomerServiceCoreClient = new Customer.LibraryCore.ServiceReferenceCore.CustomerServiceCoreClient(_basicHttpBinding, _customerServiceCoreEndpointAddress);            
        }
       
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCore(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        {
            ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> result = new ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>>();

            //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/

            var customers = new List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>();


            //var endpoint = new EndpointAddress("http://localhost:62341/Customers.svc");

            var section = _customerServiceConfiguration["CustomerServiceClientCore"];
            var endpoint = new EndpointAddress(section);
            var binding = new BasicHttpBinding();

            using (var client = new Customer.LibraryCore.ServiceReferenceCore.CustomerServiceCoreClient(binding, endpoint))
            {

                customers = client.CustomerListAsync(
                new Customer.LibraryCore.ServiceReferenceCore.CustomerCore()
                {
                    CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                }
                ).Result.ToList();
                result.Result = customers;
            }
            return result;
        }

        //Delegate example
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersGeneric(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        => Invoke(customerRequest, () => _CustomerServiceCoreClient.CustomerListAsync(customerRequest).Result.ToList());


        private ApiCoreResult<R> Invoke<R, I>(I input, Func<R> method)
        {
            var serviceName = method.Method.Name;
            var result = new ApiCoreResult<R>();
            result.ServiceName = serviceName;

            try
            {
                result.RequestMessage = input;

                var serviceResult = method();

                //MapToApiResult(serviceResult, result);

                if (serviceResult == null)
                {
                    result.Errors.Add("Error");
                }
                else
                {
                    result.Result = serviceResult;
                }

            }
            catch (Exception exp)
            {
                result.Errors.Add(exp.Message);
            }
            finally
            {
                
            }
            return result;
        }

        //MapToApiResult(List<Customer>)
    }
}
