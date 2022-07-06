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
            GetHeaders();
            Session["HeaderID"] = 0;
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
 
        protected void GetHeaders()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by HeaderID) SN,* from Headers");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Deyish")
            {
                DataRow dr = clSsql.getDT(@"Select * from Headers where HeaderID=" + e.CommandArgument.ToString()).Rows[0];
                if (dr != null)
                {
                    txtHeaderAZ.Text = dr["HeaderName_AZ"].ToString();
                    txtHeaderEN.Text = dr["HeaderName_EN"].ToString();
                    txtHeaderRU.Text = dr["HeaderName_RU"].ToString();
                    txtURL.Text = dr["LnkURL"].ToString();
                    txtSortBy.Text = dr["SortBy"].ToString();

                  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
                }
            }
            else if (e.CommandName == "Sil")
            {
                SqlCommand cmd = new SqlCommand("Delete from Headers where HeaderID=" + e.CommandArgument.ToString(), Methods.SqlConn);
                Methods.SqlConn.Open();
                cmd.ExecuteNonQuery();
                Methods.SqlConn.Close();
                GetHeaders();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["HeaderID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Headers Values(@HeaderName_AZ,@HeaderName_EN,@HeaderName_RU
                   ,@LnkURL,@SortBy)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("HeaderName_AZ", txtHeaderAZ.Text);
            cmd.Parameters.AddWithValue("HeaderName_EN", txtHeaderEN.Text);
            cmd.Parameters.AddWithValue("HeaderName_RU", txtHeaderRU.Text);
            cmd.Parameters.AddWithValue("LnkURL", txtURL.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetHeaders();
            txtHeaderAZ.Text = "";
            txtHeaderEN.Text = "";
            txtHeaderRU.Text = "";
            txtURL.Text = "";
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["HeaderID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Headers set HeaderName_AZ=@HeaderName_AZ,HeaderName_EN=@HeaderName_EN,
                          HeaderName_RU=@HeaderName_RU,LnkURL=@LnkURL,SortBy=@SortBy where HeaderID=@HeaderID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("HeaderName_AZ", txtHeaderAZ.Text);
            cmd.Parameters.AddWithValue("HeaderName_EN", txtHeaderEN.Text);
            cmd.Parameters.AddWithValue("HeaderName_RU", txtHeaderRU.Text);
            cmd.Parameters.AddWithValue("LnkURL", txtURL.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("HeaderID", Session["HeaderID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetHeaders();
            txtHeaderAZ.Text = "";
            txtHeaderEN.Text = "";
            txtHeaderRU.Text = "";
            txtURL.Text = "";
            txtSortBy.Text = "";
            Session["HeaderID"] = 0;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["HeaderID"] = 0;
            txtHeaderAZ.Text = "";
            txtHeaderEN.Text = "";
            txtHeaderRU.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
