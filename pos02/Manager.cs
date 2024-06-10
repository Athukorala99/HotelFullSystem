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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }
        static Manager _obj;
        public static Manager Instance
        {
            get { if (_obj == null) { _obj = new Manager(); } return _obj; }
        }
        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            lblUName.Text = UserLogName.userName;
            _obj = this;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            lg.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            lg.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new CategoryViwe());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new ProductViwe());
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            AddControls(new StaffViwe());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            AddControls(new Message());
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            AddControls(new Purchase());
        }
    }
}
