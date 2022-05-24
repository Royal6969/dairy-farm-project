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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Finance();
            Logistic();
            GetMax();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Production Ob = new Production();
            Ob.Show();
            this.Hide();
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
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

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");

        private void Finance()
        {
            // we calculate the Finance related Analytics

            Con.Open();

            int inc, exp; 
            double bal;

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl", Con);
            
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            inc = Convert.ToInt32(dt1.Rows[0][0].ToString());
            IncLbl.Text = "Rs: " + dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            exp = Convert.ToInt32(dt2.Rows[0][0].ToString());
            ExpLbl.Text = "Rs: " + dt2.Rows[0][0].ToString();

            bal = inc - exp;
            BalLbl.Text = "Rs: " + bal;

            Con.Close();
        }

        private void Logistic()
        {
            // we calculate the Logistics related Analytics

            Con.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from CowTbl", Con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            CowNumLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(TotalMilk) from MilkTbl", Con);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            MilkLitersLbl.Text = dt2.Rows[0][0].ToString() + " liters";

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from EmployeeTbl", Con);

            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            EmpNumLbl.Text = dt3.Rows[0][0].ToString();

            Con.Close();
        }

        private void GetMax()
        {
            SqlDataAdapter sda1 = new SqlDataAdapter("select max(IncAmt) from IncomeTbl group by IncDate", Con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            HighSaleLbl.Text = "Rs: " + dt1.Rows[0][0].ToString();
        }
    }
}
