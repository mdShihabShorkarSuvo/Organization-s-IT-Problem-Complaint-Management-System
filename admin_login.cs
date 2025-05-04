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
    public partial class admin_login : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public admin_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                String query = "select*from admin_table where id=@id  COLLATE SQL_Latin1_General_CP1_CS_AS and password=@password  COLLATE SQL_Latin1_General_CP1_CS_AS";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {


                    label8.Text = "                 Login Successful";
                    label8.Visible = true;
                    admin_form a=new admin_form();
                    a.Show();
                    this.Hide();
                    connection.Close();
                }
                else
                {
                    label8.Text = " The User Name or Password is Incorrect";
                    label8.Visible = true;
                }
                connection.Close();
            }
            else
            {
                label8.Text = "               Please Fill both fields";

                label8.Visible = true;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            home_page h=new home_page();
            h.Show();
            this.Close();

        }
    }
}
