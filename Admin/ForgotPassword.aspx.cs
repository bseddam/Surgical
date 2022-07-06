using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;



    public partial class ForgotPassword : System.Web.UI.Page
    {
        ClSsql clSsql = new ClSsql();        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetTeshkilat();
            }
        }
        protected void GetTeshkilat()
        {
            DDlTeshkilat.DataValueField = "ID";
            DDlTeshkilat.DataTextField = "Adi";
            DDlTeshkilat.DataSource = clSsql.getDT("Select * from TbTeshkilat");
            DDlTeshkilat.DataBind();
            DDlTeshkilat.Items.Insert(0, new ListItem("Seçin", "0"));
        }
        protected void btnLogIn_ServerClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from UsersTB where Login_name=@p1 and ElmiMuessiseID=@p2", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("p1",EmailText.Text);
            cmd.Parameters.AddWithValue("p2", DDLElmiMuessise.SelectedValue.ToString());
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            clSsql.sqlconn.Open();
            DataTable dt = new DataTable();
            dap.Fill(dt);
            clSsql.sqlconn.Close();
            if (dt.Rows.Count > 0)
            {
                var fromAddress = new MailAddress("elmikadramea@gmail.com");
                var fromPassword = "Ra1490qif+";
                var toAddress = new MailAddress(dt.Rows[0][1].ToString());

                Random rnd = new Random();
                int randomint = rnd.Next();

                string subject = "Yeni şifrənin təyin edilməsi";

                string body = "Yeni şifrənin təyin etmək üçün linkə daxil olun. http://elmikadr.science.az/RegstrUserUpdate.aspx?passwordchange=" + dt.Rows[0][0].ToString() + "&confirmvar=" + EmailText.Text + "&kod=" + randomint.ToString();
                //SqlCommand cmd1 = new SqlCommand();


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })

                    smtp.Send(message);

                ClSsql.MsgBox("Şifrənizin bərpası üçün email ünvanınıza məlumat göndərildi.", Page);
            }
            else
            {
                ClSsql.MsgBox("Bu email sistemdə tapılmadı.", Page);
            }
            
            //else
            //{
            //    lblMSG.ForeColor = System.Drawing.Color.Red;
            //    lblMSG.Text = "Məlumatlar düzgün qeyd edilməyib.";
            //}
        }
        protected void DDlTeshkilat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLALTTeshkilat.DataValueField = "ID";
            DDLALTTeshkilat.DataTextField = "Adi";
            DDLALTTeshkilat.DataSource = clSsql.getDT("Select * from TbAltTeshkilat where TeshkilatID=" + DDlTeshkilat.SelectedValue.ToString());
            DDLALTTeshkilat.DataBind();
            DDLALTTeshkilat.Items.Insert(0, new ListItem("Seçin", "0"));
        }

        protected void DDLALTTeshkilat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLElmiMuessise.DataValueField = "ID";
            DDLElmiMuessise.DataTextField = "Adi";
            DDLElmiMuessise.DataSource = clSsql.getDT("Select * from TbElmiMuessise where AltTeshkilatID=" + DDLALTTeshkilat.SelectedValue.ToString());
            DDLElmiMuessise.DataBind();
            DDLElmiMuessise.Items.Insert(0, new ListItem("Seçin", "0"));
        }
    }
