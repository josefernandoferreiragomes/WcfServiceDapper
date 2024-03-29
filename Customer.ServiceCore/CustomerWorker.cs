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
        public List<Customer> GetDataFromDatabaseWithDapper(Customer customer)
        {
            List<Customer> result = new List<Customer>();
            // using Dapper;
            var connectionString = _configuration["CustomersDB"];
            // Connect to the database 
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a query that retrieves all books with an author name of "John Smith"    
                //TO BE REFACTURED WITH PATTERN AND SECURITY FEATURES
                var sql = $"SELECT TOP 17 * FROM Customers WHERE CustomerName LIKE '%'+@customerName+'%' ";

                // Use the Query method to execute the query and return a list of objects    
                result = connection.Query<Customer>(
                    sql,
                    new { customerName = customer.CustomerName }
                    ).ToList();
            }
            return result;

        }

        public List<Customer> GetDataFromDatabaseWithDapperNative(Customer customer)
        {
            List<Customer> result = new List<Customer>();
            // using Dapper;
            var connectionString = _configuration["CustomersDB"];
            // Connect to the database 
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a query that retrieves all books with an author name of "John Smith"    
                //TO BE REFACTURED WITH PATTERN AND SECURITY FEATURES
                //var sql = $"SELECT TOP 17 * FROM Customers WHERE CustomerName LIKE '%'+@customerName+'%' ";

                // Use the Query method to execute the query and return a list of objects    
                result = connection.GetList<Customer>(customer).ToList();
                //.Query<Customer>(
                //    sql,
                //    new { customerName = customer.CustomerName }
                //    ).ToList();



            }
            return result;

        }

        public List<Customer> CustomerList(Customer customer)
        {
            List<Customer> customers = new List<Customer>();
            if (customer == null)
            {
                throw new ArgumentNullException("Customer");
            }
            customers = GetDataFromDatabaseWithDapper(customer);
            return customers;
        }
    }
}
