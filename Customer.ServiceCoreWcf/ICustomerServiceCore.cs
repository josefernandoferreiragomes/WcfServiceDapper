using CoreWCF;
using System;
using System.Runtime.Serialization;
using Customer.DataLayerCore;

namespace Customer.ServiceCoreWcf
{

    [ServiceContract]
    public interface ICustomerServiceCore
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract]
        //List<Customer.DataLayerCore.Customer> CustomerList(Customer.DataLayerCore.Customer customer);
    }

    public class CustomerServiceCore : ICustomerServiceCore
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //private Customer.DataLayerCore.CustomerWorker _customers;
        //public Service(Customer.DataLayerCore.CustomerWorker customers)
        //{
        //    _customers = customers;
        //}
        //public List<Customer.DataLayerCore.Customer> CustomerList(Customer.DataLayerCore.Customer customer)
        //{
        //    List<Customer.DataLayerCore.Customer> customers = new List<Customer.DataLayerCore.Customer>();
        //    if (customer == null)
        //    {
        //        throw new ArgumentNullException("Customer");
        //    }
        //    customers = _customers.GetDataFromDatabaseWithDapper(customer);
        //    return customers;
        //}
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
