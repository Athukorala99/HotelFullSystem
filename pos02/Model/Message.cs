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

namespace pos02.Model
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            DateTime datetime = DateTime.Now;
            string to, from, pass, mail;
            to = "athukoralaharith@gmail.com";
            from = "himanthaathukorala@gmail.com";
            pass = "ivoifqgtxfboqszf";
            mail =txtMessage.Text;
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
            txtMessage.Text = "";
        }
    }
}
