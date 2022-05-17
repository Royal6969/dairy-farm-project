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
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
            fillCowId();
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Production_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void panel9_Paint(object sender, PaintEventArgs e)
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

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=SERGIODIAZ\SQLEXPRESS;Initial Catalog=DairyFarm;Integrated Security=True");

        private void fillCowId()
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;

            Con.Close();
        }

        // to display data
        private void populate()
        {
            Con.Open();

            string query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            AmTb.Text = "";
            NoonTb.Text = "";
            PmTb.Text = "";
            TotalTb.Text = "";
            key = 0;
        }

        private void GetCowName()
        {
            Con.Open();

            string query = "select * from CowTbl where CowId="+ CowIdCb.SelectedValue.ToString() +"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach(DataRow dr in dt.Rows)
                CowNameTb.Text = dr["CowName"].ToString();

            Con.Close();
        }

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AmTb.Text == "" || NoonTb.Text == "" || PmTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into MilkTbl (CowId, CowName, AmMilk, NoonMilk, PmMilk, TotalMilk, DateProd) values ("+ CowIdCb.SelectedValue.ToString() +", '" + CowNameTb.Text + "', '" + AmTb.Text + "', '" + NoonTb.Text + "', '" + PmTb.Text + "', '" + TotalTb.Text + "', '"+ DateTb.Value.Date +"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk saved successfully");

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

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void PmTb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(AmTb.Text) + Convert.ToInt32(NoonTb.Text) + Convert.ToInt32(PmTb.Text);
            TotalTb.Text = "" + total;
        }

        int key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            AmTb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            NoonTb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateTb.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the milk product to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "delete from MilkTbl where MId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully");

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

        // edit button
        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AmTb.Text == "" || NoonTb.Text == "" || PmTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "update MilkTbl set CowName='" + CowNameTb.Text + "', AmMilk='" + AmTb.Text + "', NoonMilk='" + NoonTb.Text + "', PmMilk='" + PmTb.Text + "', TotalMilk='" + TotalTb.Text + "', DateProd='" + DateTb.Value.Date + "' where MId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully");

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
    }
}
