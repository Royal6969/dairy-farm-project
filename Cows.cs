using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dairy_farm_project
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }

        private void licensing1_Load(object sender, EventArgs e)
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
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
        int age = 0;

        // save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "insert into CowTbl (CowName, EarTag, Color, Breed, Age, WeightAtBirth, Pasture) values ('"+ CowNameTb.Text +"', '" + EarTagTb.Text + "', '" + ColorTb.Text + "', '" + BreedTb.Text + "', "+ age +", '" + WeightTb.Text + "', '" + PastureTb.Text +"')"; // It's very important to write the same numbers of fields and values ... // https://es.stackoverflow.com/questions/115201/alguna-forma-de-insertar-registros-cuando-la-tabla-tiene-default-e-identity-en
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow save successfully");

                    Con.Close();
                    populate();
                    Clear();

                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            MessageBox.Show("" + age);
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        // to dsiplay data
        private void populate()
        {
            Con.Open();

            string query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            WeightTb.Text = "";
            AgeTb.Text = "";
            PastureTb.Text = "";
            key = 0;
        }

        // clear button
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // DataGridView
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowsDGV.SelectedRows[0].Cells[4].Value.ToString();

            if(CowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[5].Value.ToString());
            }

            WeightTb.Text = CowsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PastureTb.Text = CowsDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        // delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the cow to be deleted");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "delete from CowTbl where CowId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow deleted successfully");

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
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string Query = "update CowTbl set CowName='"+ CowNameTb.Text +"', EarTag='"+ EarTagTb.Text +"', Color='"+ ColorTb.Text +"', Breed='"+ BreedTb.Text +"', Age='"+ age +"', WeightAtBirth='"+ WeightTb.Text +"', Pasture='"+ PastureTb.Text +"' where CowId="+ key +";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow updated successfully");

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
