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
            GetAuthors();
            Session["AuthorID"] = 0;
           // lblfooternote.Text = clSsql.getfooternote();
        }
    }
 
        protected void GetAuthors()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by AuthorID) SN,* from Authors");
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Authors where AuthorID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                
                Session["AuthorID"] = int.Parse(dr["AuthorID"].ToString());
                txtAdiAZ.Text = dr["AuthorName_AZ"].ToString();
                txtAdiEN.Text = dr["AuthorName_EN"].ToString();
                txtAdiRU.Text = dr["AuthorName_RU"].ToString();
                txtSoyadiAZ.Text = dr["AuthorSurName_AZ"].ToString();
                txtSoyadiEN.Text = dr["AuthorSurName_EN"].ToString();
                txtSoyadiRU.Text = dr["AuthorSurName_RU"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Authors where AuthorID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAuthors();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["AuthorID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Authors Values(@AuthorName_AZ, @AuthorName_EN, @AuthorName_RU, @AuthorSurName_AZ, @AuthorSurName_EN, @AuthorSurName_RU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("AuthorName_AZ", txtAdiAZ.Text);
            cmd.Parameters.AddWithValue("AuthorName_EN", txtAdiEN.Text);
            cmd.Parameters.AddWithValue("AuthorName_RU", txtAdiRU.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_AZ", txtSoyadiAZ.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_EN", txtSoyadiEN.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_RU", txtSoyadiRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAuthors();
            txtAdiAZ.Text = "";
            txtAdiEN.Text = "";
            txtAdiRU.Text = "";
            txtSoyadiAZ.Text = "";
            txtSoyadiEN.Text = "";
            txtSoyadiRU.Text = "";
            Session["AuthorID"] = 0;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["AuthorID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Authors set AuthorName_AZ=@AuthorName_AZ, AuthorName_EN=@AuthorName_EN, AuthorName_RU=@AuthorName_RU, AuthorSurName_AZ=@AuthorSurName_AZ, AuthorSurName_EN=@AuthorSurName_EN, AuthorSurName_RU=@AuthorSurName_RU where AuthorID=@AuthorID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("AuthorName_AZ", txtAdiAZ.Text);
            cmd.Parameters.AddWithValue("AuthorName_EN", txtAdiEN.Text);
            cmd.Parameters.AddWithValue("AuthorName_RU", txtAdiRU.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_AZ", txtSoyadiAZ.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_EN", txtSoyadiEN.Text);
            cmd.Parameters.AddWithValue("AuthorSurName_RU", txtSoyadiRU.Text);
            cmd.Parameters.AddWithValue("AuthorID", Session["AuthorID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetAuthors();
            txtAdiAZ.Text = "";
            txtAdiEN.Text = "";
            txtAdiRU.Text = "";
            txtSoyadiAZ.Text = "";
            txtSoyadiEN.Text = "";
            txtSoyadiRU.Text = "";
            Session["AuthorID"] = 0;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["AuthorID"] = 0;
            txtAdiAZ.Text = "";
            txtAdiEN.Text = "";
            txtAdiRU.Text = "";
            txtSoyadiAZ.Text = "";
            txtSoyadiEN.Text = "";
            txtSoyadiRU.Text = "";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
