using System;
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
    public partial class Saleviwe : SampleViwe1
    {
        public Saleviwe()
        {
            InitializeComponent();
        }

        private void Saleviwe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.frmPOS());
            LoadData();
        }
        private void LoadData()
        {
            string tdate = (DateTime.Now.Date).ToString();
            string qry = "Select saleID,aTime,aDate,total,status From sales  where saleID like '%" + txtSearch.Text + "%'     ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvReNumber);
            lb.Items.Add(dgvTime);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvTotal);
            lb.Items.Add(dgvStatus);




            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
