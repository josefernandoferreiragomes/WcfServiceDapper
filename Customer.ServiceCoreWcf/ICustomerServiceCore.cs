using CoreWCF;
using System;
using System.Runtime.Serialization;
using Customer.DataLayerCore;
using System.Web.Services.Description;
using Microsoft.Extensions.Hosting.Internal;

namespace Customer.ServiceCoreWcf
{

    [ServiceContract]
    public interface ICustomerServiceCore
    {       

        [OperationContract]
        List<Customer.DataLayerCore.CustomerCore> CustomerList(Customer.DataLayerCore.CustomerCore customer);
    }
    
    //TO BE MOVED TO FILE
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CustomerServiceCore : ICustomerServiceCore
    {       

        private Customer.DataLayerCore.ICustomerWorker _customers;

        private IConfiguration _configuration;
        public CustomerServiceCore()
        {         
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            _customers = new CustomerWorker(_configuration);
        }
       
        public List<Customer.DataLayerCore.CustomerCore> CustomerList(Customer.DataLayerCore.CustomerCore customer)
        {
            List<Customer.DataLayerCore.CustomerCore> customers = new List<Customer.DataLayerCore.CustomerCore>();
            if (customer == null)
            {
                throw new ArgumentNullException("CustomerCore");
            }
            customers = _customers.CustomerList(customer);
            return customers;
        }
    }

   
}
