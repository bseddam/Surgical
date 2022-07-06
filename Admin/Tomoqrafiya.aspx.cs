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
            GetTomoqrafiya();
            Session["TomoqrafiyaID"] = 0;
            FIllOrgan();
            FIllCategory();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
    protected void GetTomoqrafiya()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by T.TomoqrafiyaID) SN,T.*,M.MainName_AZ,O.OrganName_AZ  
from Tomoqrafiya T inner join Main M on T.MainID=M.MainID 
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
            DataRow dr = clSsql.getDT(@"Select T.*,M.OrganID,M.CategoryID from Tomoqrafiya T inner join Main M
 on T.MainID=M.MainID where T.TomoqrafiyaID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtTomoqrafiyaNameAZ.Text = dr["TomoqrafiyaNameAZ"].ToString();
                txtTomoqrafiyaNameEN.Text = dr["TomoqrafiyaNameEN"].ToString();
                txtTomoqrafiyaNameRU.Text = dr["TomoqrafiyaNameRU"].ToString();
                ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                ddlorgan.SelectedValue = dr["OrganID"].ToString();
                FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
                ddlNov.SelectedValue = dr["MainID"].ToString();                
                txtMuayineUsuluAZ.Text = dr["MuayineUsuluAZ"].ToString();
                txtMuayineUsuluEN.Text = dr["MuayineUsuluEN"].ToString();
                txtMuayineUsuluRU.Text = dr["MuayineUsuluRU"].ToString();
                Session["TomoqrafiyaID"] = dr["TomoqrafiyaID"].ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Tomoqrafiya where TomoqrafiyaID=" + e.CommandArgument.ToString(), clSsql.sqlconn);
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            GetTomoqrafiya();
        } else 
        if (e.CommandName == "Slayd")
        {
            Session["SlideID"] = 0;
            Session["TomoqrafiyaID"] = e.CommandArgument.ToString();
            GetSlide(Session["TomoqrafiyaID"].ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal1();", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["TomoqrafiyaID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Tomoqrafiya Values(@TomoqrafiyaNameAZ, @TomoqrafiyaNameEN, @TomoqrafiyaNameRU, @MainID, @MuayineUsuluAZ, @MuayineUsuluEN, @MuayineUsuluRU)", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameAZ", txtTomoqrafiyaNameAZ.Text);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameEN", txtTomoqrafiyaNameEN.Text);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameRU", txtTomoqrafiyaNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MuayineUsuluAZ", txtMuayineUsuluAZ.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluEN", txtMuayineUsuluEN.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluRU", txtMuayineUsuluRU.Text);
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtTomoqrafiyaNameAZ.Text = "";
            txtTomoqrafiyaNameEN.Text = "";
            txtTomoqrafiyaNameRU.Text = "";
            txtMuayineUsuluAZ.Text = "";
            txtMuayineUsuluEN.Text = "";
            txtMuayineUsuluRU.Text = "";
        }
        else if (Session["TomoqrafiyaID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Tomoqrafiya set TomoqrafiyaNameAZ=@TomoqrafiyaNameAZ, TomoqrafiyaNameEN=@TomoqrafiyaNameEN, TomoqrafiyaNameRU=@TomoqrafiyaNameRU, MainID=@MainID, MuayineUsuluAZ=@MuayineUsuluAZ, MuayineUsuluEN=@MuayineUsuluEN, MuayineUsuluRU=@MuayineUsuluRU where TomoqrafiyaID=@TomoqrafiyaID", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameAZ", txtTomoqrafiyaNameAZ.Text);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameEN", txtTomoqrafiyaNameEN.Text);
            cmd.Parameters.AddWithValue("TomoqrafiyaNameRU", txtTomoqrafiyaNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MuayineUsuluAZ", txtMuayineUsuluAZ.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluEN", txtMuayineUsuluEN.Text);
            cmd.Parameters.AddWithValue("MuayineUsuluRU", txtMuayineUsuluRU.Text);
            cmd.Parameters.AddWithValue("TomoqrafiyaID", Session["TomoqrafiyaID"].ToString());
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtTomoqrafiyaNameAZ.Text = "";
            txtTomoqrafiyaNameEN.Text = "";
            txtTomoqrafiyaNameRU.Text = "";
            txtMuayineUsuluAZ.Text = "";
            txtMuayineUsuluEN.Text = "";
            txtMuayineUsuluRU.Text = "";
        }
        Session["TomoqrafiyaID"] = "0";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void Button3_Click(object sender, EventArgs e)
        {
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        ddlNov.SelectedIndex = 0;
        txtTomoqrafiyaNameAZ.Text = "";
        txtTomoqrafiyaNameEN.Text = "";
        txtTomoqrafiyaNameRU.Text = "";
        txtMuayineUsuluAZ.Text = "";
        txtMuayineUsuluEN.Text = "";
        txtMuayineUsuluRU.Text = "";
        Session["TomoqrafiyaID"] = "0";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    protected void ddlorgan_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
    }
    protected void GetSlide(string id)
    {
        Repeater2.DataSource = clSsql.getDT(@"Select row_number() over(order by SlideID) SN,* from Slides where TableName='Tomoqrafiya' and InfoID=" + id);
        Repeater2.DataBind();
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Slides where SlideID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                Session["SlideID"] = e.CommandArgument.ToString();
                txtSlideAZ.Text = dr["SlideName_AZ"].ToString();
                txtSlideEN.Text = dr["SlideName_EN"].ToString();
                txtSlideRU.Text = dr["SlideName_RU"].ToString();
                Session["fotonameAZ"] = dr["SlideURL_AZ"].ToString();
                Session["fotonameEN"] = dr["SlideURL_EN"].ToString();
                Session["fotonameRU"] = dr["SlideURL_RU"].ToString();
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand(@"Delete Slides where SlideID=" + e.CommandArgument.ToString(), clSsql.sqlconn);
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            GetSlide(Session["InfoID"].ToString());
        }
    }
    protected void BtnFotoSave_Click(object sender, EventArgs e)
    {
        // slide yadda saxla 
        string fotoAZ = "";
        string fotoEN = "";
        string fotoRU = "";
        if (Session["SlideID"].ToString() == "0")
        {
            fotoAZ = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_AZ.jpg";
            fotoEN = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_EN.jpg";
            fotoRU = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_RU.jpg";
            SqlCommand cmd = new SqlCommand(@"Insert into Slides (SlideName_AZ, SlideName_EN, SlideName_RU, SlideURL_AZ,SlideURL_EN,SlideURL_RU, InfoID, TableName) Values(@SlideName_AZ, @SlideName_EN, @SlideName_RU, @SlideURL_AZ,@SlideURL_EN,@SlideURL_RU, @InfoID, @TableName)", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("SlideName_AZ", txtSlideAZ.Text);
            cmd.Parameters.AddWithValue("SlideName_EN", txtSlideEN.Text);
            cmd.Parameters.AddWithValue("SlideName_RU", txtSlideRU.Text);
            cmd.Parameters.AddWithValue("SlideURL_AZ", fotoAZ);
            cmd.Parameters.AddWithValue("SlideURL_EN", fotoEN);
            cmd.Parameters.AddWithValue("SlideURL_RU", fotoRU);
            cmd.Parameters.AddWithValue("InfoID", Session["TomoqrafiyaID"].ToString());
            cmd.Parameters.AddWithValue("TableName", "Tomoqrafiya");
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            UPFotoAZ.SaveAs(Server.MapPath(@"..\") + fotoAZ);
            UPFotoEN.SaveAs(Server.MapPath(@"..\") + fotoEN);
            UPFotoRU.SaveAs(Server.MapPath(@"..\") + fotoRU);
            GetSlide(Session["InfoID"].ToString());
            Session["SlideID"] = 0;
            txtSlideAZ.Text = "";
            txtSlideEN.Text = "";
            txtSlideRU.Text = "";
            
        }
        else if (Session["SlideID"].ToString() != "0")
        {
            if (Session["fotonameAZ"].ToString().Trim() == "")
            {
                fotoAZ = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_AZ.jpg";
            }
            else
            {
                fotoAZ = Session["fotonameAZ"].ToString().Trim();
            }
            if (Session["fotonameEN"].ToString().Trim() == "")
            {
                fotoEN = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_EN.jpg";
            }
            else
            {
                fotoEN = Session["fotonameEN"].ToString().Trim();
            }
            if (Session["fotonameRU"].ToString().Trim() == "")
            {
                fotoRU = @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_RU.jpg";
            }
            else
            {
                fotoRU = Session["fotonameRU"].ToString().Trim();
            }
            SqlCommand cmd = new SqlCommand(@"Update Slides set SlideName_AZ=@SlideName_AZ, SlideName_EN=@SlideName_EN, SlideName_RU=@SlideName_RU, SlideURL_AZ=@SlideURL_AZ, SlideURL_EN=@SlideURL_EN, SlideURL_RU=@SlideURL_RU where SlideID=@SlideID", clSsql.sqlconn);
            cmd.Parameters.AddWithValue("SlideName_AZ", txtSlideAZ.Text);
            cmd.Parameters.AddWithValue("SlideName_EN", txtSlideEN.Text);
            cmd.Parameters.AddWithValue("SlideName_RU", txtSlideRU.Text);
            cmd.Parameters.AddWithValue("SlideURL_AZ", fotoAZ);
            cmd.Parameters.AddWithValue("SlideURL_EN", fotoEN);
            cmd.Parameters.AddWithValue("SlideURL_RU", fotoRU);
            cmd.Parameters.AddWithValue("SlideID", Session["SlideID"].ToString());
            clSsql.sqlconn.Open();
            cmd.ExecuteNonQuery();
            clSsql.sqlconn.Close();
            UPFotoAZ.SaveAs(Server.MapPath(@"..\") + fotoAZ);
            UPFotoEN.SaveAs(Server.MapPath(@"..\") + fotoEN);
            UPFotoRU.SaveAs(Server.MapPath(@"..\") + fotoRU);
            GetSlide(Session["TomoqrafiyaID"].ToString());
            Session["SlideID"] = 0;
            txtSlideAZ.Text = "";
            txtSlideEN.Text = "";
            txtSlideRU.Text = "";
            
        }
    }
}
