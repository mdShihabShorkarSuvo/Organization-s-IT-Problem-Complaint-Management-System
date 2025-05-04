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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Organizations_IT_Problem_complain_management
{
    public partial class user_details : Form
    {
        public user_details()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_form admin_Form = new admin_form();
            admin_Form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from user_tbl ", con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand childCmd = new SqlCommand("DELETE FROM complaint_table WHERE user_id = @user_id", con))
                    {
                        childCmd.Parameters.AddWithValue("@user_id", textBox4.Text);
                        childCmd.ExecuteNonQuery();
                    }

                    
                    using (SqlCommand parentCmd = new SqlCommand("DELETE FROM user_tbl WHERE user_id = @user_id", con))
                    {
                        parentCmd.Parameters.AddWithValue("@user_id", textBox4.Text);
                        parentCmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Deletion successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deletion failed. Error: " + ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["user_id"].Value.ToString();
            }
        }
    }
}
