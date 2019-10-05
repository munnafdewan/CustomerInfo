using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CoffeeShop.BLL;
using CoffeeShop.Repository;

namespace CoffeeShop.Model
{
   public class Customer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int DistrictId { get; set; }

        internal void Add(Customer cust)
        {
            throw new NotImplementedException();
        }
    }
}
