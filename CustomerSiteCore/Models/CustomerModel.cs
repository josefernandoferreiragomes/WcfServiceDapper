using Customer.APICore;
using Customer.LibraryCore.ServiceReferenceCore;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private readonly IConfiguration Configuration;
        public string CustomerName { get; set; }

        private List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>? _customerList;

        public CustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    //_customerList = new Customer.APICore.Customers(Configuration).GetCustomers(
                    //    new Customer.LibraryCore.ServiceReferenceCore.Customer()
                    //    {
                    //       CustomerName = CustomerName
                    //    }
                    //);
                    //_customerList = new Customer.APICore.Customers(Configuration).GetCustomersGeneric(
                    //    new Customer.LibraryCore.ServiceReferenceCore.Customer()
                    //    {
                    //        CustomerName = CustomerName
                    //    }
                    //)?.Result;
                    
                    _customerList = new Customer.APICore.CustomersCore(Configuration).GetCustomersCore(
                        new Customer.LibraryCore.ServiceReferenceCore.CustomerCore()
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