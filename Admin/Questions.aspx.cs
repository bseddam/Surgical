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
            GetQuestions();
            Session["QuestionID"] = 0;
            FIllCategory();
            FIllAuthors();
            FIllOrgan();
            FIllQuestionType();
            lblfooternote.Text = clSsql.getfooternote();
        }
    }
 
        protected void GetQuestions()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by Questions.QuestionID) SN,Questions.*, (select STRING_AGG(AuthorName_AZ +' '+AuthorSurName_AZ,', ') from Authors 
where AuthorID in (select ConnAuthorAll.AuthorsID from ConnAuthorAll where TableName=N'Questions' and ConnAuthorAll.TableID=QuestionID)) Muellifler, Main.MainName_AZ from Questions inner join Main on Main.MainID=Questions.MainID");
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
    protected void FIllQuestionType()
    {
        ddlQuestionType.Items.Clear();
        ddlQuestionType.DataValueField = "QuestionTypeID";
        ddlQuestionType.DataTextField = "QuestionType";
        ddlQuestionType.DataSource = clSsql.getDT("Select * from QuestionType");
        ddlQuestionType.DataBind();
        ddlQuestionType.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void FillMainCategory(string Categoryid, string Organid)
    {
        ddlNov.Items.Clear();
        ddlNov.DataValueField = "MainID";
        ddlNov.DataTextField = "MainName_AZ";
        ddlNov.DataSource = clSsql.getDT("Select * from Main where CategoryID=" + Categoryid + " and OrganID=" + Organid + " order by SortBy");
        ddlNov.DataBind();
        ddlNov.Items.Insert(0, new ListItem("Seçin", "0"));
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Questions where QuestionID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                FIllAuthors();
                FIllCategory();
                FIllOrgan();
                DataRow dr1= clSsql.getDT(@"Select * from Main where MainID=" + dr["MainID"].ToString()).Rows[0];
                ddlCategory.SelectedValue = dr1["CategoryID"].ToString();
                ddlorgan.SelectedValue = dr1["OrganID"].ToString();
                FIllQuestionType();
                ddlQuestionType.SelectedValue = dr["QuestionTypeID"].ToString();
                FillMainCategory(ddlCategory.SelectedValue,ddlorgan.SelectedValue);
                ddlNov.SelectedValue = dr["MainID"].ToString();
                Session["QuestionID"] = int.Parse(dr["QuestionID"].ToString());
                txtSualAZ.Text = dr["QuestionText_AZ"].ToString();
                txtSualEN.Text = dr["QuestionText_EN"].ToString();
                txtSualRU.Text = dr["QuestionText_RU"].ToString();                
                txtCavabAZ.Text = dr["AnswerText_AZ"].ToString();
                txtCavabEN.Text = dr["AnswerText_EN"].ToString();
                txtCavabRU.Text = dr["AnswerText_RU"].ToString();
                txtduzgunCavabAZ.Text = dr["ValidAnswer_AZ"].ToString();
                txtduzgunCavabEN.Text = dr["ValidAnswer_AZ"].ToString();
                txtduzgunCavabRU.Text = dr["ValidAnswer_AZ"].ToString();
                txtDetailAZ.Text = dr["DetailsText_AZ"].ToString();
                txtDetailEN.Text = dr["DetailsText_EN"].ToString();
                txtDetailRU.Text = dr["DetailsText_RU"].ToString();
                DataTable dt = clSsql.getDT("Select * from ConnAuthorAll where TableName='Questions' and TableID=" + dr["QuestionID"].ToString() + " order by ConnAuthorID");
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
            SqlCommand cmd = new SqlCommand("Delete from Questions where QuestionID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetQuestions();
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        string QuestionID = "0";
        if (Session["QuestionID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Questions Values(@MainID, @QuestionTypeID, @QuestionText_AZ, @QuestionText_EN, @QuestionText_RU, @AnswerText_AZ, 
                        @AnswerText_EN, @AnswerText_RU, @ValidAnswer_AZ, @ValidAnswer_EN, @ValidAnswer_RU, @DetailsText_AZ, 
                  @DetailsText_EN, @DetailsText_RU)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("QuestionTypeID", ddlNov.SelectedValue);            
            cmd.Parameters.AddWithValue("QuestionText_AZ", txtSualAZ.Text);
            cmd.Parameters.AddWithValue("QuestionText_EN", txtSualEN.Text);
            cmd.Parameters.AddWithValue("QuestionText_RU", txtSualRU.Text);
            cmd.Parameters.AddWithValue("AnswerText_AZ", txtCavabAZ.Text);
            cmd.Parameters.AddWithValue("AnswerText_EN", txtCavabEN.Text);
            cmd.Parameters.AddWithValue("AnswerText_RU", txtCavabRU.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_AZ", txtduzgunCavabAZ.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_EN", txtduzgunCavabEN.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_RU", txtduzgunCavabRU.Text);
            cmd.Parameters.AddWithValue("DetailsText_AZ", txtDetailAZ.Text);
            cmd.Parameters.AddWithValue("DetailsText_EN", txtDetailEN.Text);
            cmd.Parameters.AddWithValue("DetailsText_RU", txtDetailRU.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            ddlQuestionType.SelectedIndex = 0;
            txtSualAZ.Text = "";
            txtSualEN.Text = "";
            txtSualRU.Text = "";
            txtCavabAZ.Text = "";
            txtCavabEN.Text = "";
            txtCavabRU.Text = "";
            txtduzgunCavabAZ.Text = "";
            txtduzgunCavabEN.Text = "";
            txtduzgunCavabRU.Text = "";
            txtDetailAZ.Text = "";
            txtDetailEN.Text = "";
            txtDetailRU.Text = "";
            QuestionID = clSsql.getDT("Select max(QuestionID) QuestionID from Questions").Rows[0][0].ToString();
        }
        else if (Session["QuestionID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Questions set MainID=@MainID, QuestionTypeID=@QuestionTypeID, QuestionText_AZ=@QuestionText_AZ, QuestionText_EN=@QuestionText_EN, QuestionText_RU=@QuestionText_RU, AnswerText_AZ=@AnswerText_AZ, 
                        AnswerText_EN=@AnswerText_EN, AnswerText_RU=@AnswerText_RU, ValidAnswer_AZ=@ValidAnswer_AZ, ValidAnswer_EN=@ValidAnswer_EN, ValidAnswer_RU=@ValidAnswer_RU, DetailsText_AZ=@DetailsText_AZ, 
                  DetailsText_EN=@DetailsText_EN, DetailsText_RU=@DetailsText_RU where QuestionID=@QuestionID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainID", ddlNov.SelectedValue);
            cmd.Parameters.AddWithValue("QuestionTypeID", ddlQuestionType.SelectedValue);
            cmd.Parameters.AddWithValue("QuestionText_AZ", txtSualAZ.Text);
            cmd.Parameters.AddWithValue("QuestionText_EN", txtSualEN.Text);
            cmd.Parameters.AddWithValue("QuestionText_RU", txtSualRU.Text);
            cmd.Parameters.AddWithValue("AnswerText_AZ", txtCavabAZ.Text);
            cmd.Parameters.AddWithValue("AnswerText_EN", txtCavabEN.Text);
            cmd.Parameters.AddWithValue("AnswerText_RU", txtCavabRU.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_AZ", txtduzgunCavabAZ.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_EN", txtduzgunCavabEN.Text);
            cmd.Parameters.AddWithValue("ValidAnswer_RU", txtduzgunCavabRU.Text);
            cmd.Parameters.AddWithValue("DetailsText_AZ", txtDetailAZ.Text);
            cmd.Parameters.AddWithValue("DetailsText_EN", txtDetailEN.Text);
            cmd.Parameters.AddWithValue("DetailsText_RU", txtDetailRU.Text);
            cmd.Parameters.AddWithValue("QuestionID", Session["QuestionID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            ddlNov.SelectedIndex = 0;
            ddlQuestionType.SelectedIndex = 0;
            txtSualAZ.Text = "";
            txtSualEN.Text = "";
            txtSualRU.Text = "";
            txtCavabAZ.Text = "";
            txtCavabEN.Text = "";
            txtCavabRU.Text = "";
            txtduzgunCavabAZ.Text = "";
            txtduzgunCavabEN.Text = "";
            txtduzgunCavabRU.Text = "";
            txtDetailAZ.Text = "";
            txtDetailEN.Text = "";
            txtDetailRU.Text = "";
            QuestionID = Session["QuestionID"].ToString();
        }

        SqlCommand cmdconn = new SqlCommand("Delete from ConnAuthorAll where TableName='Questions' and TableID=" + Session["QuestionID"].ToString(), Methods.SqlConn);
        Methods.SqlConn.Open();
        cmdconn.ExecuteNonQuery();
        Methods.SqlConn.Close();
        foreach (ListItem item in chAuthors.Items)
        {
            if (item.Selected)
            {
                SqlCommand cmdheader = new SqlCommand("Insert into ConnAuthorAll (TableID,AuthorsID,TableName) values(@TableID,@AuthorsID,@TableName)", Methods.SqlConn);

                cmdheader.Parameters.AddWithValue("TableID", QuestionID);
                cmdheader.Parameters.AddWithValue("AuthorsID", item.Value);
                cmdheader.Parameters.AddWithValue("TableName", "Questions");
                Methods.SqlConn.Open();
                cmdheader.ExecuteNonQuery();
                Methods.SqlConn.Close();
            }
        }
        Session["QuestionID"] = "0";
        Response.Redirect(Request.Url.AbsoluteUri);
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["QuestionID"] = 0;
        ddlCategory.SelectedIndex = 0;
        ddlorgan.SelectedIndex = 0;
        ddlNov.SelectedIndex = 0;
        ddlQuestionType.SelectedIndex = 0;
            txtSualAZ.Text = "";
            txtSualEN.Text = "";
            txtSualRU.Text = "";
            txtCavabAZ.Text = "";
            txtCavabEN.Text = "";
            txtCavabRU.Text = "";
        txtDetailAZ.Text = "";
        txtDetailEN.Text = "";
        txtDetailRU.Text = "";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

    protected void ddlorgan_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMainCategory(ddlCategory.SelectedValue.ToString(), ddlorgan.SelectedValue.ToString());
    }
}
