using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pos02.Model;

namespace pos02.Viwe
{
    public partial class ProductViwe : SampleViwe1
    {
        public ProductViwe()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "select pID,pName,barcode,pPrice,qty,CategoryID,c.catName from products p inner join category c on c.catID = p.CategoryID where pName like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvBarcode);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvQty);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);
           



            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.ProductAdd());
            /*CategoryAdd frm = new CategoryAdd();
            frm.ShowDialog();*/
            GetData();
        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Update
            {

                ProductAdd frm = new ProductAdd();
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtBarcode.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvBarcode"].Value);
                frm.cbCat.SelectedText = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcat"].Value);
                frm.txtPrice.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value);
                frm.txtQty.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvQty"].Value);
                frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvcatID"].Value);


                string qry = "Delete From products where pID = " + id + " ";
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);
                MainClass.BlurBackground(frm);
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete From products where pID = " + id + " ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }

        private void ProductViwe_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.ProductAdd());

            /*CategoryAdd frm = new CategoryAdd();
            frm.ShowDialog();*/
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
