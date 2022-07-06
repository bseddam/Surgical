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
            GetOrgans();
            Session["OrganID"] = 0;
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
 
        protected void GetOrgans()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by OrganID) SN,* from Organs");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Organs where OrganID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtOrganAZ.Text = dr["OrganName_AZ"].ToString();
                txtOrganEN.Text = dr["OrganName_EN"].ToString();
                txtOrganRU.Text = dr["OrganName_RU"].ToString();
                txtSortBy.Text = dr["SortBy"].ToString();
                Session["OrganID"] = int.Parse(dr["OrganID"].ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Organs where OrganID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetOrgans();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["OrganID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Organs Values(@OrganName_AZ,@OrganName_EN,@OrganName_RU,@SortBy)", Methods.SqlConn);            
            cmd.Parameters.AddWithValue("OrganName_AZ", txtOrganAZ.Text);
            cmd.Parameters.AddWithValue("OrganName_EN", txtOrganEN.Text);
            cmd.Parameters.AddWithValue("OrganName_RU", txtOrganRU.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetOrgans();
            txtOrganAZ.Text = "";
            txtOrganEN.Text = "";
            txtOrganRU.Text = "";
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["OrganID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Organs set OrganName_AZ=@OrganName_AZ,OrganName_EN=@OrganName_EN,
                          OrganName_RU=@OrganName_RU, SortBy=@SortBy where OrganID=@OrganID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("OrganName_AZ", txtOrganAZ.Text);
            cmd.Parameters.AddWithValue("OrganName_EN", txtOrganEN.Text);
            cmd.Parameters.AddWithValue("OrganName_RU", txtOrganRU.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("OrganID", Session["OrganID"].ToString());
            
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetOrgans();
            txtOrganAZ.Text = "";
            txtOrganEN.Text = "";
            txtOrganRU.Text = "";
            txtSortBy.Text = "";
            Session["OrganID"] = 0;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["OrganID"] = 0;
            txtOrganAZ.Text = "";
            txtOrganEN.Text = "";
            txtOrganRU.Text = "";
            txtSortBy.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
