using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CustomerService.Data;

namespace CustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomers
    {       

        [OperationContract]
        List<Customer> CustomerList(Customer customer);

        // TODO: Add your service operations here
    }
    
}
