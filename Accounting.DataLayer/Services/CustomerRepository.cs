using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Accounting_DBEntities db;
        public CustomerRepository(Accounting_DBEntities context)
        {
            db = context;
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                Console.WriteLine("Error!");
                return false;
            }

            
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = GetCustomersByID(customerId);
            try
            {
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                Console.WriteLine("Error!");
                return false;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            var customer = db.Customers.Where(c => c.FullName.Contains(parameter) || c.Mobile.Contains(parameter) || c.Email.Contains(parameter)).ToList();
            return customer;
        }

        public Customers GetCustomersByID(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool insertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {
                Console.WriteLine("Eror!");
                return false;
            }
        }

        //public void save()
        //{
        //    db.SaveChanges();
        //}

        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                Console.WriteLine("Eror!");
                return false;
            }
        }
    }
}
