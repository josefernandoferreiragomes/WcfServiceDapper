using Microsoft.Extensions.Configuration;
using System.ServiceModel;

namespace Customer.APICore
{
    public interface ICustomersCoreRepository
    {

        ApiCoreResult<List<Customer.LibraryCore.ServiceReferenceCore.CustomerCore>> GetCustomersCore(Customer.LibraryCore.ServiceReferenceCore.CustomerCore customerRequest);

    }
}
