using CustomerAPIStandard20;
using CustomerService.Data;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private List<CustomerStandard> _customerList;
        public List<CustomerStandard> CustomerList
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