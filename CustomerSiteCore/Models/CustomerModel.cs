using CustomerAPIStandard20;
using CustomerLibraryCore;
using ServiceReference;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private List<Customer> _customerList;
        public List<Customer> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new CustomerAPIStandard20.Customers().GetCustomers("");
                }
                return _customerList;
            }
        }

    }
}