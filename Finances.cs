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
    public partial class Finances : Form
    {
        public Finances()
        {
            InitializeComponent();
            fillEmpId();
            populateExpenditures();
            populateIncomes();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Production Ob = new Production();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Health Ob = new Health();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Breedings Ob = new Breedings();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Sales Ob = new Sales();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");

        private void fillEmpId()
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;

            Con.Close();
        }

        // to display data
        private void populateExpenditures()
        {
            Con.Open();

            string query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpendituresDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void populateIncomes()
        {
            Con.Open();

            string query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void filterExpenditureDate()
        {
            Con.Open();

            string query = "select * from ExpenditureTbl where ExpDate='" + ExpDatePickerTb.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpendituresDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void filterIncomeDate()
        {
            Con.Open();

            string query = "select * from IncomeTbl where IncDate='" + IncDatePickerTb.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomesDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void ClearExpenditures()
        {
            ExpAmountTb.Text = "";
            ExpPurposeCb.SelectedIndex = -1;
        }

        private void ClearIncomes()
        {
            IncAmountTb.Text = "";
            IncPurposeCb.SelectedIndex = -1;
        }

        // save expenditures button
        private void button5_Click(object sender, EventArgs e)
        {
            if (ExpPurposeCb.SelectedIndex == -1 || ExpAmountTb.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into ExpenditureTbl (ExpDate, ExpPurpose, ExpAmount, EmpId) values ('" + ExpDateTb.Value.Date + "', '" + ExpPurposeCb.SelectedItem.ToString() + "', '" + ExpAmountTb.Text + "', '" + EmpIdCb.SelectedValue.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure saved successfully");

                    Con.Close();
                    populateExpenditures();
                    ClearExpenditures();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // save incomes button
        private void button1_Click(object sender, EventArgs e)
        {
            if (IncPurposeCb.SelectedIndex == -1 || IncAmountTb.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into IncomeTbl (IncDate, IncPurpose, IncAmt, EmpId) values ('" + IncDateTb.Value.Date + "', '" + IncPurposeCb.SelectedItem.ToString() + "', '" + IncAmountTb.Text + "', '" + EmpIdCb.SelectedValue.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income saved successfully");

                    Con.Close();
                    populateIncomes();
                    ClearIncomes();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // income datepicker
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            filterIncomeDate();
        }

        // expenditure datepicker
        private void ExpDatePickerTb_ValueChanged(object sender, EventArgs e)
        {
            filterExpenditureDate();
        }

        // income refresh button
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateIncomes();
        }

        // expenditure refresh button
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateExpenditures();
        }
    }
}
