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

namespace pos02.Viwe
{
    public partial class StaffViwe : SampleViwe1
    {
        public StaffViwe()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From mem_login where staffID like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvMail);
            lb.Items.Add(dgvUName);
            lb.Items.Add(dgvPass);
            lb.Items.Add(dgvRole);



            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.Register());

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



                Register frm = new Register();
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName1.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtGmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvUName"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
                frm.txtPassword.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPass"].Value);
                frm.txtUname.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMail"].Value);


                string qry = "Delete From mem_login where staffID = " + id + " ";
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
                    string qry = "Delete From mem_login where staffID = " + id + " ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }

        private void StaffViwe_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Register());

            /*CategoryAdd frm = new CategoryAdd();
            frm.ShowDialog();*/
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Update
            {



                Register frm = new Register();
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName1.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtGmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvMail"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);

                string qry = "Delete From mem_login where staffID = " + id + " ";
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
                    string qry = "Delete From mem_login where staffID = " + id + " ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }
    }
}
