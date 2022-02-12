using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork();

            var res = db.CustomerRepository.GetAllCustomers();

            db.Dispose(); // unallocate resources
        }
    }
}
