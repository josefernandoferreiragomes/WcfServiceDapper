using Customer.Library;
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

        //from api client
        //private List<CustomerCore> _customerList;

        //public List<CustomerCore> CustomerList
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
        //            _customerList = client.CustomerCoreAsync(CustomerName).Result.ToList();
        //        }
        //        return _customerList;
        //    }
        //}

        //from library
        //private List<ClientApiClient.CustomerCore> _customerList;

        //public List<ClientApiClient.CustomerCore> CustomerList
        //{
        //    get
        //    {
        //        if (_customerList == null)
        //        {
        //            _httpclient = new HttpClient();
        //            _httpclient.BaseAddress = new Uri("http://localhost:5015/Api/Customer/");

        //            var client = new ClientApiClient.Client(
        //                "http://localhost:5015/Api/Customer/",
        //                _httpclient
        //                );
        //            _customerList = client.CustomerCoreAsync(CustomerName).Result.ToList();
        //        }
        //        return _customerList;
        //    }
        //}

        //teste command API proxy
        private List<Customer.Library.CustomerCore> _customerList;

        public List<Customer.Library.CustomerCore> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    //_httpclient = new HttpClient();
                    //_httpclient.BaseAddress = new Uri("http://localhost:5015/Api/Customer/");

                    //var client = new CustomerApiCoreProxy(
                    //    "",
                    //    _httpclient
                    //    );
                    //_customerList = client.CustomerCoreAsync(CustomerName).Result.ToList();

                    var httpclient = new HttpClient();
                    //httpclient.BaseAddress = new Uri(new Uri("http://localhost:5015/Api/Customer/"), "http://localhost:5015/Api/Customer/");
                    httpclient.BaseAddress = new Uri("http://localhost:5015/Api/Customer/");
                    var client2 = new ClientApiClient(
                        "/",
                        httpclient
                        );
                    _customerList = client2.CustomerCoreAsync(CustomerName).Result.ToList();
                }
                return _customerList;
            }
        }
    }
}