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
            Session["Catagory"] = 0;
            lblfooternote.Text = clSsql.getfooternote();
            GetCategory();
        }
    }
 
        protected void GetCategory()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by CategoryID) SN,* from Category");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Category where CategoryID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                Session["Catagory"] = int.Parse(dr["CategoryID"].ToString());
                txtKateqoriyaAZ.Text = dr["CategoryName_AZ"].ToString();
                txtKateqoriyaEN.Text = dr["CategoryName_EN"].ToString();
                txtKateqoriyaRU.Text = dr["CategoryName_RU"].ToString();
                txtSortBy.Text = dr["SortBy"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Category where CategoryID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetCategory();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["Catagory"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Category Values(@CategoryName_AZ,@CategoryName_EN,@CategoryName_RU ,@SortBy)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("CategoryName_AZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("CategoryName_EN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("CategoryName_RU", txtKateqoriyaRU.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetCategory();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["Catagory"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Category set CategoryName_AZ=@CategoryName_AZ,CategoryName_EN=@CategoryName_EN,
                          CategoryName_RU=@CategoryName_RU,SortBy=@SortBy where CategoryID=@CategoryID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("CategoryName_AZ", txtKateqoriyaAZ.Text);
            cmd.Parameters.AddWithValue("CategoryName_EN", txtKateqoriyaEN.Text);
            cmd.Parameters.AddWithValue("CategoryName_RU", txtKateqoriyaRU.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("CategoryID", Session["Catagory"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetCategory();
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["CategoryID"] = 0;
            txtKateqoriyaAZ.Text = "";
            txtKateqoriyaEN.Text = "";
            txtKateqoriyaRU.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
