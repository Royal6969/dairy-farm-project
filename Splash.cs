using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_farm_project
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        int startPoint = 0;
        // timer component
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            ProgressBar.Value = startPoint;

            if (ProgressBar.Value == 100)
            {
                ProgressBar.Value = 0;
                timer1.Stop();

                Login log = new Login();
                this.Hide();
                log.Show();
            }
        }
    }
}
