using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos02.Model
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string qry1 = "select pID,pName,barcode,pPrice,qty,CategoryID,c.catName from products p inner join category c on c.catID = p.CategoryID where barcode like '%" + txtBarcode.Text + "%' ";
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);


            try
            {
                lblPName.Text = dt1.Rows[0]["pName"].ToString();
                lblQty.Text = dt1.Rows[0]["qty"].ToString();
                lblPrice.Text ="Rs: "+ dt1.Rows[0]["pPrice"].ToString();
                lblCatName.Text = dt1.Rows[0]["catName"].ToString();

            }
            catch (Exception)
            {
                guna2MessageDialog1.Show("There is no such thing");
            }
           
        }

        private void lblPName_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string barc = txtBarcode.Text;
            int oldqty, newqty, addqty;
            oldqty = Convert.ToInt32(lblQty.Text);
            addqty = Convert.ToInt32(txtAddQty.Text);
            newqty = oldqty + addqty;

            string qry2 = "Update products set qty = '"+newqty+"' where barcode =@bcode";
            //string qry3 = "select pID,pName,barcode,pPrice,qty,CategoryID,c.catName from products p inner join category c on c.catID = p.CategoryID where barcode =@bcode";
            Hashtable ht2 = new Hashtable();
            ht2.Add("@bcode", barc);

            if (MainClass.SQl(qry2, ht2) > 0)
            {
                //guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                //guna2MessageDialog1.Show("Save Successfull");
            }

            string qry3 = "select pID,pName,barcode,pPrice,qty,CategoryID,c.catName from products p inner join category c on c.catID = p.CategoryID where barcode like '%" + txtBarcode.Text + "%' ";
            SqlCommand cmd3 = new SqlCommand(qry3, MainClass.con);
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);


            try
            {
                lblPName.Text = dt3.Rows[0]["pName"].ToString();
                lblQty.Text = dt3.Rows[0]["qty"].ToString();
                lblPrice.Text = "Rs: " + dt3.Rows[0]["pPrice"].ToString();
                lblCatName.Text = dt3.Rows[0]["catName"].ToString();

            }
            catch (Exception)
            {
                guna2MessageDialog1.Show("There is no such thing");
            }
            txtAddQty.Text = "";

        }

        private void Purchase_Load(object sender, EventArgs e)
        {

        }
    }
}
