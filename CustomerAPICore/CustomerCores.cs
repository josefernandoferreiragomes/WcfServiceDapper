using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceReference;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using CustomerServiceCoreProxy;

namespace Customer.APICore
{
    public class CustomerCores
    {
        private IConfiguration _customerServiceConfiguration;
        private BasicHttpBinding _basicHttpBinding;      
        private EndpointAddress _customerServiceCoreEndpointAddress;
        private CustomerServiceCoreProxy.CustomerServiceCoreClient _CustomerServiceCoreClient;

        public CustomerCores(IConfiguration configuration)
        {
            _customerServiceConfiguration = configuration;            
            var customerServiceSectionCore = _customerServiceConfiguration["CustomerServiceClientCore"];            
            _customerServiceCoreEndpointAddress = new EndpointAddress(customerServiceSectionCore);
            _basicHttpBinding = new BasicHttpBinding();
            _CustomerServiceCoreClient = new CustomerServiceCoreProxy.CustomerServiceCoreClient(_basicHttpBinding, _customerServiceCoreEndpointAddress);            
        }
       
        public ApiCoreResult<List<CustomerServiceCoreProxy.CustomerCore>> GetCustomersCore(CustomerServiceCoreProxy.CustomerCore customerRequest)
        {
            ApiCoreResult<List<CustomerServiceCoreProxy.CustomerCore>> result = new ApiCoreResult<List<CustomerServiceCoreProxy.CustomerCore>>();

            //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/

            var customers = new List<CustomerServiceCoreProxy.CustomerCore>();


            //var endpoint = new EndpointAddress("http://localhost:62341/Customers.svc");

            var section = _customerServiceConfiguration["CustomerServiceClientCore"];
            var endpoint = new EndpointAddress(section);
            var binding = new BasicHttpBinding();

            using (var client = new CustomerServiceCoreProxy.CustomerServiceCoreClient(binding, endpoint))
            {

                customers = client.CustomerListAsync(
                new CustomerServiceCoreProxy.CustomerCore()
                {
                    CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                }
                ).Result.ToList();
                result.Result = customers;
            }
            return result;
        }

        //Delegate example
        public ApiCoreResult<List<CustomerServiceCoreProxy.CustomerCore>> GetCustomersGeneric(CustomerServiceCoreProxy.CustomerCore customerRequest)
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
