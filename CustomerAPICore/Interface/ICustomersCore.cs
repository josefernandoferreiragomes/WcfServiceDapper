using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{
    public interface ICustomersCore
    {


        ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCore(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest);


        //Delegate example
        ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCoreGeneric(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest);
    }        
}
