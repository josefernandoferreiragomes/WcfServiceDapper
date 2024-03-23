using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceReference;

namespace CustomerAPICore
{
    public class Customers
    {
        public List<Customer> GetCustomers(string? customerName)
        {                        
            var client = new CustomersClient();

            var customers = client.CustomerListAsync(
            new Customer()
                {
                    CustomerName = customerName == null ? "" : customerName
                }
            ).Result.ToList();                       

            return customers;
        }
    }
}
