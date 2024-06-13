using Customer.LibraryCore.ServiceReference;
using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{

    public class Customers
    {
        private IConfiguration _customerServiceConfiguration;
        private BasicHttpBinding _basicHttpBinding;
        private EndpointAddress _customerServiceEndpointAddress;
        private Customer.LibraryCore.ServiceReference.CustomersClient _serviceClient;

        //using essential IoC, only for IConfiguration (default)
        public Customers(IConfiguration configuration)
        {
            _customerServiceConfiguration = configuration;
        }

        private void SetUpServiceClient()
        {
            var customerServiceSection = _customerServiceConfiguration["CustomerServiceClient"];
            _customerServiceEndpointAddress = new EndpointAddress(customerServiceSection);
            _basicHttpBinding = new BasicHttpBinding();
        }

        public List<Customer.LibraryCore.ServiceReference.Customer> GetCustomers(Customer.LibraryCore.ServiceReference.Customer customerRequest)
        {
            List<Customer.LibraryCore.ServiceReference.Customer> result = new List<Customer.LibraryCore.ServiceReference.Customer>();
           
            var customers = new List<Customer.LibraryCore.ServiceReference.Customer>();

            SetUpServiceClient();
            
            using (var client = new CustomersClient(_basicHttpBinding, _customerServiceEndpointAddress))
            {

                customers = client.CustomerListAsync(
                new Customer.LibraryCore.ServiceReference.Customer()
                {
                    CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                }
                ).Result.ToList();
                result = customers;
            }
            return result;
        }

        public ApiCoreResult<List<Customer.LibraryCore.ServiceReference.Customer>> GetCustomersCoreDeprecated(Customer.LibraryCore.ServiceReference.Customer customerRequest)
        {
            ApiCoreResult<List<Customer.LibraryCore.ServiceReference.Customer>> result = new ApiCoreResult<List<Customer.LibraryCore.ServiceReference.Customer>>();

            var customers = new List<Customer.LibraryCore.ServiceReference.Customer>();

            using (var client = new CustomersClient(_basicHttpBinding, _customerServiceEndpointAddress))
            {

                customers = client.CustomerListAsync(
                new Customer.LibraryCore.ServiceReference.Customer()
                {
                    CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                }
                ).Result.ToList();
                result.Result = customers;
            }
            return result;
        }
        
    }
}
