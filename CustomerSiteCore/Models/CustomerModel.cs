using Customer.APICore;
using Customer.LibraryCore.ServiceReferenceCore;

namespace CustomerSiteCore.Models
{
    public class CustomerModel
    {
        private ICustomersCore _customersCore;
        public string CustomerName { get; set; }

        private List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>? _customerList;

        public CustomerModel(ICustomersCore customersCore)
        {
            this._customersCore = customersCore;
        }

        public List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    
                    _customerList = _customersCore.GetCustomersCoreGenericWithDelegate(
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