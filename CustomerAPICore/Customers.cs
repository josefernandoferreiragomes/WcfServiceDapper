﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceReference;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Customer.APICore
{
    public class Customers
    {
        private IConfiguration _configuration;
        //private BasicHttpBinding _basicHttpBinding;
        //private EndpointAddress _endpointAddress;
        //private CustomersClient _serviceClient;

        public Customers(IConfiguration configuration)
        {
            _configuration = configuration;
            //var section = _configuration["CustomerApiClient"];
            //_endpointAddress = new EndpointAddress(section);
            //_basicHttpBinding = new BasicHttpBinding();
            //_serviceClient = new CustomersClient(_basicHttpBinding, _endpointAddress);
        }

        public List<ServiceReference.Customer> GetCustomers(ServiceReference.Customer customerRequest)
        {
            List<ServiceReference.Customer> result = new List<ServiceReference.Customer>();

            //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/

            var customers = new List<ServiceReference.Customer>();


            //var endpoint = new EndpointAddress("http://localhost:62341/Customers.svc");

            var section = _configuration["CustomerApiClient"];
            var endpoint = new EndpointAddress(section);
            var binding = new BasicHttpBinding();

            using (var client = new CustomersClient(binding, endpoint))
            {

                customers = client.CustomerListAsync(
                new ServiceReference.Customer()
                {
                    CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
                }
                ).Result.ToList();
                result = customers;
            }
            return result;
        }

        //public ApiCoreResult<List<ServiceReference.Customer>> GetCustomersCore(ServiceReference.Customer customerRequest)
        //{
        //    ApiCoreResult<List<ServiceReference.Customer>> result = new ApiCoreResult<List<ServiceReference.Customer>>();

        //    //https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
            
        //    var customers = new List<ServiceReference.Customer>();


        //    //var endpoint = new EndpointAddress("http://localhost:62341/Customers.svc");

        //    var section = _configuration["CustomerApiClient"];
        //    var endpoint = new EndpointAddress(section);
        //    var binding = new BasicHttpBinding();

        //    using (var client = new CustomersClient(binding, endpoint))
        //    {

        //        customers = client.CustomerListAsync(
        //        new ServiceReference.Customer()
        //        {
        //            CustomerName = customerRequest.CustomerName == null ? "" : customerRequest.CustomerName
        //        }
        //        ).Result.ToList();
        //        result.Result= customers;
        //    }
        //    return result;
        //}

        //public ApiCoreResult<List<ServiceReference.Customer>> GetCustomersGeneric(ServiceReference.Customer customerRequest)
        //=> Invoke(customerRequest, () => _serviceClient.CustomerListAsync(customerRequest).Result.ToList());

        
        //private ApiCoreResult<R> Invoke<R,I>(I input, Func<R> method)
        //{
        //    var serviceName = method.Method.Name;
        //    var result = new ApiCoreResult<R>();
        //    result.ServiceName=serviceName;

        //    try
        //    {
        //        result.RequestMessage = input;

        //        var serviceResult = method();

        //        //MapToApiResult(serviceResult, result);

        //        if (serviceResult==null)
        //        {
        //            result.Errors.Add("Error");
        //        }
        //        else
        //        {
        //            result.Result = serviceResult;
        //        }

        //    }
        //    catch (Exception exp)
        //    {
        //        result.Errors.Add(exp.Message);
        //    }
        //    return result;
        //}

        //MapToApiResult(List<Customer>)
    }
}
