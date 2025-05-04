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
    public partial class complaint_history : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-L06E3MPH\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public complaint_history()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
           

        private void button3_Click(object sender, EventArgs e)
        {
            assign_emp k= new assign_emp();
            k.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void complaint_history_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_form a= new admin_form();
            a.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-L06E3MPH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT ct.Complaint_id, ut.user_id, ut.name, ct.complaint, ct.emp_id, ct.status FROM complaint_table ct INNER JOIN user_tbl ut ON ct.user_id = ut.user_id ", con))
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

    }
}

