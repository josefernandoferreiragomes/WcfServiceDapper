using Customer.APICore;
using ServiceReference;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private readonly IConfiguration Configuration;
        public string CustomerName { get; set; }

        private List<CustomerServiceCoreProxy.CustomerCore>? _customerList;

        public CustomerModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<CustomerServiceCoreProxy.CustomerCore> CustomerList
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
                    //_customerList = new Customer.APICore.Customers(Configuration).GetCustomersGeneric(
                    //    new ServiceReference.Customer()
                    //    {
                    //        CustomerName = CustomerName
                    //    }
                    //)?.Result;
                    
                    _customerList = new Customer.APICore.CustomerCores(Configuration).GetCustomersCore(
                        new CustomerServiceCoreProxy.CustomerCore()
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