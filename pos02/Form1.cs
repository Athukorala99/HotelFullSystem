using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace pos02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1JFPHN\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM mem_login WHERE u_name = '" + txtUser.Text + "' AND pass_w = '" + txtPass.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                
                if (ds.Tables[0].Rows.Count == 1)
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[5].ToString() == "Admin")
                    {

                        UserLogName.userName = dr[1].ToString();
                        frmMain fmain = new frmMain();
                        fmain.Show();
                        this.Hide();


                        DateTime datetime = DateTime.Now;
                        string to, from, pass, mail;
                        to = "athukoralaharith@gmail.com";
                        from = "himanthaathukorala@gmail.com";
                        pass = "ivoifqgtxfboqszf";
                        mail = datetime + "\n" + txtUser.Text + " has Logedin now";
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


                    else if (dr[5].ToString() == "Manager")
                    {
                        UserLogName.userName = dr[1].ToString();
                        Manager md = new Manager();
                        md.Show();
                        this.Hide();

                        DateTime datetime = DateTime.Now;
                        string to, from, pass, mail;
                        to = "athukoralaharith@gmail.com";
                        from = "himanthaathukorala@gmail.com";
                        pass = "ivoifqgtxfboqszf";
                        mail = datetime + "\n" + txtUser.Text + " has Logedin now";
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


                    else if (dr[5].ToString() == "Store")
                    {
                        UserLogName.userName = dr[1].ToString();
                        Kitchen kd = new Kitchen();
                        kd.Show();
                        this.Hide();

                        DateTime datetime = DateTime.Now;
                        string to, from, pass, mail;
                        to = "athukoralaharith@gmail.com";
                        from = "himanthaathukorala@gmail.com";
                        pass = "ivoifqgtxfboqszf";
                        mail = datetime + "\n" + txtUser.Text + " has Logedin now";
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

                    
                    else if (dr[5].ToString() == "Cashier ")
                    {
                        UserLogName.userName = dr[1].ToString();
                        Cashier cd = new Cashier();
                        cd.Show();
                        this.Hide();

                        DateTime datetime = DateTime.Now;
                        string to, from, pass, mail;
                        to = "athukoralaharith@gmail.com";
                        from = "himanthaathukorala@gmail.com";
                        pass = "ivoifqgtxfboqszf";
                        mail = datetime + "\n" + txtUser.Text + " has Logedin now";
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

                else
                {
                    guna2MessageDialog1.Show("Invalid Username or Password");
                    return;

                }
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Error in ligin process" + ex);
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBox1.Checked == false)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
    }
}
