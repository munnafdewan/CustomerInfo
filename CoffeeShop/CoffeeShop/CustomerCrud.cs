using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.BLL;
using CoffeeShop.Model;

using System.Data.SqlClient;

namespace CoffeeShop
{
    public partial class CustomerCrud : Form
    {
        ErrorProvider erp = new ErrorProvider();
        CustomerManager _customerManager = new CustomerManager();
        DistrictManager _districtManager = new DistrictManager();
        Customer customer = new Customer();
        int index = 0;
        public CustomerCrud()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            erp.Clear();

            if ((codeTextBox.Text.Equals("") || codeTextBox.Text.Length != 4))
            {
                index++;
                erp.SetError(codeTextBox, "Enter your Id and Id Must be 4 charecter");
                return;

            }
            if (_customerManager.IsNameExist(customer))
            {
                index++;
                erp.SetError(codeTextBox, "Please Insert  Unique Code");
                //ep.SetError(contactTextBox, "Enter your Id and Id Must be 4 charecter");
                //MessageBox.Show(codeTextBox.Text + " Already Exist!!");

                return;
            }

            if ((contactTextBox.Text.Equals("") || contactTextBox.Text.Length != 11))
            {
                index++;
                erp.SetError(contactTextBox, "please insert 11 charecter");
                return;

            }

            if (_customerManager.IsContactExist(customer))
            {
                index++;

                erp.SetError(contactTextBox, "unique contact need");


                return;
            }
            if ((nameTextBox.Text.Equals("")))
            {
                index++;
                erp.SetError(nameTextBox, "insert Name");
                return;

            }
            if (districtComboBox.SelectedItem == null)
            {
                index++;
                erp.SetError(districtComboBox, "insert District Name");
                return;

            }


            customer.Code = codeTextBox.Text;
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.Contact = contactTextBox.Text;
            customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);


            if (saveButton.Text == "Save")
            {

                if (_customerManager.Add(customer))
                {
                    MessageBox.Show("added");
                    dataGridView.DataSource = _customerManager.Display();
                    clear();
                }
            }
            else
            {
                customer.Id = Convert.ToInt32(idTextBox.Text);
                if (_customerManager.Update(customer))
                {
                    MessageBox.Show("Update");
                    dataGridView.DataSource = _customerManager.Display();
                    clear();
                }
            }



        }

        private void CustomerCrud_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            idTextBox.Visible = false;
            dataGridView.DataSource = _customerManager.Display();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                (dataGridView.Columns[1]).Visible = false;
                (dataGridView.Columns[6]).Visible = false;
            }
            AllComboLOad();
        }

        public void AllComboLOad()
        {
            districtComboBox.DataSource = _districtManager.loadCombo();
            districtComboBox.DisplayMember = "Name";
            districtComboBox.ValueMember = "Id";
            districtComboBox.SelectedIndex = 0;

        }

        public void clear()
        {
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            contactTextBox.Text = "";
            districtComboBox.Text = "--please Select District--";
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           idTextBox.Text = dataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            codeTextBox.Text = dataGridView.SelectedRows[1].Cells["Code"].Value.ToString();
            nameTextBox.Text = dataGridView.SelectedRows[2].Cells["Name"].Value.ToString();
            addressTextBox.Text = dataGridView.SelectedRows[3].Cells["Address"].Value.ToString();
            contactTextBox.Text = dataGridView.SelectedRows[4].Cells["Contact"].Value.ToString();
            districtComboBox.SelectedValue = Convert.ToInt32(dataGridView.SelectedRows[5].Cells["DistrictId"].Value.ToString());

            saveButton.Text = "Update";
        }
    }
}
