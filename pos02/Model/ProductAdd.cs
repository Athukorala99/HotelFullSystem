using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos02.Model
{
    public partial class ProductAdd : SampleAdd
    {
        public ProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;


        private void ProductAdd_Load(object sender, EventArgs e)
        {
            string qry = "Select catID 'id' , catName name from category";

            MainClass.CBFill(qry, cbCat);

            if (cID > 0)
            {
                cbCat.SelectedValue = cID;
            }

            if (id >0)
            {

            }
        }
        string filepath ;
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtImage.Image = new Bitmap(filepath);
            }
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)//Insert
            {
               // qry = "INSERT INTO products (pName,pPrice,CategoryID,pImage) Values ('" + txtName.Text + "' , '"+ txtPrice.Text +"' , '"+ cbCat.Text +"' , '"+ txtImage.Image +"')";
                qry = "INSERT INTO products  Values (@Name , @barc , @price , @Qty , @cat , @img)";

            }
            else//Update
            {
                qry = "Update products Set (pName = @Name , barcode = @barc, pPrice = @Price , qty = @Qty , CategoryID = @cat , pImage = @img where pID = @id)";
            }

            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();


            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@barc", txtBarcode.Text);
            ht.Add("@price", txtPrice.Text);
            ht.Add("@Qty", txtQty.Text);
            ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img", imageByteArray);



            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved Successfully...");
                id = 0;
                cID = 0;
                txtName.Text = "";
                txtBarcode.Text = "";
                txtPrice.Text = "";
                txtQty.Text = "";
                cbCat.SelectedIndex = 0;
                cbCat.SelectedIndex = -1;
                txtImage.Image = pos02.Properties.Resources._1684687418700;
                txtName.Focus();
            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Select * products where pID = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageAray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageArray = imageAray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageAray));

            }
        }

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
