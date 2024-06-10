using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pos02.Model;
using pos02.Viwe;
using Message = pos02.Model.Message;


namespace pos02
{
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }
        static Cashier _obj;
        public static Cashier Instance
        {
            get { if (_obj == null) { _obj = new Cashier(); } return _obj; }
        }
        private void Cashier_Load(object sender, EventArgs e)
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
        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            lg.Show();
            this.Hide();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblUName_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            lg.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            AddControls(new CategoryViwe());
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            AddControls(new ProductViwe());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddControls(new Saleviwe());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            AddControls(new Message());
        }
    }
}
