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
                    Session["InfoID"] = 0;
                    lblfooternote.Text = clSsql.getfooternote();
                    GetMainCategory();
                    GetTablesHeader();
                   // GetHeader();
                    GetInfo();
                }
        }
 
        protected void GetInfo()
        {
            Repeater1.DataSource = clSsql.getDT(@"Select row_number() over(order by InfoID) SN,i.*,m.MainName_AZ,f.Adi_AZ from Informations i inner join 
main m on m.MainID=i.MainID inner join FieldNames f on f.FieldID=i.FieldNamesID");
            Repeater1.DataBind();
        }
    protected void GetSlide(string id)
    {
        Repeater2.DataSource = clSsql.getDT(@"Select row_number() over(order by SlideID) SN,* from Slides where InfoID=" + id);
        Repeater2.DataBind();
    }
    protected void GetMainCategory()
    {
        ddlMainCategory.Items.Clear();
        ddlMainCategory.DataValueField = "MainID";
        ddlMainCategory.DataTextField = "MainName_AZ";
        ddlMainCategory.DataSource = clSsql.getDT(@"Select row_number() over(order by MainID) SN,* from Main");
        ddlMainCategory.DataBind();
        ddlMainCategory.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void GetTablesHeader()
    {
        ddltable.Items.Clear();
        ddltable.DataValueField = "TableHeaderID";
        ddltable.DataTextField = "TableHeader_AZ";
        ddltable.DataSource = clSsql.getDT(@"Select row_number() over(order by TableHeaderID) SN,* from TableHeader");
        ddltable.DataBind();
        ddltable.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    //protected void GetHeader()
    //{
    //    DataTable dt = clSsql.getDT(@"Select row_number() over(order by sortby) SN,*,' |' fild from Headers");
    //    chlist.DataValueField = "HeaderID";
    //    chlist.DataTextField = "HeaderName_AZ";
    //    chlist.DataSource = dt;
    //    chlist.DataBind();
    //    chQisa.DataValueField = "HeaderID";
    //    chQisa.DataTextField = "fild";
    //    chQisa.DataSource = dt;
    //    chQisa.DataBind();
    //    chAciqlama.DataValueField = "HeaderID";
    //    chAciqlama.DataTextField = "fild";
    //    chAciqlama.DataSource = dt;
    //    chAciqlama.DataBind();
    //    chSlide.DataValueField = "HeaderID";
    //    chSlide.DataTextField = "fild";
    //    chSlide.DataSource = dt;
    //    chSlide.DataBind();
    //    chQisaAcQapa.DataValueField = "HeaderID";
    //    chQisaAcQapa.DataTextField = "fild";
    //    chQisaAcQapa.DataSource = dt;
    //    chQisaAcQapa.DataBind();
    //    chAciqlamaAcQapa.DataValueField = "HeaderID";
    //    chAciqlamaAcQapa.DataTextField = "fild";
    //    chAciqlamaAcQapa.DataSource = dt;
    //    chAciqlamaAcQapa.DataBind();
    //    chQisa.ForeColor = chAciqlama.ForeColor = chSlide.ForeColor = chQisaAcQapa.ForeColor = chAciqlamaAcQapa.ForeColor = System.Drawing.Color.White;
    //}
    protected void GetFields(string id)
    {
        ddlFieldName.Items.Clear();
        ddlFieldName.DataValueField = "FieldID";
        ddlFieldName.DataTextField = "Adi_AZ";
        ddlFieldName.DataSource = clSsql.getDT(@"Select row_number() over(order by FieldID) SN,* from FieldNames Where TableHeaderID="+id);
        ddlFieldName.DataBind();
        ddlFieldName.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        if (e.CommandName == "Deyish")
        {
            DataRow dr = clSsql.getDT(@"Select * from Informations i inner join FieldNames f on f.FieldID=i.FieldNamesID where i.InfoID=" + e.CommandArgument.ToString()).Rows[0];
            if (dr != null)
            {
                Session["InfoID"] = int.Parse(dr["InfoID"].ToString());
                ddlMainCategory.SelectedValue = dr["MainID"].ToString();
                ddltable.SelectedValue = dr["TableHeaderID"].ToString();
                GetFields(dr["TableHeaderID"].ToString());
                ddlFieldName.SelectedValue = dr["FieldNamesID"].ToString();
                txtshortAZ.Text = dr["InfoShort_AZ"].ToString();
                txtshortEN.Text = dr["InfoShort_EN"].ToString();
                txtshortRU.Text = dr["InfoShort_RU"].ToString();
                InfoDetails_AZ.Text = dr["InfoDetails_AZ"].ToString();
                InfoDetails_EN.Text = dr["InfoDetails_EN"].ToString();
                InfoDetails_RU.Text = dr["InfoDetails_RU"].ToString();
                txtSortBy.Text = dr["SortBy"].ToString();

                //DataTable dt = clSsql.getDT("Select * from ConnHeaderInformation where InfoID=" + dr["InfoID"].ToString()+ " order by HeaderID");
                //chlist.ClearSelection();
                //chQisa.ClearSelection();
                //chAciqlama.ClearSelection();
                //chSlide.ClearSelection();
                //chQisaAcQapa.ClearSelection();
                //chAciqlamaAcQapa.ClearSelection();

                //for (int i = 0; i < chlist.Items.Count; i++)
                //{
                //        if (dt != null)
                //        {
                //            if (dt.Rows.Count > 0)
                //            {
                //                foreach (DataRow row in dt.Rows)
                //                {
                //                    if (chlist.Items[i].Value == row["HeaderID"].ToString())
                //                    {
                //                        chlist.Items[i].Selected = true;
                //                        if (row["Short"].ToString()=="1")
                //                        {
                //                             chQisa.Items[i].Selected = true;
                //                        }
                //                        if (row["Detail"].ToString() == "1")
                //                        {
                //                            chAciqlama.Items[i].Selected = true;
                //                        }
                //                        if (row["Slide"].ToString() == "1")
                //                        {
                //                            chSlide.Items[i].Selected = true;
                //                        }
                //                        if (row["ShortView"].ToString() == "1")
                //                        {
                //                            chQisaAcQapa.Items[i].Selected = true;
                //                        }
                //                        if (row["DetailView"].ToString() == "1")
                //                        {
                //                            chAciqlamaAcQapa.Items[i].Selected = true;
                //                        }
                //                    }
                //                }
                //            }
                //        }                   
                //}

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Informations where InfoID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetInfo();
        } else if (e.CommandName == "Slayd")
        {
            Session["SlideID"] = 0;
            Session["infoID"] = e.CommandArgument.ToString();
            GetSlide(Session["infoID"].ToString());            
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal1();", true);
        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
        string infoid = "0";
        if (Session["InfoID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Informations (MainID, InfoShort_AZ, InfoShort_EN, InfoShort_RU, InfoDetails_AZ, InfoDetails_EN, InfoDetails_RU, FieldNamesID, SortBy) Values(@MainID, @InfoShort_AZ, @InfoShort_EN, @InfoShort_RU, @InfoDetails_AZ, @InfoDetails_EN, @InfoDetails_RU, @FieldNamesID, @SortBy)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainID", ddlMainCategory.SelectedValue);
            cmd.Parameters.AddWithValue("InfoShort_AZ", txtshortAZ.Text);
            cmd.Parameters.AddWithValue("InfoShort_EN", txtshortEN.Text);
            cmd.Parameters.AddWithValue("InfoShort_RU", txtshortRU.Text);
            cmd.Parameters.AddWithValue("InfoDetails_AZ", InfoDetails_AZ.Text);
            cmd.Parameters.AddWithValue("InfoDetails_EN", InfoDetails_EN.Text);
            cmd.Parameters.AddWithValue("InfoDetails_RU", InfoDetails_RU.Text);
            cmd.Parameters.AddWithValue("FieldNamesID", ddlFieldName.SelectedValue);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetInfo();
            Session["InfoID"] = 0;
            txtshortAZ.Text = "";
            txtshortEN.Text = "";
            txtshortRU.Text = "";
            InfoDetails_AZ.Text = "";
            InfoDetails_EN.Text = "";
            InfoDetails_RU.Text = "";
            ddlMainCategory.SelectedValue = "0";
            ddlFieldName.SelectedValue = "0";
            infoid = clSsql.getDT("Select max(InfoID) InfoID from Informations").Rows[0][0].ToString();
            
        }
        else if (Session["InfoID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Informations set MainID=@MainID, InfoShort_AZ=@InfoShort_AZ, InfoShort_EN=@InfoShort_EN, InfoShort_RU=@InfoShort_RU, InfoDetails_AZ=@InfoDetails_AZ, InfoDetails_EN=@InfoDetails_EN, InfoDetails_RU=@InfoDetails_RU, FieldNamesID=@FieldNamesID,SortBy=@SortBy where InfoID=@InfoID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainID", ddlMainCategory.SelectedValue);
            cmd.Parameters.AddWithValue("InfoShort_AZ", txtshortAZ.Text);
            cmd.Parameters.AddWithValue("InfoShort_EN", txtshortEN.Text);
            cmd.Parameters.AddWithValue("InfoShort_RU", txtshortRU.Text);
            cmd.Parameters.AddWithValue("InfoDetails_AZ", InfoDetails_AZ.Text);
            cmd.Parameters.AddWithValue("InfoDetails_EN", InfoDetails_EN.Text);
            cmd.Parameters.AddWithValue("InfoDetails_RU", InfoDetails_RU.Text);
            cmd.Parameters.AddWithValue("FieldNamesID", ddlFieldName.SelectedValue);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("InfoID", Session["InfoID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetInfo();
            infoid = Session["InfoID"].ToString();
            Session["InfoID"] = 0;
            txtshortAZ.Text = "";
            txtshortEN.Text = "";
            txtshortRU.Text = "";
            InfoDetails_AZ.Text = "";
            InfoDetails_EN.Text = "";
            InfoDetails_RU.Text = "";
            ddlMainCategory.SelectedValue = "0";
            ddlFieldName.SelectedValue = "0";
            
        }
        //SqlCommand cmdconn = new SqlCommand("Delete from ConnHeaderInformation where InfoID=" + infoid, Methods.SqlConn);
        //Methods.SqlConn.Open();
        //cmdconn.ExecuteNonQuery();
        //Methods.SqlConn.Close();
        //int i = -1;
        //foreach (ListItem item in chlist.Items)
        //{
        //    i++;
            
        //    if (item.Selected)
        //    {
        //        int qisa = 0;
        //        if (chQisa.Items[i].Selected)
        //        {
        //             qisa= 1;
        //        }
        //        int Aciqlama = 0;
        //        if (chAciqlama.Items[i].Selected)
        //        {
        //            Aciqlama = 1;
        //        }
        //        int Slide = 0;
        //        if (chSlide.Items[i].Selected)
        //        {
        //            Slide = 1;
        //        }
        //        int qisaview = 0;
        //        if (chQisaAcQapa.Items[i].Selected)
        //        {
        //            qisaview = 1;
        //        }
        //        int aciqlamaview = 0;
        //        if (chAciqlamaAcQapa.Items[i].Selected)
        //        {
        //            aciqlamaview = 1;
        //        }

        //        SqlCommand cmdheader = new SqlCommand("Insert into ConnHeaderInformation (InfoID,HeaderID,Short,Detail,Slide,ShortView,DetailView) values(@InfoID,@HeaderID,@Short,@Detail,@Slide,@ShortView,@DetailView)", Methods.SqlConn);

        //        cmdheader.Parameters.AddWithValue("InfoID", infoid);
        //        cmdheader.Parameters.AddWithValue("HeaderID", item.Value);
        //        cmdheader.Parameters.AddWithValue("Short", qisa);
        //        cmdheader.Parameters.AddWithValue("Detail", Aciqlama);
        //        cmdheader.Parameters.AddWithValue("Slide", Slide);
        //        cmdheader.Parameters.AddWithValue("ShortView", qisaview);
        //        cmdheader.Parameters.AddWithValue("DetailView", aciqlamaview);
        //        Methods.SqlConn.Open();
        //        cmdheader.ExecuteNonQuery();
        //        Methods.SqlConn.Close();
        //    }
        //}

        Response.Redirect(Request.Url.AbsoluteUri);
    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["InfoID"] = 0;
            txtshortAZ.Text = "";
            txtshortEN.Text = "";
            txtshortRU.Text = "";
            InfoDetails_AZ.Text = "";
            InfoDetails_EN.Text = "";
            InfoDetails_RU.Text = "";
            ddlMainCategory.SelectedValue = "0";
            ddlFieldName.SelectedValue = "0";
            //chlist.ClearSelection();
            //chQisa.ClearSelection();
            //chAciqlama.ClearSelection();
            //chSlide.ClearSelection();
            //chQisaAcQapa.ClearSelection();
            //chAciqlamaAcQapa.ClearSelection();
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

    protected void ddltable_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetFields(ddltable.SelectedValue.ToString());
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
            SqlCommand cmd = new SqlCommand(@"Insert into Slides (SlideName_AZ, SlideName_EN, SlideName_RU, SlideURL_AZ,SlideURL_EN,SlideURL_RU, InfoID, TableName) Values(@SlideName_AZ, @SlideName_EN, @SlideName_RU, @SlideURL_AZ,@SlideURL_EN,@SlideURL_RU, @InfoID, @TableName)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("SlideName_AZ", txtSlideAZ.Text);
            cmd.Parameters.AddWithValue("SlideName_EN", txtSlideEN.Text);
            cmd.Parameters.AddWithValue("SlideName_RU", txtSlideRU.Text);
            cmd.Parameters.AddWithValue("SlideURL_AZ", fotoAZ);
            cmd.Parameters.AddWithValue("SlideURL_EN", fotoEN);
            cmd.Parameters.AddWithValue("SlideURL_RU", fotoRU);
            cmd.Parameters.AddWithValue("InfoID", Session["InfoID"].ToString());
            cmd.Parameters.AddWithValue("TableName", "INFO");
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetSlide(Session["InfoID"].ToString());
            Session["SlideID"] = 0;
            txtSlideAZ.Text = "";
            txtSlideEN.Text = "";
            txtSlideRU.Text = "";
            imgAZ.ImageUrl = "";
            imgEN.ImageUrl = "";
            imgRU.ImageUrl = "";
            UPFotoAZ.SaveAs(Server.MapPath(@"..\") + fotoAZ);
            UPFotoEN.SaveAs(Server.MapPath(@"..\") + fotoEN);
            UPFotoRU.SaveAs(Server.MapPath(@"..\") + fotoRU);
        }
        else if (Session["SlideID"].ToString() != "0")
        {
            if (Session["fotonameAZ"].ToString().Trim() == "")
            {
                fotoAZ= @"Slide\" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_sss") + "_AZ.jpg";
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
            SqlCommand cmd = new SqlCommand(@"Update Slides set SlideName_AZ=@SlideName_AZ, SlideName_EN=@SlideName_EN, SlideName_RU=@SlideName_RU, SlideURL_AZ=@SlideURL_AZ, SlideURL_EN=@SlideURL_EN, SlideURL_RU=@SlideURL_RU where SlideID=@SlideID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("SlideName_AZ", txtSlideAZ.Text);
            cmd.Parameters.AddWithValue("SlideName_EN", txtSlideEN.Text);
            cmd.Parameters.AddWithValue("SlideName_RU", txtSlideRU.Text);
            cmd.Parameters.AddWithValue("SlideURL_AZ", fotoAZ);
            cmd.Parameters.AddWithValue("SlideURL_EN", fotoEN);
            cmd.Parameters.AddWithValue("SlideURL_RU", fotoRU);
            cmd.Parameters.AddWithValue("SlideID", Session["SlideID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetSlide(Session["InfoID"].ToString());
            Session["SlideID"] = 0;
            txtSlideAZ.Text = "";
            txtSlideEN.Text = "";
            txtSlideRU.Text = "";
            imgAZ.ImageUrl = "";
            imgEN.ImageUrl = "";
            imgRU.ImageUrl = "";
            Session["fotonameAZ"] = "";
            Session["fotonameEN"] = "";
            Session["fotonameRU"] = "";
            if (UPFotoAZ.HasFile)
            {
                UPFotoAZ.SaveAs(Server.MapPath(@"..\") + fotoAZ);
            }
            if (UPFotoEN.HasFile)
            {
                UPFotoEN.SaveAs(Server.MapPath(@"..\") + fotoEN);
            }
            if (UPFotoRU.HasFile)
            {
                UPFotoRU.SaveAs(Server.MapPath(@"..\") + fotoRU);
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal1();", true);

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

                imgAZ.ImageUrl = "../"+dr["SlideURL_AZ"].ToString();
                imgEN.ImageUrl = "../" + dr["SlideURL_EN"].ToString();
                imgRU.ImageUrl = "../" + dr["SlideURL_RU"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal1();", true);
            }
        } else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand(@"Delete Slides where SlideID="+e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetSlide(Session["InfoID"].ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal1();", true);
        }
    }
}
