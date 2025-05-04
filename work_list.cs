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
    public partial class work_list : Form
    {
        public work_list()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))

                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    using (DataTable dt = new DataTable("complaint_table"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT complaint_table.complaint_id,user_tbl.user_id, user_tbl.name, complaint_table.complaint, complaint_table.emp_id, complaint_table.status FROM user_tbl INNER JOIN complaint_table ON user_tbl.user_id = complaint_table.user_id WHERE complaint_table.emp_id = @user_id", cn))
                        {
                            cmd.Parameters.AddWithValue("@user_id", textBox1.Text);
                            SqlDataAdapter ad = new SqlDataAdapter(cmd);
                            ad.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            }
                            else
                            {
                                MessageBox.Show("No complaints found for the entered ID.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee_form k= new employee_form();
            k.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "UPDATE complaint_table SET status = @status WHERE complaint_id = @complaint_id AND emp_id = @emp_id";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@status", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@complaint_id", textBox2.Text);
                    cmd.Parameters.AddWithValue("@emp_id", textBox1.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["complaint_id"].Value.ToString();
            }
        }
    }
}
