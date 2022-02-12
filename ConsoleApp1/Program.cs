using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            var allCustomer = customerRepository.GetAllCustomers();
        }
    }
}
