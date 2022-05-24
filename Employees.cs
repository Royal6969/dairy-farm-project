using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_farm_project
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");

        // to display data
        private void populate()
        {
            Con.Open();

            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            EmployeeNameTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";
            GenderCb.SelectedIndex = -1;
            PasswordTb.Text = "";
            key = 0;
        }

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmployeeNameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into EmployeeTbl (EmpName, EmpDob, Gender, Phone, Address, EmpPass) values ('" + EmployeeNameTb.Text + "', '" + DOBTb.Value.Date + "', '" + GenderCb.SelectedItem.ToString() + "', '" + PhoneTb.Text + "', '" + AddressTb.Text + "', '" + PasswordTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee saved successfully");

                    Con.Close();
                    populate();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOBTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            PasswordTb.Text = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (EmployeeNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // clear button
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the employee to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "delete from EmployeeTbl where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully");

                    Con.Close();
                    populate();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // update button
        private void button2_Click(object sender, EventArgs e)
        {
            if (EmployeeNameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "update EmployeeTbl set EmpName='" + EmployeeNameTb.Text + "', EmpDob='" + DOBTb.Value.Date + "', Gender='" + GenderCb.SelectedItem.ToString() + "', Phone='" + PhoneTb.Text + "', Address='" + AddressTb.Text + "', EmpPass='" + PasswordTb.Text + "' where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated successfully");

                    Con.Close();
                    populate();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // close app button
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // minimize windows
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
