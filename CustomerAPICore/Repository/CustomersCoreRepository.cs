using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{
    public class CustomersCoreRepository : ICustomersCoreRepository
    {
        private IConfiguration _customerServiceConfiguration;
        private BasicHttpBinding _basicHttpBinding;      
        private EndpointAddress _customerServiceCoreEndpointAddress;
      
        public CustomersCoreRepository(IConfiguration configuration)
        {
            _customerServiceConfiguration = configuration;            
          
        }
       
        private void SetUpServiceClient()
        {
            var customerServiceSectionCore = _customerServiceConfiguration["CustomerServiceClientCore"];
            _customerServiceCoreEndpointAddress = new EndpointAddress(customerServiceSectionCore);
            _basicHttpBinding = new BasicHttpBinding();
        }
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCore(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        {
            ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> result = new ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>>();

            var customers = new List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>();
            try
            {
                SetUpServiceClient();
                using (var client = new Customer.LibraryCore.ServiceReferenceCore.CustomerServiceCoreClient(_basicHttpBinding, _customerServiceCoreEndpointAddress))
                {

                    customers = client.CustomerListAsync(
                    new Customer.LibraryCore.ServiceReferenceCore.CustomerCore()
                    {
                        CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                    }
                    ).Result.ToList();
                    result.Result = customers;
                }
            }
            catch (Exception ex)
            {
                //handle exception
                throw ex;
            }
            return result;
        }

    }
}
