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
using pos02.Viwe;
using pos02.Model;
using Message = pos02.Model.Message;

namespace pos02
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1JFPHN\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
        static frmMain _obj;
        public static frmMain Instance
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; }
        }

        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }      
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Register regfrm = new Register();
            regfrm.Show();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new CategoryViwe());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*con.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblUName.Text = dr[1].ToString();
            con.Close();*/
            lblUName.Text = UserLogName.userName;
            _obj = this;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            lg.Show();
            this.Hide();
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AddControls(new StaffViwe());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new ProductViwe());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddControls(new Saleviwe());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddControls(new Kitchenviwe());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            AddControls(new Message());
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            AddControls(new Dashboard());
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            AddControls(new Purchase());
        }
    }
}
