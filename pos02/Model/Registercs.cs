using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pos02
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1JFPHN\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtCPassword.Text)
            {
                try
                {
                    con.Open();
                    string qry = "INSERT INTO mem_login (f_name,u_name,gmail,pass_w,position) VALUES ('" + txtName1.Text + "','" + txtUname.Text + "','" + txtGmail.Text + "','" + txtPassword.Text + "', '"+cbRole.Text+"')";
                    SqlDataAdapter sda = new SqlDataAdapter(qry, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    guna2MessageDialog1.Show("Registation Successfully");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in registering" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Password Not Matched");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName1.Clear();
            txtUname.Clear();
            txtGmail.Clear();
            txtPassword.Clear();
            txtCPassword.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        this.Hide();
        }
    }
}
