using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pos02.Model
{
    
    public partial class ucProduct : UserControl
    {
        public event EventHandler onSelect = null;
        public ucProduct()
        {
            InitializeComponent();
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {

        }
        private void txtPic_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        public int id { get; set; }
        public string PCost { get; set; }
        public string PCategory { get; set; }
        public string PName
        {
            get { return lblPName.Text; }
            set { lblPName.Text = value; }
        }

        public string PPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }
        public string PQty
        {
            get { return lblQty.Text; }
            set { lblQty.Text = value; }
        }

        public Image PImage
        {
            get { return txtPic.Image; }
            set { txtPic.Image = value; }
        }

        private void ucProduct_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void txtPic_Click_1(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblPName_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblQty_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
