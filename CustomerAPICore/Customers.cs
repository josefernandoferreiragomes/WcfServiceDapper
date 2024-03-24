using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceReference;
using Microsoft.Extensions.Configuration;

namespace CustomerAPICore
{
    public class Customers
    {
        private IConfiguration _configuration;

        public Customers(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Customer> GetCustomers(string? customerName)
        {
            //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
            var customers = new List<Customer>();
            var binding = new BasicHttpBinding();
            //var endpoint = new EndpointAddress("http://localhost:62341/Customers.svc");
            var section = _configuration["CustomerApiClient"];
            var endpoint = new EndpointAddress(section);

            using (var client = new CustomersClient(binding, endpoint))
            {

                customers = client.CustomerListAsync(
                new Customer()
                {
                    CustomerName = customerName == null ? "" : customerName
                }
                ).Result.ToList();
            }
            return customers;
        }
    }
}
