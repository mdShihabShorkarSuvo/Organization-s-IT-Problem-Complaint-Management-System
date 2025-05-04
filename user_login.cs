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
    public partial class user_login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public user_login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user_registration ur =new user_registration();
            ur.Show();    
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home_page hp = new home_page();
            hp.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                String query = "select*from user_tbl where user_id=@user_id COLLATE SQL_Latin1_General_CP1_CS_AS  and user_password=@user_password COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@user_password", textBox2.Text);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    conn.Close();
                    label8.Text = "Login Successful";
                    label8.Visible = true;
                    user_form uf= new user_form();
                    uf.Show();
                    this.Hide();


                }
                else


                {
                    label8.Text = " The User ID or Password is Incorrect";
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

        private void user_login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
