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
    public partial class Breedings : Form
    {
        public Breedings()
        {
            InitializeComponent();
            fillCowId();
            populate();
        }

        private void Breedings_Load(object sender, EventArgs e)
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

            string query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            AgeTb.Text = "";
            RemarksTb.Text = "";
            key = 0;
        }

        private void GetCowName()
        {
            Con.Open();

            string query = "select * from CowTbl where CowId=" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
                AgeTb.Text = dr["Age"].ToString();
            }

            Con.Close();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AgeTb.Text == "" || RemarksTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into BreedTbl (HeatDate, BreedDate, CowId, CowName, PregDate, ExpDateCalve, DateCalved, CowAge, Remarks) values ('" + HeatTb.Value.Date + "', '" + BreedTb.Value.Date + "', " + CowIdCb.SelectedValue.ToString() + ", '" + CowNameTb.Text + "', '" + PregnancyTb.Value.Date + "', '" + ExpectedTb.Value.Date + "', '" + CalvedTb.Value.Date + "', '" + AgeTb.Text + "', '" + RemarksTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding report saved");

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

        // clear button
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        int key = 0;
        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatTb.Text = BreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            BreedTb.Text = BreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowIdCb.SelectedValue = BreedDGV.SelectedRows[0].Cells[3].Value.ToString();
            CowNameTb.Text = BreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregnancyTb.Text = BreedDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExpectedTb.Text = BreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            CalvedTb.Text = BreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            AgeTb.Text = BreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            RemarksTb.Text = BreedDGV.SelectedRows[0].Cells[9].Value.ToString();

            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BreedDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the breed report to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "delete from BreedTbl where BrId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed deleted successfully");

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
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || AgeTb.Text == "" || RemarksTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "update BreedTbl set HeatDate='" + HeatTb.Value.Date + "', BreedDate='" + BreedTb.Value.Date + "', CowId='" + CowIdCb.SelectedValue.ToString() + "', CowName='" + CowNameTb.Text + "', PregDate='" + PregnancyTb.Value.Date + "', ExpDateCalve='" + ExpectedTb.Value.Date + "', DateCalved='" + CalvedTb.Value.Date + "', CowAge='" + AgeTb.Text + "', Remarks='" + RemarksTb.Text + "' where BrId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding updated successfully");

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
