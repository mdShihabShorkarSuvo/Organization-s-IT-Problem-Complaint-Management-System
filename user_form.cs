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
    public partial class user_form : Form
    {
        public user_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            help_req_form hr = new help_req_form();
            hr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            user_login ul= new user_login();
            ul.Show();  
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
