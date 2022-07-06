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
            GetLectures();
            Session["LectureID"] = 0;
            FIllOrgan();
            FIllCategory();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
    protected void GetLectures()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by LectureID) SN,*, (select STRING_AGG(AuthorName_AZ +' '+AuthorSurName_AZ,', ') from Authors 
where AuthorID in (select ConnAuthorAll.AuthorsID from ConnAuthorAll where TableName=N'Mühazirə' and ConnAuthorAll.TableID=LectureID)) Muellifler, L.Kurs LKurs from Lectures L inner join Main M
 on L.MainID=M.MainID inner join Organs O on O.OrganID=M.OrganID order by L.SortBy");
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
    protected void FIllAuthors()
    {
        chAuthors.Items.Clear();
        chAuthors.DataValueField = "AuthorID";
        chAuthors.DataTextField = "AuthorName";
        chAuthors.DataSource = clSsql.getDT("Select *,AuthorName_AZ+' '+AuthorSurName_AZ AuthorName from Authors order by AuthorName_AZ,AuthorSurName_AZ");
        chAuthors.DataBind();
        //chAuthors.Items.Insert(0, new ListItem("Seçin", "0"));
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
            DataRow dr = clSsql.getDT(@"Select *, L.Kurs LKurs from Lectures L inner join Main M
 on L.MainID=M.MainID inner join Organs O on O.OrganID=M.OrganID where L.LectureID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtLectureName.Text = dr["LectureName"].ToString();
                ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                ddlorgan.SelectedValue = dr["OrganID"].ToString();
                FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
                ddlNov.SelectedValue = dr["MainID"].ToString();                
                txtKurs.Text = dr["LKurs"].ToString();
                txtSortBy.Text = dr["SortBy"].ToString();
                Session["LectureID"] = dr["LectureID"].ToString();
                FIllAuthors();
                DataTable dt = clSsql.getDT("Select * from ConnAuthorAll where TableName = N'Mühazirə' and TableID=" + dr["LectureID"].ToString() + " order by ConnAuthorID");
                chAuthors.ClearSelection();

                for (int i = 0; i < chAuthors.Items.Count; i++)
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (chAuthors.Items[i].Value == row["AuthorsID"].ToString())
                                {
                                    chAuthors.Items[i].Selected = true;                                    
                                }
                            }
                        }
                    }
                }
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Lectures where LectureID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetLectures();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Lectureid = "0";
        if (Session["LectureID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Lectures Values( @LectureName,@MainID, @Kurs, @VideoURL_AZ, @VideoURL_EN, @VideoURL_RU, @SortBy)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("LectureName", txtLectureName.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("Kurs", txtKurs.Text);
            cmd.Parameters.AddWithValue("VideoURL_AZ", UPVideoAZ.FileName);
            cmd.Parameters.AddWithValue("VideoURL_EN", UPVideoEN.FileName);
            cmd.Parameters.AddWithValue("VideoURL_RU", UPVideoRU.FileName);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtSortBy.Text = "";
            txtKurs.Text = "";
            txtLectureName.Text = "";
            Lectureid = clSsql.getDT("Select max(LectureID) LectureID from Lectures").Rows[0][0].ToString();
        }
        else if (Session["LectureID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Lectures set LectureName=@LectureName,MainID=@MainID, Kurs=@Kurs, VideoURL_AZ=@VideoURL_AZ, VideoURL_EN=@VideoURL_EN, VideoURL_RU=@VideoURL_RU, SortBy=@SortBy where LectureID=@LectureID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("LectureName", txtLectureName.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("Kurs", txtKurs.Text);
            cmd.Parameters.AddWithValue("VideoURL_AZ", UPVideoAZ.FileName);
            cmd.Parameters.AddWithValue("VideoURL_EN", UPVideoEN.FileName);
            cmd.Parameters.AddWithValue("VideoURL_RU", UPVideoRU.FileName);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("LectureID", Session["LectureID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtLectureName.Text = "";
            txtSortBy.Text = "";
            txtKurs.Text = "";
            Lectureid = Session["LectureID"].ToString();
        }

        SqlCommand cmdconn = new SqlCommand("Delete from ConnAuthorAll where TableName = N'Mühazirə' and TableID =" + Session["LectureID"].ToString(), Methods.SqlConn);
        Methods.SqlConn.Open();
        cmdconn.ExecuteNonQuery();
        Methods.SqlConn.Close();
        foreach (ListItem item in chAuthors.Items)
        {
            if (item.Selected)
            {                 
                SqlCommand cmdheader = new SqlCommand("Insert into ConnAuthorAll (TableID,AuthorsID,TableName) values(@TableID,@AuthorsID,@TableName)", Methods.SqlConn);

                cmdheader.Parameters.AddWithValue("TableID", Lectureid);
                cmdheader.Parameters.AddWithValue("AuthorsID", item.Value);
                cmdheader.Parameters.AddWithValue("TableName", "Mühazirə");
                Methods.SqlConn.Open();
                cmdheader.ExecuteNonQuery();
                Methods.SqlConn.Close();
            }
        }
        Session["LectureID"] = "0";
        Response.Redirect(Request.Url.AbsoluteUri);
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        ddlNov.SelectedIndex = 0;         
        txtKurs.Text = "";
        txtSortBy.Text = "";
        txtLectureName.Text = "";
        Session["LectureID"] = "0";
        FIllAuthors();
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

    protected void ddlorgan_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
    }
}
