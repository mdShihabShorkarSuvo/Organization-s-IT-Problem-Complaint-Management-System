using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizations_IT_Problem_complain_management
{
    public partial class home_page : Form
    {
        public home_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user_login ul= new user_login();
            ul.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin_login al= new admin_login();
            al.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee_login l=new employee_login();
            l.Show();
            this.Hide();    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            about_form a= new about_form(); 
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
