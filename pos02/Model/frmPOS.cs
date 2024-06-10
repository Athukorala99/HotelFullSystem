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
using pos02.Viwe;
using System.Net.Mail;
using System.Net;
using System.Web;


namespace pos02.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int cID = 0;
        public int SaleID = 0;
        

        private void frmPOS_Load(object sender, EventArgs e)
        {
            string qry = "Select catID 'id' , catName name from category";

            MainClass.CBFill(qry, cbCat);

            

            if (cID > 0)
            {
                cbCat.SelectedValue = cID;
            }

           
            loadProductsFromDatabase();
        }
        public void AddItems(string id,String proid, string name,string qty, string cat, string price,Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PQty = qty,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(proid),
                
            };
            flowLayoutPanel1.Controls.Add(w);


            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                MessageBox.Show("Add");

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvproid"].Value) == wdg.id)
                    {
                        item.Cells["dgvqty"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) * int.Parse(item.Cells["dgvPrice"].Value.ToString());

                        GrandTotal();
                        return;
                    } 
                }
                guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GrandTotal();

            };
        }
        private void GrandTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach(DataGridViewRow item in guna2DataGridView1.Rows)
            {

                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());

            }

            lblTotal.Text = tot.ToString("N2");

        }
        private void loadProductsFromDatabase()
        {
            string qry = @"Select * From products inner join category on catID = CategoryID ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Byte[] imageArray = (byte[])row["pImage"];
                    byte[] imageByteArray = imageArray;

                    //AddItems(row["pID"].ToString(), row["pName"].ToString(), row["pPrice"].ToString(), Image.FromStream(new MemoryStream(imageArray)), row["pPrice"].ToString());
                    AddItems("0",row["pID"].ToString(), row["pName"].ToString(),row["qty"].ToString(), row["catName"].ToString(),row["pPrice"].ToString(),Image.FromStream(new MemoryStream(imageArray)));
                }

            }
        }

        private void ucProduct1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                
                
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    int rowindex = guna2DataGridView1.CurrentCell.RowIndex;
                    guna2DataGridView1.Rows.RemoveAt(rowindex);
                    //int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    //string qry = "Delete From category where catID = " + id + " ";
                    //Hashtable ht = new Hashtable();
                    //MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    //GetData();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            txtDate.Value = DateTime.Now;
            lblTotal.Text = "0.00";
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qry = "Select * from products where barcode like '"+txtBarcode.Text+"'";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        
                        if (Convert.ToInt32(item.Cells["dgvproid"].Value) == int.Parse(row["pID"].ToString()))
                        {
                            item.Cells["dgvqty"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) + 1;
                            item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) * int.Parse(item.Cells["dgvPrice"].Value.ToString());

                            GrandTotal();
                            txtBarcode.Text = "";
                            return;
                        }
                    }

                    guna2DataGridView1.Rows.Add(new object[] { 0, row["pID"].ToString(), row["pName"].ToString(), 1, row["pPrice"].ToString(), row["pPrice"].ToString() });
                    GrandTotal();
                    txtBarcode.Text = "";
                }


                
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qry = "Select * from products where pName like '" + txtName.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {

                        if (Convert.ToInt32(item.Cells["dgvproid"].Value) == int.Parse(row["pID"].ToString()))
                        {
                            item.Cells["dgvqty"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) + 1;
                            item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvqty"].Value.ToString()) * int.Parse(item.Cells["dgvPrice"].Value.ToString());

                            GrandTotal();
                            txtName.Text = "";
                            return;
                        }
                    }

                    guna2DataGridView1.Rows.Add(new object[] { 0, row["pID"].ToString(), row["pName"].ToString(), 1, row["pPrice"].ToString(), row["pPrice"].ToString() });
                    GrandTotal();
                    txtName.Text = "";
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            /*string qry1 = "";//Sale
            string qry2 = "";//SDetails

            int detailID = 0;
            
            if (SaleID == 0)//Insert
            {
                qry1 = @"Insert into Sale Values(@aDate  , @aTime , @status , @total , @received , @change); Select SCOPE_IDENTITY()";
            }
            else // Update
            {
                qry1 = @"Update sale set (status =@status ,total = @total , received = @received , change = @change where SaleID = @ID )";
            }

            Hashtable ht = new Hashtable();

           /* string qry3 = "SELECT * FROM Sale";
            SqlCommand cmd3 = new SqlCommand(qry3, MainClass.con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);*//*
            



            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            string x = cmd.Parameters.AddWithValue("@ID", SaleID).ToString();
            cmd.Parameters.AddWithValue("@aDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue(@"aTime", DateTime.Now.ToLongTimeString());
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            int y = SaleID;
            
            if(MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (SaleID == 0) {SaleID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

           // SqlDataReader dr3 = cmd3.ExecuteReader();
           // dr3.Read();
            //string x = dr3[0].ToString();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if(detailID == 0)
                {
                    qry2 = @"Insert into SDetails values ( @SaleID , @pID , @qty , @price , @amount )";
                }
                else
                {
                    qry2 = @"Update into SDetails Set (SaleID = @SaleID , proid = @pID , qty = @qty , price = @price , amount = @amount where SDetailID = @ID)";
                }

                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@SaleID",y );
                cmd2.Parameters.AddWithValue("@pID",Convert.ToInt32( row.Cells["dgvproid"].Value));
                cmd2.Parameters.AddWithValue("@qty",Convert.ToInt32( row.Cells["dgvqty"].Value));
                cmd2.Parameters.AddWithValue("@price",  Convert.ToInt32(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToInt32(row.Cells["dgvAmount"].Value));

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery(); 
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                guna2MessageDialog1.Show("Saved Successfully");
                SaleID = 0;
                detailID = 0;
                guna2DataGridView1.Rows.Clear();
                lblTotal.Text = "0.00";

            }*/

            string qry1 = "";
            string qry2 = "";

            int detailID = 0;
            
                if (SaleID == 0)
            {
                qry1 = "Insert into sales Values (@aDate , @aTime , @satus , @total , @received , @change); Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = "Update sales Set aDate = @aDate , aTime = @aTime , status = @status , total = @total , received = @received , change = @change where saleID = @sID";
            }
            Hashtable ht1 = new Hashtable();
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            ht1.Add("@sID", SaleID);
            cmd1.Parameters.AddWithValue("@aDate", DateTime.Now.Date);
            cmd1.Parameters.AddWithValue("@aTime", DateTime.Now.ToLongTimeString());
            cmd1.Parameters.AddWithValue("@satus", "Pending");
            cmd1.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
            cmd1.Parameters.AddWithValue("@received", Convert.ToInt32(0));
            cmd1.Parameters.AddWithValue("@change", Convert.ToInt32(0));


            

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (SaleID == 0) { SaleID = Convert.ToInt32(cmd1.ExecuteScalar()); } else { cmd1.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)    
             {
                for (int item = 0; item <= guna2DataGridView1.Rows.Count - 1; item++)
                {
                    //detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                    if (detailID == 0)
                        {
                            qry2 = @"Insert into SDetails values ( @SaleID , @pID , @qty , @price , @amount )";
                        }
                        else
                        {
                            qry2 = @"Update into SDetails Set (SaleID = @SaleID , proid = @pID , qty = @qty , price = @price , amount = @amount where SDetailID = @ID)";
                        }

                        SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                        cmd2.Parameters.AddWithValue("@ID", guna2DataGridView1.Rows[item].Cells["dgvid"].Value);
                        cmd2.Parameters.AddWithValue("@SaleID", SaleID);
                        cmd2.Parameters.AddWithValue("@pID", guna2DataGridView1.Rows[item].Cells["dgvproid"].Value);
                        cmd2.Parameters.AddWithValue("@qty", guna2DataGridView1.Rows[item].Cells["dgvqty"].Value);
                        cmd2.Parameters.AddWithValue("@price", guna2DataGridView1.Rows[item].Cells["dgvPrice"].Value);
                        cmd2.Parameters.AddWithValue("@amount", guna2DataGridView1.Rows[item].Cells["dgvAmount"].Value);

                        string prName = (guna2DataGridView1.Rows[item].Cells["dgvProduct"].Value).ToString();
                    

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        cmd2.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        MainClass.con.Open();
                        int qtyo,qtyn ;
                        string  productiid;
                        

                        int prid = Convert.ToInt32(guna2DataGridView1.Rows[item].Cells["dgvproid"].Value);
                        int qty1 = Convert.ToInt32(guna2DataGridView1.Rows[item].Cells["dgvqty"].Value);

                        string qry4 =@"Select pID,qty from products where pID = @prodid";

                        SqlCommand cmd3 = new SqlCommand(qry4, MainClass.con);
                        cmd3.Parameters.AddWithValue("@prodid",prid);
                        SqlDataReader read1 = cmd3.ExecuteReader();
                        read1.Read();
                        
                            productiid = read1["qty"].ToString();
                        
                    qtyo = Convert.ToInt32(productiid);
                            qtyn = qtyo - qty1;
                           
                        
                        MainClass.con.Close();
                        //MessageBox.Show("Qty " + qty1 + " PID " + prid + " all " + qtyo + " Now " + qtyn);


                        string qry6 = "Update products set qty = '" + qtyn + "' where pID = @prodiid";
                        Hashtable ht6 = new Hashtable();
                        ht6.Add("@prodiid", prid);
                        if (MainClass.SQl(qry6, ht6) > 0)
                        {
                            //guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            //guna2MessageDialog1.Show("Save Successfull");
                        }

                        if (qtyn < 10)
                        {
                            DateTime datetime = DateTime.Now;
                            string to, from, pass, mail;
                            to = "athukoralaharith@gmail.com";
                            from = "himanthaathukorala@gmail.com";
                            pass = "ivoifqgtxfboqszf";
                            mail = datetime + "\n" +prName + " are lack of stock" + "\n" + " Please refill ";
                            MailMessage msg = new MailMessage();
                            msg.To.Add(to);
                            msg.From = new MailAddress(from);
                            msg.Body = mail;
                            msg.Subject = "Hotel Management System";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential(from, pass);

                            try
                            {
                                smtp.Send(msg);

                            }
                            catch (Exception ex)
                            {
                                guna2MessageDialog1.Show(ex.Message);
                            }
                        }

                }
                guna2MessageDialog1.Show("Saved Successfully");
                SaleID = 0;
                detailID = 0;
                guna2DataGridView1.Rows.Clear();
                lblTotal.Text = "0.00";
                loadProductsFromDatabase();
                flowLayoutPanel1.Controls.Clear();






                string qry5 = @"Select * From products inner join category on catID = CategoryID ";
                SqlCommand cmd5 = new SqlCommand(qry5, MainClass.con);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);

                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow rowb in dt5.Rows)
                    {
                        Byte[] imageArray = (byte[])rowb["pImage"];
                        byte[] imageByteArray = imageArray;

                        //AddItems(row["pID"].ToString(), row["pName"].ToString(), row["pPrice"].ToString(), Image.FromStream(new MemoryStream(imageArray)), row["pPrice"].ToString());
                        AddItems("0", rowb["pID"].ToString(), rowb["pName"].ToString(), rowb["qty"].ToString(), rowb["catName"].ToString(), rowb["pPrice"].ToString(), Image.FromStream(new MemoryStream(imageArray)));
                    }

                }

            }

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Bill_List());

            /*CategoryAdd frm = new CategoryAdd();
            frm.ShowDialog();*/
            
        }
    }   
}

