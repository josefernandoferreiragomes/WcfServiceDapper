using Microsoft.Extensions.Configuration;
using Customer.DataLayerCore;

namespace Customer.DataLayerCore.Test.Unit
{
    /// <summary>
    /// Test client related methods
    /// The tests are written using Gherkin specification
    /// And are organised in regions comprising Arrange, Act, Assert
    /// </summary>
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
        public void Given_CustomersRepository_When_CustomersAreRequested_Then_CustomersAreReturned()
        {
            #region Arrange
            CustomerCore customerCore = new CustomerCore()
            {
                CustomerName = "a"
            };
            #endregion

            #region Act
            var customers = _customers.GetDataFromDatabaseWithDapper(customerCore);
            #endregion

            #region Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
            Assert.Pass();
            #endregion
        }
    }
}