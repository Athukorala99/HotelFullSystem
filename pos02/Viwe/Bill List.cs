using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pos02.Reports;

namespace pos02.Viwe
{
    public partial class Bill_List : Form
    {
        public Bill_List()
        {
            InitializeComponent();
        }
        public int MainID = 0;

        private void Bill_List_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string qry = "Select saleID,aTime,aDate,total From sales where status = 'Pending' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvReNumber);
            lb.Items.Add(dgvTime);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvTotal);
            


            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvprint")//Update
            {
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvReNumber"].Value);
                string qry2 = "select * from sDetails d inner join sales s on s.saleID = d.saleID inner join products p on p.pID = d.pID where d.saleID = " + MainID + "";


                SqlCommand cmd = new SqlCommand(qry2, MainClass.con);
                MainClass.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                MainClass.con.Close();


                BillPrint bp = new BillPrint();
                Billreport cr = new Billreport();

                cr.SetDatabaseLogon("","");
                cr.SetDataSource(dt);
                bp.crystalReportViewer1.ReportSource = cr;
                bp.crystalReportViewer1.Refresh();
                bp.Show();

            }
        }
    }
}
