using CustomerAPICore;
using ServiceReference;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private readonly IConfiguration Configuration;
        public string CustomerName { get; set; }

        private List<Customer>? _customerList;

        public CustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Customer> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new CustomerAPICore.Customers(Configuration).GetCustomers(CustomerName);
                }
                return _customerList;
            }
        }

    }
}