using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;




    public partial class Category : System.Web.UI.Page
    {
    Methods clSsql = new Methods();
        protected void Page_Load(object sender, EventArgs e)
        {
        if (Session["UsersID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            Session["ContactID"] = 0;
            lblfooternote.Text = clSsql.getfooternote();
            GetContact();
        }
    }
 
        protected void GetContact()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by ContactID) SN,* from Contact");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Contact where ContactID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                Session["ContactID"] = int.Parse(dr["ContactID"].ToString());
                txtKateqoriyaAZ.Text = dr["ContactAZ"].ToString();
                txtKateqoriyaEN.Text = dr["ContactEN"].ToString();
                txtKateqoriyaRU.Text = dr["ContactRU"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Contact where ContactID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetContact();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["ContactID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Contact Values(@ContactAZ,@ContactEN,@ContactRU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("ContactAZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("ContactEN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("ContactRU", txtKateqoriyaRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetContact();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["ContactID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Contact set ContactAZ=@ContactAZ,ContactEN=@ContactEN,
                          ContactRU=@ContactRU where ContactID=@ContactID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("ContactAZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("ContactEN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("ContactRU", txtKateqoriyaRU.Text);
            cmd.Parameters.AddWithValue("ContactID", Session["ContactID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetContact();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["ContactID"] = 0;
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
