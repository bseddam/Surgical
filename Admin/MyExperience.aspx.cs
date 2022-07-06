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
            GetMenimTecrubem();
            Session["MenimTecrubemID"] = 0;
            FIllCategory();
            FIllAuthors();
            FIllOrgan();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
    protected void GetMenimTecrubem()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by MenimTecrubem.MenimTecrubemID) SN,MenimTecrubem.*, 
(select STRING_AGG(AuthorName_AZ +' '+AuthorSurName_AZ,', ') from Authors 
where AuthorID in (select ConnAuthorAll.AuthorsID from ConnAuthorAll 
where TableName=N'MenimTecrubem' and ConnAuthorAll.TableID=MenimTecrubemID)) Muellifler,
Main.MainName_AZ,o.OrganName_AZ from MenimTecrubem inner join Main on Main.MainID=MenimTecrubem.MainID
inner join Organs o on o.organid=Main.organid");
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
    protected void FIllAuthors()
    {
        chAuthors.Items.Clear();
        chAuthors.DataValueField = "AuthorID";
        chAuthors.DataTextField = "AuthorName";
        chAuthors.DataSource = clSsql.getDT("Select *,AuthorName_AZ+' '+AuthorSurName_AZ AuthorName from Authors order by AuthorName_AZ,AuthorSurName_AZ");
        chAuthors.DataBind();
        //chAuthors.Items.Insert(0, new ListItem("Seçin", "0"));
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
            DataRow dr = clSsql.getDT(@"Select E.*,M.OrganID,M.CategoryID from MenimTecrubem E inner join Main M
 on E.MainID=M.MainID where E.MenimTecrubemID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                txtMyExperienceNameAZ.Text = dr["MenimTecrubemNameAZ"].ToString();
                txtMyExperienceNameEN.Text = dr["MenimTecrubemNameEN"].ToString();
                txtMyExperienceNameRU.Text = dr["MenimTecrubemNameRU"].ToString();
                ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                ddlorgan.SelectedValue = dr["OrganID"].ToString();
                FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
                ddlNov.SelectedValue = dr["MainID"].ToString();                
                txtMyExperienceAZ.Text = dr["MenimTecrubemAZ"].ToString();
                txtMyExperienceEN.Text = dr["MenimTecrubemEN"].ToString();
                txtMyExperienceRU.Text = dr["MenimTecrubemRU"].ToString();
                Session["MenimTecrubemID"] = dr["MenimTecrubemID"].ToString();

                DataTable dt = clSsql.getDT("Select * from ConnAuthorAll where TableName='MenimTecrubem' and TableID=" + dr["MenimTecrubemID"].ToString() + " order by ConnAuthorID");
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
            SqlCommand cmd = new SqlCommand("Delete from MenimTecrubem where MenimTecrubemID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetMenimTecrubem();
        } 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MenimTecrubemID = "";
        if (Session["MenimTecrubemID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into MenimTecrubem Values(@MenimTecrubemNameAZ, @MenimTecrubemNameEN, @MenimTecrubemNameRU, @MainID, @MenimTecrubemAZ, @MenimTecrubemEN, @MenimTecrubemRU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MenimTecrubemNameAZ", txtMyExperienceNameAZ.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemNameEN", txtMyExperienceNameEN.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemNameRU", txtMyExperienceNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MenimTecrubemAZ", txtMyExperienceAZ.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemEN", txtMyExperienceEN.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemRU", txtMyExperienceRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtMyExperienceNameAZ.Text = "";
            txtMyExperienceNameEN.Text = "";
            txtMyExperienceNameRU.Text = "";
            txtMyExperienceAZ.Text = "";
            txtMyExperienceEN.Text = "";
            txtMyExperienceRU.Text = "";
            MenimTecrubemID = clSsql.getDT("Select max(MenimTecrubemID) MenimTecrubemID from MenimTecrubem").Rows[0][0].ToString();
        }
        else if (Session["MenimTecrubemID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update MenimTecrubem set MenimTecrubemNameAZ=@MenimTecrubemNameAZ, MenimTecrubemNameEN=@MenimTecrubemNameEN, MenimTecrubemNameRU=@MenimTecrubemNameRU, MainID=@MainID, MenimTecrubemAZ=@MenimTecrubemAZ, MenimTecrubemEN=@MenimTecrubemEN, MenimTecrubemRU=@MenimTecrubemRU where MenimTecrubemID=@MenimTecrubemID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MenimTecrubemNameAZ", txtMyExperienceNameAZ.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemNameEN", txtMyExperienceNameEN.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemNameRU", txtMyExperienceNameRU.Text);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("MenimTecrubemAZ", txtMyExperienceAZ.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemEN", txtMyExperienceEN.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemRU", txtMyExperienceRU.Text);
            cmd.Parameters.AddWithValue("MenimTecrubemID", Session["MenimTecrubemID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            txtMyExperienceNameAZ.Text = "";
            txtMyExperienceNameEN.Text = "";
            txtMyExperienceNameRU.Text = "";
            txtMyExperienceAZ.Text = "";
            txtMyExperienceEN.Text = "";
            txtMyExperienceRU.Text = "";
            MenimTecrubemID = Session["MenimTecrubemID"].ToString();
        }

        SqlCommand cmdconn = new SqlCommand("Delete from ConnAuthorAll where TableName='MenimTecrubem' and TableID=" + Session["MenimTecrubemID"].ToString(), Methods.SqlConn);
        Methods.SqlConn.Open();
        cmdconn.ExecuteNonQuery();
        Methods.SqlConn.Close();
        foreach (ListItem item in chAuthors.Items)
        {
            if (item.Selected)
            {
                SqlCommand cmdheader = new SqlCommand("Insert into ConnAuthorAll (TableID,AuthorsID,TableName) values(@TableID,@AuthorsID,@TableName)", Methods.SqlConn);

                cmdheader.Parameters.AddWithValue("TableID", MenimTecrubemID);
                cmdheader.Parameters.AddWithValue("AuthorsID", item.Value);
                cmdheader.Parameters.AddWithValue("TableName", "MenimTecrubem");
                Methods.SqlConn.Open();
                cmdheader.ExecuteNonQuery();
                Methods.SqlConn.Close();
            }
        }
        Session["MenimTecrubemID"] = "0";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void Button3_Click(object sender, EventArgs e)
        {
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        ddlNov.SelectedIndex = 0;
        txtMyExperienceNameAZ.Text = "";
        txtMyExperienceNameEN.Text = "";
        txtMyExperienceNameRU.Text = "";
        txtMyExperienceAZ.Text = "";
        txtMyExperienceEN.Text = "";
        txtMyExperienceRU.Text = "";
        Session["MenimTecrubemID"] = "0";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    protected void ddlorgan_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
    }
}
