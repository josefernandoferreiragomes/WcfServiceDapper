using Customer.APICore;
using ServiceReference;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private readonly IConfiguration Configuration;
        public string CustomerName { get; set; }

        private List<ServiceReference.Customer>? _customerList;

        public CustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<ServiceReference.Customer> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    //_customerList = new Customer.APICore.Customers(Configuration).GetCustomers(
                    //    new ServiceReference.Customer()
                    //    {
                    //       CustomerName = CustomerName
                    //    }
                    //);
                    _customerList = new Customer.APICore.Customers(Configuration).GetCustomersGeneric(
                        new ServiceReference.Customer()
                        {
                            CustomerName = CustomerName
                        }
                    )?.Result;
                }
                return _customerList;
            }
        }

    }
}