using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceReference;

namespace CustomerAPIStandard20
{
    public class Customers
    {
        public List<Customer> GetCustomers(string nameSearchPattern)
        {
            List<Customer> customersStandard = new List<Customer> ();

            //in .NET Standard 2.0 it needs to implement IDisposable(), to be used as a using(){}
            //var client = new CustomersClient(
            //    new System.ServiceModel.Channels.CustomBinding() { },
            //    System.ServiceModel.EndpointAddressBuilder(){ }

            //    );
            var client = new CustomersClient();

            var customers = client.CustomerListAsync(
            new Customer()
            {
                CustomerName = nameSearchPattern
            }).Result;
            
            //mapper
            foreach (var customer in customers)
            {
                Customer customerStandard = new Customer()
                {
                    CustomerName = customer.CustomerName,
                    CustomerId = customer.CustomerId
                };
                customersStandard.Add( customerStandard );
            }

            return customersStandard;
        }
    }
}
