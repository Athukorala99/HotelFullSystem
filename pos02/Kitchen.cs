using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pos02.Viwe;
using pos02.Model;
using Message = pos02.Model.Message;


namespace pos02
{
    public partial class Kitchen : Form
    {
        public Kitchen()
        {
            InitializeComponent();
        }
        static Kitchen _obj;
        public static Kitchen Instance
        {
            get { if (_obj == null) { _obj = new Kitchen(); } return _obj; }
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

        private void Kitchen_Load(object sender, EventArgs e)
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

        private void guna2Button4_Click_1(object sender, EventArgs e)
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddControls(new Kitchenviwe());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            AddControls(new Message());

        }
    }
}
