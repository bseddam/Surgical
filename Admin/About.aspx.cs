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
            Session["AboutID"] = 0;
           // lblfooternote.Text = clSsql.getfooternote();
            GetAbout();
        }
    }
 
        protected void GetAbout()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by AboutID) SN,* from About");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from About where AboutID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                Session["AboutID"] = int.Parse(dr["AboutID"].ToString());
                txtKateqoriyaAZ.Text = dr["AboutAZ"].ToString();
                txtKateqoriyaEN.Text = dr["AboutEN"].ToString();
                txtKateqoriyaRU.Text = dr["AboutRU"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from About where AboutID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAbout();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["AboutID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into About Values(@AboutAZ,@AboutEN,@AboutRU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("AboutAZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("AboutEN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("AboutRU", txtKateqoriyaRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAbout();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["AboutID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update About set AboutAZ=@AboutAZ,AboutEN=@AboutEN,
                          AboutRU=@AboutRU where AboutID=@AboutID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("AboutAZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("AboutEN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("AboutRU", txtKateqoriyaRU.Text);
            cmd.Parameters.AddWithValue("AboutID", Session["AboutID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAbout();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["AboutID"] = 0;
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
