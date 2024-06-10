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

namespace pos02.Viwe
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GetOrders();
        }
        private void GetOrders()
        {
            string qry1 = "select pID,pName,barcode,pPrice,qty,CategoryID,c.catName from products p inner join category c on c.catID = p.CategoryID ";
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            lblProduct.Text = (dt1.Rows.Count).ToString();


            string tdate = (DateTime.Now.Date).ToString();

            String qry2 = "Select * From sales where aDate = '"+tdate+"'";
            SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            lblBillCount.Text = (dt2.Rows.Count).ToString();

            



            MainClass.con.Open();
            int salesum;
            string salesumm;
            int todaysale = 0;

            string qry3 = "Select * From sales where aDate = '" + tdate + "'";

            SqlCommand cmd3 = new SqlCommand(qry3, MainClass.con);

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(dt3);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                salesumm =  dt3.Rows[i]["total"].ToString();
                salesum = Convert.ToInt32(salesumm);
    
                todaysale =todaysale + salesum;

                lblTotaIncome.Text = (todaysale).ToString();

            }
            MainClass.con.Close();

        }
    }
}
