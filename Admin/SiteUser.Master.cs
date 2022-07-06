using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;



public partial class SiteUser : System.Web.UI.MasterPage
{
    Methods clSsql = new Methods();
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //if (Session["PersonalProfilID"] == null || Session["UsersID"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["PersonalProfilID"] == null || Session["UsersID"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
      
//        if (!Page.IsPostBack)
//        {
//            lblbildirissay.Text = clSsql.getDT(@"Select count(*) say from TBBildiris b
//inner join UserAdmin ua on b.UserAdminID = ua.ID
//inner join TbElmiMuessise em on ua.ElmiMuessiseID = em.ID
//where SendType=1  and  b.ShexsiProfilID="+ Session["PersonalProfilID"].ToString()).Rows[0][0].ToString();
//            DataRow dr = clSsql.getDT("Select adi,qisaadi,HeadAdi from TbElmiMuessise where ID=" + Session["ElmiMuessiseID"].ToString()).Rows[0];
//            lbltamElmiMuesse.Text = dr[0].ToString();
//            lblqisaElmiMuesse.Text = dr[1].ToString();
//            lblUser.Text = Session["UsersName"].ToString();
//            if (Request.QueryString["p"] != null)
//            {
//                divheadinfo.Visible = true;
//                if (Request.QueryString["p"].ToString() == "1")
//                    lblheadInfo.Text = "Şəxsi məlumatlar";
//                else
//                if (Request.QueryString["p"].ToString() == "2")
//                    lblheadInfo.Text = "Təhsil";
//                else
//                if (Request.QueryString["p"].ToString() == "3")
//                    lblheadInfo.Text = "Elmi dərəcə";
//                else
//                if (Request.QueryString["p"].ToString() == "4")
//                    lblheadInfo.Text = "Elmi adlar";
//                else
//                if (Request.QueryString["p"].ToString() == "5")
//                    lblheadInfo.Text = "Elmi rütbəsi";
//                else
//                if (Request.QueryString["p"].ToString() == "6")
//                    lblheadInfo.Text = "Elmi məqalələr";
//                else
//                if (Request.QueryString["p"].ToString() == "7")
//                    lblheadInfo.Text = "Konfranslarda iştirak";
//                else
//                if (Request.QueryString["p"].ToString() == "8")
//                    lblheadInfo.Text = "Monoqrafiya, kitablar və b.";
//                else
//                if (Request.QueryString["p"].ToString() == "9")
//                    lblheadInfo.Text = "Dərsliklər və dərs vəsaitləri";
//                else
//                if (Request.QueryString["p"].ToString() == "10")
//                    lblheadInfo.Text = "Elmi ekspertiza fəaliyyəti";
//                else
//                //if (Request.QueryString["p"].ToString() == "11")
//                //    lblheadInfo1.Text = "Təşkilat komitəsinin (proqram komitəsinin) üzvü olduğu konfrans";
//                //else
//                if (Request.QueryString["p"].ToString() == "12")
//                    lblheadInfo.Text = "Patentlər və ixtiralar";
//                else
//                if (Request.QueryString["p"].ToString() == "13")
//                    lblheadInfo.Text = "Qrant layihələrində iştirak";
//                else
//                if (Request.QueryString["p"].ToString() == "14")
//                    lblheadInfo.Text = "Kadr hazırlığı";
//                else
//                if (Request.QueryString["p"].ToString() == "15")
//                    lblheadInfo.Text = "Qurumlarda Üzvülük";
//                else if (Request.QueryString["p"].ToString() == "16")
//                {
//                    lblheadInfo.Text = "Məlumatlara ümumi baxış";
//                }
//            }
//            else
//            {
//                divheadinfo.Visible = false;
//            }
//            int tesdiq = int.Parse(Session["PersonalTesdiq"].ToString());
//            if (tesdiq >= 1)
//            {
//                LinkButton1.Enabled = false;
//                LinkButton1.CssClass = "dropdown-toggle bg-green";
//                LinkButton1.Text = "Məlumat təsdiqlənib";
//            }
//            else
//            {
//                LinkButton1.Enabled = true;
//                LinkButton1.CssClass = "dropdown-toggle bg-red";
//            }
//            lblimgLogo.Text = "imgshexsi/" + Session["Foto"].ToString();
//        }

    }

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{ DataTable dt = clSsql.getDT("Select * from TbShexsiProfil where ad<>'' and Soyad<>'' and AtaAd<>'' and ID=" + Session["PersonalProfilID"].ToString());
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (Session["PersonalTesdiq"].ToString() == "0")
    //        {
    //            SqlCommand cmd = new SqlCommand("Update TbShexsiProfil set Tesdiq=1 where ID=" + Session["PersonalProfilID"].ToString(), clSsql.sqlconn);
    //            clSsql.sqlconn.Open();
    //            cmd.ExecuteNonQuery();
    //            clSsql.sqlconn.Close();
    //            Session["PersonalTesdiq"] = "1";
    //            ClSsql.MsgBox("Məlumat təsdiqləndi!", this.Page);
    //        }
    //    } else
    //    {
    //        ClSsql.MsgBox("Əsas şəxsi məlumatları daxil edin (Soyad, ad, ata adı)!", this.Page);
    //    }

    //}

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        divheadinfo.Visible = true;
        Response.Redirect("ReportPersonalProfil.aspx?p=16");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
