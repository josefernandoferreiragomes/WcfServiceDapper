using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.DataLayerCore
{
    public interface ICustomerWorker
    {
        List<CustomerCore> CustomerList(CustomerCore customer);
    }
}
