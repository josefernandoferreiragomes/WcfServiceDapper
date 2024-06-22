using Microsoft.Extensions.Configuration;
using System.ServiceModel;
using static Customer.APICore.CustomersCore;

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

        #region Generic service call with delegate
        private delegate R GenericServiceCall<R,I>();

        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGenericWithDelegate(
            Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest
        )
        {
            var processServiceCall = new GenericServiceCall<ApiCoreResult<List<LibraryCore.ServiceReferenceCore.CustomerCore>>, LibraryCore.ServiceReferenceCore.CustomerCore>(
                () =>_customersCoreRepository.GetCustomersCore(customerRequest)
            );
            return InvokeGenericWithDelegate(
                customerRequest,
                processServiceCall
            )?.Result;
        }

        private ApiCoreResult<R> InvokeGenericWithDelegate<R,I>(I input, GenericServiceCall<R,I> processServiceCall)
        {
            var serviceName = processServiceCall.Method.Name;
            var result = new ApiCoreResult<R>();
            result.ServiceName = serviceName;

            try
            {
                result.RequestMessage = input;

                var serviceResult = processServiceCall;

                if (serviceResult == null)
                {
                    result.Errors.Add("Error");
                }
                else
                {
                    result.Result = serviceResult.Invoke();
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

        #endregion

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

        #region Delegate example using Func<> and lambda expression
        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGenericLambdaAndFunc(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        => InvokeServiceMethod(customerRequest, () => _customersCoreRepository.GetCustomersCore(customerRequest)?.Result);

        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGenericAnonymousAndFunc(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        {
            return InvokeServiceMethod<ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>>, Customer.LibraryCore.ServiceReferenceCore.CustomerCore>(
                customerRequest, 
                () => _customersCoreRepository.GetCustomersCore(customerRequest)
            )?.Result;
        }

        public ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGenericAnonymousDelegateAndFunc(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest)
        {
            return InvokeServiceMethod<ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>>, Customer.LibraryCore.ServiceReferenceCore.CustomerCore>(
                customerRequest,
                delegate ()
                {
                    return _customersCoreRepository.GetCustomersCore(customerRequest);
                }
            )?.Result;
        }

        private ApiCoreResult<R> InvokeServiceMethod<R, I>(I input, Func<R> method)
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

        #endregion

    }
}
