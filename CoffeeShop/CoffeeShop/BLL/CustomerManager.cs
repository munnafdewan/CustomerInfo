using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CoffeeShop.Repository;
using CoffeeShop.Model;


namespace CoffeeShop.BLL
{
    public class CustomerManager
    {
      
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public bool SelectById(Customer customer)
        {
            return _customerRepository.SelectById(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
        public bool IsNameExist(Customer customer)
        {
            return _customerRepository.IsNameExist(customer);
        }
        public bool IsContactExist(Customer customer)
        {
            return _customerRepository.IsContactExist(customer);
        }
        public List<Customer> Search(Customer customer)
        {
            return _customerRepository.Search(customer);
        }
    }
}
