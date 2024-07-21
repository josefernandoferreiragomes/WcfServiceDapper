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

    [ServiceContract]
    public interface ICustomers
    {       

        [OperationContract]
        List<Customer> CustomerList(Customer customer);

    }
    
}
