﻿using CustomerService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CustomerAPIStandard20
{
    public class Customers
    {
        public List<CustomerStandard> GetCustomers(string nameSearchPattern)
        {
            List<CustomerStandard> customersStandard = new List<CustomerStandard> ();

            var client = new CustomersClient();
            
            var customers = client.CustomerList(
            new Customer()
            {
                CustomerName = nameSearchPattern
            }).ToList();
            
            //mapper
            foreach (var customer in customers)
            {
                CustomerStandard customerStandard = new CustomerStandard()
                {
                    CustomerName = customer.CustomerName,
                    CustomerId = customer.CustomerId
                };
                customersStandard.Add( customerStandard );
            }

            return customersStandard;
        }
    }
}
