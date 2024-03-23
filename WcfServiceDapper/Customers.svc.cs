using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CustomerService.Data;
using System.Configuration;

namespace CustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Customers : ICustomers
    {       

        public List<Customer> GetDataFromDatabaseWithDapper(Customer customer)
        {
            List<Customer> result = new List<Customer>();
            // using Dapper;
            var connectionString = ConfigurationManager.ConnectionStrings["CustomersDB"].ConnectionString;//"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=LoanManagementDB;Integrated Security=true;TrustServerCertificate=True";
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
        public List<Customer> CustomerList(Customer customer)
        {
            List <Customer> customers = new List<Customer>();
            if (customer == null)
            {
                throw new ArgumentNullException("Customer");
            }
            customers = GetDataFromDatabaseWithDapper(customer);
            return customers;
        }
    }
}
