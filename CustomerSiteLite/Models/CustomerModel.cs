using CustomerService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSite.Models
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