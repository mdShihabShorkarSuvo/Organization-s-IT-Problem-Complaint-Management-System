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
    public partial class emp_details : Form
    {
        public emp_details()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from emp_tbl ", con))
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

        private void button2_Click(object sender, EventArgs e)
        {
            admin_form admin = new admin_form();
            admin.Show();
            this.Hide();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["emp_id"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        con.Open();
                        using (SqlCommand childCmd = new SqlCommand("DELETE FROM complaint_table WHERE emp_id = @emp_id", con))
                        {
                            childCmd.Parameters.AddWithValue("@emp_id", textBox2.Text);
                            childCmd.ExecuteNonQuery();
                        }


                        using (SqlCommand parentCmd = new SqlCommand("DELETE FROM emp_tbl WHERE emp_id = @emp_id", con))
                        {
                            parentCmd.Parameters.AddWithValue("@emp_id", textBox2.Text);
                            parentCmd.ExecuteNonQuery(); MessageBox.Show("Deletion successful!");
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Deletion failed. Error: " + ex.Message);
                }
            }
            else MessageBox.Show("Please Select a row first. Error: ");
        }

        private void emp_details_Load(object sender, EventArgs e)
        {

        }
    }
}
