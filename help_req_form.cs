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

    public partial class help_req_form : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public help_req_form()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( textBox4.Text != "" && textBox5.Text != "" && textBox1.Text != "" && textBox6.Text != "")
            {
                String query = "INSERT INTO complaint_table (user_id, room_no,pc_no,complaint,emp_id) VALUES(@user_id,@room_no,@pc_no,@complaint,NULL)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@user_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@room_no", textBox4.Text);
                cmd.Parameters.AddWithValue("@pc_no", textBox5.Text);
                cmd.Parameters.AddWithValue("@complaint", textBox6.Text);

                connection.Open();
                 int row=cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Successfully Submited", "success", MessageBoxButtons.OK);


                }
                else
                {
                    MessageBox.Show(" Field", "Failed", MessageBoxButtons.OK);

                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("please fill the Field", "Failed", MessageBoxButtons.OK);


            }
       
      
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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
                        using (SqlCommand cmd = new SqlCommand("SELECT user_tbl.user_id, user_tbl.name, complaint_table.complaint, complaint_table.emp_id, complaint_table.status FROM user_tbl INNER JOIN complaint_table ON user_tbl.user_id = complaint_table.user_id WHERE user_tbl.user_id = @user_id", cn))
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
            user_form uf = new user_form();
            uf.Show();
            this.Hide();
        }

        private void help_req_form_Load(object sender, EventArgs e)
        {

        }
    }
}
