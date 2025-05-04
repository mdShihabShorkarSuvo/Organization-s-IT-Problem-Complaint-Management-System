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
    public partial class admin_form : Form
    {
        public admin_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complaint_history c = new complaint_history();
            c.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            user_details c = new user_details();
            c.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            emp_details s= new emp_details();
            s.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            complaint_history h= new complaint_history();   
            h.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            admin_login  hp = new  admin_login ();
            hp.Show();
            this.Hide();

        }
    }
}