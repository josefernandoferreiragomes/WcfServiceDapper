using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{
    public class CustomersCore : ICustomersCore
    {
        //using IoC everywhere
        private ICustomersCoreRepository _customersCoreRepository;
        public CustomersCore(ICustomersCoreRepository customersCoreRepository)
        {
            this._customersCoreRepository = customersCoreRepository;
        }
       
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCore(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        {
            ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> result = new ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>>();

            result = _customersCoreRepository.GetCustomersCore(
            new Customer.LibraryCore.ServiceReferenceCore.CustomerCore()
            {
                CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
            }
            );
            
            return result;
        }

        //Delegate example
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGeneric(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        => Invoke(customerRequest, () => _customersCoreRepository.GetCustomersCore(customerRequest)?.Result);


        private ApiCoreResult<R> Invoke<R, I>(I input, Func<R> method)
        {
            var serviceName = method.Method.Name;
            var result = new ApiCoreResult<R>();
            result.ServiceName = serviceName;

            try
            {
                result.RequestMessage = input;

                var serviceResult = method();

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

    }
}
