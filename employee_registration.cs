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

namespace Organizations_IT_Problem_complain_management
{
    public partial class employee_registration : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public employee_registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                String query = "INSERT INTO emp_tbl VALUES(@emp_name,@emp_email,@emp_address,@user_name,@password)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@emp_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@emp_email", textBox2.Text);
                cmd.Parameters.AddWithValue("@emp_address", textBox3.Text);
                cmd.Parameters.AddWithValue("@user_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@password", textBox5.Text);
                connection.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {

                    label12.Text = "    Registration Successful";
                    label12.Visible = true;
                }
                else
                {
                    label12.Text = "Please Cheak your connection";
                    label12.Visible = true;
                }
                connection.Close();
            }
            else
            {
                label12.Text = "Please Field The Requirment";
                label12.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee_login l= new employee_login();
            l.Show();
            this.Close();

        }
    }
}
