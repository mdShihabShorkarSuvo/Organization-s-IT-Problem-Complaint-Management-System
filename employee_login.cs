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
    public partial class employee_login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public employee_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                String query = "select*from emp_tbl where emp_id=@emp_id COLLATE SQL_Latin1_General_CP1_CS_AS  and password=@password COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    conn.Close();
                    label8.Text = "                 Login Successful";
                    label8.Visible = true;
                    employee_form uf = new employee_form();
                    uf.Show();
                    this.Hide();


                }
                else


                {
                    label8.Text = " The Emp ID or Password is Incorrect";
                    label8.Visible = true;
                }
                conn.Close();



            }
            else
            {

                label8.Text = "               Please Fill both fields";

                label8.Visible = true;



            }
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee_registration r= new employee_registration();
            r.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            home_page hp = new home_page();
            hp.Show();
            this.Hide();

        }
    }
}
