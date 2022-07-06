using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;




    public partial class MainCategory : System.Web.UI.Page
    {
        ClSsql clSsql = new ClSsql();
        protected void Page_Load(object sender, EventArgs e)
        {
        if (Session["UsersID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            GetMain();
            Session["MainID"] = 0;
            FIllOrgan();
            FIllCategory();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
 
        protected void GetMain()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by MainID) SN,* from Main order by SortBy");
            Repeater1.DataBind();
        }
    protected void FIllCategory()
    {
        ddlCategory.Items.Clear();
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataTextField = "CategoryName_AZ";
        ddlCategory.DataSource = clSsql.getDT("Select * from Category order by SortBy");
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void FIllOrgan()
    {
        ddlorgan.Items.Clear();
        ddlorgan.DataValueField = "OrganID";
        ddlorgan.DataTextField = "OrganName_AZ";
        ddlorgan.DataSource = clSsql.getDT("Select * from Organs order by SortBy");
        ddlorgan.DataBind();
        ddlorgan.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Main where MainID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtMainNameAZ.Text = dr["MainName_AZ"].ToString();
                txtMainNameEN.Text = dr["MainName_EN"].ToString();
                txtMainNameRU.Text = dr["MainName_RU"].ToString();
                ddlorgan.SelectedValue = dr["OrganID"].ToString();
                ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                txtInformationAZ.Text = dr["Information_AZ"].ToString();
                txtInformationEN.Text = dr["Information_EN"].ToString();
                txtInformationRU.Text = dr["Information_RU"].ToString();                
                txtSeviyyeAZ.Text = dr["Seviyye_AZ"].ToString();
                txtSeviyyeEN.Text = dr["Seviyye_EN"].ToString();
                txtSeviyyeRU.Text = dr["Seviyye_RU"].ToString();                
                txtSortBy.Text = dr["SortBy"].ToString();
                Session["MainID"]= dr["MainID"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Main where MainID=" + e.CommandArgument.ToString(), clSsql.sqlconn);
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            GetMain();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["MainID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Main Values(@MainName_AZ,@MainName_EN,@MainName_RU
                   ,@OrganID, @CategoryID, @Information_AZ, @Information_EN, @Information_RU, @Seviyye_AZ, 
                  @Seviyye_EN, @Seviyye_RU, @SortBy)", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("MainName_AZ", txtMainNameAZ.Text);
            cmd.Parameters.AddWithValue("MainName_EN", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("MainName_RU", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("OrganID", ddlorgan.SelectedValue);
            cmd.Parameters.AddWithValue("CategoryID", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("Information_AZ", txtInformationAZ.Text);
            cmd.Parameters.AddWithValue("Information_EN", txtInformationEN.Text);
            cmd.Parameters.AddWithValue("Information_RU", txtInformationRU.Text);            
            cmd.Parameters.AddWithValue("Seviyye_AZ", txtSeviyyeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_EN", txtSeviyyeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_RU", txtSeviyyeRU.Text);            
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            txtMainNameAZ.Text = "";
            txtMainNameEN.Text = "";
            txtMainNameRU.Text = "";
            txtInformationAZ.Text = "";
            txtInformationEN.Text = "";
            txtInformationRU.Text = "";           
            txtSeviyyeAZ.Text = "";
            txtSeviyyeEN.Text = "";
            txtSeviyyeRU.Text = "";            
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["MainID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Main set MainName_AZ=@MainName_AZ,MainName_EN=@MainName_EN,MainName_RU=@MainName_RU
                   ,OrganID=@OrganID, CategoryID=@CategoryID, Information_AZ=@Information_AZ, Information_EN=@Information_EN, Information_RU=@Information_RU, Seviyye_AZ=@Seviyye_AZ, 
                  Seviyye_EN=@Seviyye_EN, Seviyye_RU=@Seviyye_RU, SortBy=@SortBy where MainID=@MainID", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("MainName_AZ", txtMainNameAZ.Text);
            cmd.Parameters.AddWithValue("MainName_EN", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("MainName_RU", txtMainNameRU.Text);
            cmd.Parameters.AddWithValue("OrganID", ddlorgan.SelectedValue);
            cmd.Parameters.AddWithValue("CategoryID", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("Information_AZ", txtInformationAZ.Text);
            cmd.Parameters.AddWithValue("Information_EN", txtInformationEN.Text);
            cmd.Parameters.AddWithValue("Information_RU", txtInformationRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_AZ", txtSeviyyeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_EN", txtSeviyyeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_RU", txtSeviyyeRU.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("MainID", Session["MainID"].ToString());
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            txtMainNameAZ.Text = "";
            txtMainNameEN.Text = "";
            txtMainNameRU.Text = "";
            txtInformationAZ.Text = "";
            txtInformationEN.Text = "";
            txtInformationRU.Text = "";
            txtSeviyyeAZ.Text = "";
            txtSeviyyeEN.Text = "";
            txtSeviyyeRU.Text = "";            
            txtSortBy.Text = "";
            Session["MainID"] = "0";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        txtMainNameAZ.Text = "";
        txtMainNameEN.Text = "";
        txtMainNameRU.Text = "";
        txtInformationAZ.Text = "";
        txtInformationEN.Text = "";
        txtInformationRU.Text = "";
        txtSeviyyeAZ.Text = "";
        txtSeviyyeEN.Text = "";
        txtSeviyyeRU.Text = "";        
        txtSortBy.Text = "";
        Session["MainID"] = "0";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
