using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CustomerSite.Models
{
    public class CustomerModel
    {
        private HttpClient _httpclient;

        public string CustomerName { get; set; }

        //private List<Customer> _customerList;
        //public List<Customer> CustomerList
        //{
        //    get
        //    {
        //        if (_customerList == null)
        //        {
        //            _httpclient = new HttpClient();
        //            _httpclient.BaseAddress = new Uri("http://localhost:5015/Api/Customer/");

        //            var client = new CustomerApiCoreProxy(
        //                "",
        //                _httpclient
        //                );
        //            _customerList = client.CustomerAsync(CustomerName).Result.ToList();
        //        }
        //        return _customerList;
        //    }
        //}
        
        private List<CustomerCore> _customerList;

        public List<CustomerCore> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _httpclient = new HttpClient();
                    _httpclient.BaseAddress = new Uri("http://localhost:5015/Api/Customer/");

                    var client = new CustomerApiCoreProxy(
                        "",
                        _httpclient
                        );
                    _customerList = client.CustomerCoreAsync(CustomerName).Result.ToList();
                }
                return _customerList;
            }
        }
    }
}