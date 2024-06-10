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
using System.Data.SqlClient;

namespace pos02.Model
{
    public partial class CategoryAdd : SampleAdd
    {
        public CategoryAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if(id == 0)//Insert
            {
                qry = "INSERT INTO category (catName) Values('" + txtName.Text + "')";
            }
            else//Update
            {
                qry = "Update category Set catName = (@Name where catID = @id)";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);

           if (MainClass.SQl(qry , ht) > 0)
            {
                guna2MessageDialog1.Show("Saved Successfully...");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }
        }
        private void CategoryAdd_Load(object sender, EventArgs e)
        {
            
        }
    }
}
