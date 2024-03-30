using Microsoft.Extensions.Configuration;
using Customer.DataLayerCore;

namespace Customer.DataLayerCore.Test.Unit
{
    public class CustomerCoreTest
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;
        Customer.DataLayerCore.CustomerWorker _customers;

        public CustomerCoreTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            _customers = new CustomerWorker(_configuration);

        }
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestHasCustomers()
        {
            CustomerCore customerCore = new CustomerCore()
            {
                CustomerName = "a"
            };
            var customers = _customers.GetDataFromDatabaseWithDapper(customerCore);
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
            Assert.Pass();
        }
    }
}