using CustomerService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSiteLite.Models
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
                    _customerList = new CustomerAPI.Customers().GetCustomers("");
                }
                return _customerList;
            }
        }

    }
}