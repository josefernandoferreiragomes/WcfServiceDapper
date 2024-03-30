using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using DapperExtensions;

namespace Customer.DataLayerCore
{
    public class CustomerWorker : ICustomerWorker
    {
        private IConfiguration _configuration;
        public CustomerWorker(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CustomerCore> GetDataFromDatabaseWithDapper(CustomerCore customer)
        {
            List<CustomerCore> result = new List<CustomerCore>();
            // using Dapper;
            var connectionString = _configuration["CustomersDB"];
            // Connect to the database 
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a query that retrieves all books with an author name of "John Smith"    
                //TO BE REFACTURED WITH PATTERN AND SECURITY FEATURES
                var sql = $"SELECT TOP 17 * FROM Customers WHERE CustomerName LIKE '%'+@customerName+'%' ";

                // Use the Query method to execute the query and return a list of objects    
                result = connection.Query<CustomerCore>(
                    sql,
                    new { customerName = customer.CustomerName }
                    ).ToList();
            }
            return result;

        }

        public List<CustomerCore> GetDataFromDatabaseWithDapperNative(CustomerCore customer)
        {
            List<CustomerCore> result = new List<CustomerCore>();
            // using Dapper;
            var connectionString = _configuration["CustomersDB"];
            // Connect to the database 
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a query that retrieves all books with an author name of "John Smith"    
                //TO BE REFACTURED WITH PATTERN AND SECURITY FEATURES
                //var sql = $"SELECT TOP 17 * FROM Customers WHERE CustomerName LIKE '%'+@customerName+'%' ";

                // Use the Query method to execute the query and return a list of objects    
                result = connection.GetList<CustomerCore>(customer).ToList();
                //.Query<Customer>(
                //    sql,
                //    new { customerName = customer.CustomerName }
                //    ).ToList();



            }
            return result;

        }

        public List<CustomerCore> CustomerList(CustomerCore customer)
        {
            List<CustomerCore> customers = new List<CustomerCore>();
            if (customer == null)
            {
                throw new ArgumentNullException("Customer");
            }
            customers = GetDataFromDatabaseWithDapper(customer);
            return customers;
        }
    }
}
