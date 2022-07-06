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
            GetEndoskopiya();
            Session["EndoskopiyaID"] = 0;
            FIllOrgan();
            FIllCategory();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
    protected void GetEndoskopiya()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by E.EndoskopiyaID) SN,E.*,M.MainName_AZ,O.OrganName_AZ  
from Endoskopiya E inner join Main M on E.MainID=M.MainID 
inner join Organs O on O.OrganID=M.OrganID ");
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
    protected void FillMainCategory(string Categoryid, string Organid)
    {
        ddlNov.Items.Clear();
        ddlNov.DataValueField = "MainID";
        ddlNov.DataTextField = "MainName_AZ";
        ddlNov.DataSource = clSsql.getDT("Select * from Main where CategoryID="+Categoryid+" and OrganID="+Organid+" order by SortBy");
        ddlNov.DataBind();
        ddlNov.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select E.*,M.OrganID,M.CategoryID from Endoskopiya E inner join Main M
 on E.MainID=M.MainID where E.EndoskopiyaID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtEndoskopiyaNameAZ.Text = dr["EndoskopiyaNameAZ"].ToString();
                txtEndoskopiyaNameEN.Text = dr["EndoskopiyaNameEN"].ToString();
                txtEndoskopiyaNameRU.Text = dr["EndoskopiyaNameRU"].ToString();
                ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                ddlorgan.SelectedValue = dr["OrganID"].ToString();
                FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
                ddlNov.SelectedValue = dr["MainID"].ToString();                
                txtMuayineUsuluAZ.Text = dr["MuayineUsuluAZ"].ToString();
                txtMuayineUsuluEN.Text = dr["MuayineUsuluEN"].ToString();
                txtMuayineUsuluRU.Text = dr["MuayineUsuluRU"].ToString();
                txtVideoAZ.Text = dr["VideoAZ"].ToString();
                txtVideoEN.Text = dr["VideoEN"].ToString();
                txtVideoRU.Text = dr["VideoRU"].ToString();
                Session["EndoskopiyaID"] = dr["EndoskopiyaID"].ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Endoskopiya where EndoskopiyaID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetEndoskopiya();
        } 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["EndoskopiyaID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Endoskopiya Values(@EndoskopiyaNameAZ, @EndoskopiyaNameEN, @EndoskopiyaNameRU, @MainID, @MuayineUsuluAZ, @MuayineUsuluEN, @MuayineUsuluRU, @VideoAZ, @VideoEN, @VideoRU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("EndoskopiyaNameAZ", txtEndoskopiyaNameAZ.Text);
            cmd.Parameters.AddWithValue("EndoskopiyaNameEN", txtEndoskopiyaNameEN.Text);
            cmd.Parameters.AddWithValue("EndoskopiyaNameRU", txtEndoskopiyaNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MuayineUsuluAZ", txtMuayineUsuluAZ.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluEN", txtMuayineUsuluEN.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluRU", txtMuayineUsuluRU.Text);
            cmd.Parameters.AddWithValue("VideoAZ", txtVideoAZ.Text);
            cmd.Parameters.AddWithValue("VideoEN", txtVideoEN.Text);
            cmd.Parameters.AddWithValue("VideoRU", txtVideoRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtEndoskopiyaNameAZ.Text = "";
            txtEndoskopiyaNameEN.Text = "";
            txtEndoskopiyaNameRU.Text = "";
            txtMuayineUsuluAZ.Text = "";
            txtMuayineUsuluEN.Text = "";
            txtMuayineUsuluRU.Text = "";
            txtVideoAZ.Text = "";
            txtVideoEN.Text = "";
            txtVideoRU.Text = "";
        }
        else if (Session["EndoskopiyaID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Endoskopiya set EndoskopiyaNameAZ=@EndoskopiyaNameAZ, EndoskopiyaNameEN=@EndoskopiyaNameEN, EndoskopiyaNameRU=@EndoskopiyaNameRU, MainID=@MainID, MuayineUsuluAZ=@MuayineUsuluAZ, MuayineUsuluEN=@MuayineUsuluEN, MuayineUsuluRU=@MuayineUsuluRU, VideoAZ=@VideoAZ, VideoEN=@VideoEN, VideoRU=@VideoRU where EndoskopiyaID=@EndoskopiyaID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("EndoskopiyaNameAZ", txtEndoskopiyaNameAZ.Text);
            cmd.Parameters.AddWithValue("EndoskopiyaNameEN", txtEndoskopiyaNameEN.Text);
            cmd.Parameters.AddWithValue("EndoskopiyaNameRU", txtEndoskopiyaNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MuayineUsuluAZ", txtMuayineUsuluAZ.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluEN", txtMuayineUsuluEN.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluRU", txtMuayineUsuluRU.Text);
            cmd.Parameters.AddWithValue("VideoAZ", txtVideoAZ.Text);
            cmd.Parameters.AddWithValue("VideoEN", txtVideoEN.Text);
            cmd.Parameters.AddWithValue("VideoRU", txtVideoRU.Text);
            cmd.Parameters.AddWithValue("EndoskopiyaID", Session["EndoskopiyaID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtEndoskopiyaNameAZ.Text = "";
            txtEndoskopiyaNameEN.Text = "";
            txtEndoskopiyaNameRU.Text = "";
            txtMuayineUsuluAZ.Text = "";
            txtMuayineUsuluEN.Text = "";
            txtMuayineUsuluRU.Text = "";
            txtVideoAZ.Text = "";
            txtVideoEN.Text = "";
            txtVideoRU.Text = "";
        }
        Session["EndoskopiyaID"] = "0";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void Button3_Click(object sender, EventArgs e)
        {
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        ddlNov.SelectedIndex = 0;
        txtEndoskopiyaNameAZ.Text = "";
        txtEndoskopiyaNameEN.Text = "";
        txtEndoskopiyaNameRU.Text = "";
        txtMuayineUsuluAZ.Text = "";
        txtMuayineUsuluEN.Text = "";
        txtMuayineUsuluRU.Text = "";
        txtVideoAZ.Text = "";
        txtVideoEN.Text = "";
        txtVideoRU.Text = "";
        Session["EndoskopiyaID"] = "0";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    protected void ddlorgan_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
    }
}
