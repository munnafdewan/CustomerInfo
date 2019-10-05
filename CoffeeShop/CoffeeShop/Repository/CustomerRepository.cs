using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoffeeShop.BLL;
using CoffeeShop.Model;

namespace CoffeeShop.Repository
{
   public class CustomerRepository
    {

      
        public bool Add(Customer customer)
        {
           
            bool isAdded = false;
            try
            {

                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);



                string commandString = @"INSERT INTO Customers (Code, Name, Address, Contact, DistrictId) Values ('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','" + customer.Contact + "', '" + customer.DistrictId + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }



                //Close
                sqlConnection.Close();


            }
            catch (Exception exception)
            {
                throw;//MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }

        public DataTable Display()
        {
            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT ROW_NUMBER() OVER (ORDER BY s.Id) AS SL,s.Id, s.Code, s.Name as'Name', s.Address, s.Contact,s.DistrictId, d.Name as 'District Name' FROM Customers as s
                                    LEFT JOIN Districts as d ON d.Id=s.DistrictId";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;


        }

        public bool SelectById(Customer customer)
        {

            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            string commandString = @"SELECT Id, Code, Name, Address, Contact, DistrictId FROM Customers WHERE Id='" + customer.Id + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"]);

                sqlDataReader.Close();
                sqlConnection.Close();
                return true;
            }

            sqlDataReader.Close();
            sqlConnection.Close();
            return false;

        }

        public bool Update(Customer customer)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Customer SET Code =  '" + customer.Code + "', Name = '" + customer.Name + "',  Address = '" + customer.Address + "', Contact = '" + customer.Contact + "',  DistrictId = '" + customer.DistrictId + "' WHERE Id = " + customer.Id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception )
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }

        public bool IsNameExist(Customer customer)

        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeSop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Code='" + customer.Code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(exeption.Message);
            }
            return isExist;
        }

        public bool IsContactExist(Customer customer)

        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Contact='" + customer.Contact + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception )
            {
                //MessageBox.Show(exeption.Message);
            }
            return isExist;
        }

        public List<Customer> Search(Customer customer)
        {
           
            List<Customer> customers = new List<Customer>();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=Coffeeshop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Code='" + customer.Code + "'";
                ////string commandString = @"SELECT * FROM Students";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customer cust = new Customer();
                    cust.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    cust.Code = sqlDataReader["Code"].ToString();
                    cust.Name = sqlDataReader["Name"].ToString();
                    cust.Address = sqlDataReader["Address"].ToString();
                    cust.Contact = sqlDataReader["Contact"].ToString();
                    cust.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"]);
                    cust.Add(cust);
                }

                sqlConnection.Close();
                return customers;



            }
            catch (Exception ex)
            {
                throw ex; //MessageBox.Show(exeption.Message);
            }
        }
    }
}
