using Customer.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Configuration;
namespace CustomerSite.Models
{
    public class CustomerModel
    {
        private HttpClient _httpclient;

        public string CustomerName { get; set; }

        private List<Customer.Library.CustomerCore> _customerList;

        public List<Customer.Library.CustomerCore> CustomerList
        {
            get
            {
                if (_customerList == null)
                {              

                    var httpclient = new HttpClient();
                 
                    httpclient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("CustomerAPIClient")); 
                    var clientApiClient = new ClientApiClient(
                        "/",
                        httpclient
                    );
                    _customerList = clientApiClient.CustomerCoreAsync(CustomerName).Result.ToList();
                }
                return _customerList;
            }
        }
    }
}