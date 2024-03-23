using CustomerAPICore;
using ServiceReference;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        public string CustomerName { get; set; }

        private List<Customer>? _customerList;
        public List<Customer> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new CustomerAPICore.Customers().GetCustomers(CustomerName);
                }
                return _customerList;
            }
        }

    }
}