using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public interface ICustomerRepository
    {

        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        // 5 usual operation SelectAll, Select row, Insert, Update, Delete
        List<Customers> GetAllCustomers(); //Select all
        Customers GetCustomersByID(int customerId);  //Select by row

        bool insertCustomer(Customers customer);   // insert
        bool UpdateCustomer(Customers customer);   // Update
        
        bool DeleteCustomer(Customers customer);    //Delete
        bool DeleteCustomer(int customerId); //Delete by Id

        // void save();
    }
}
