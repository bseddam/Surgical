using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;




    public partial class Kateqoriya : System.Web.UI.Page
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
                txtPatalogyAZ.Text = dr["Patalogy_AZ"].ToString();
                txtPatalogyEN.Text = dr["Patalogy_EN"].ToString();
                txtPatalogyRU.Text = dr["Patalogy_RU"].ToString();
                txtSerishteAZ.Text = dr["Serishte_AZ"].ToString();
                txtSerishteEN.Text = dr["Serishte_EN"].ToString();
                txtSerishteRU.Text = dr["Serishte_RU"].ToString();
                txtSeviyyeAZ.Text = dr["Seviyye_AZ"].ToString();
                txtSeviyyeEN.Text = dr["Seviyye_EN"].ToString();
                txtSeviyyeRU.Text = dr["Seviyye_RU"].ToString();
                SeviyyeTelebeAZ.Text = dr["Seviyye_telebe_AZ"].ToString();
                SeviyyeTelebeEN.Text = dr["Seviyye_telebe_EN"].ToString();
                SeviyyeTelebeRU.Text = dr["Seviyye_telebe_RU"].ToString();
                SeviyyeRezidentAZ.Text = dr["Seviyye_rezident_AZ"].ToString();
                SeviyyeRezidentEN.Text = dr["Seviyye_rezident_EN"].ToString();
                SeviyyeRezidentRU.Text = dr["Seviyye_rezident_RU"].ToString();
                txtKurs.Text = dr["Kurs"].ToString();
                txtSaat.Text = dr["Saat"].ToString();
                txtXBTKodu.Text = dr["XBT_Kodu"].ToString();
                AcarSozlerAZ.Text = dr["Acar_sozler_AZ"].ToString();
                AcarSozlerEN.Text = dr["Acar_sozler_EN"].ToString();
                AcarSozlerRU.Text = dr["Acar_sozler_RU"].ToString();
                txtDOI.Text = dr["DOI"].ToString();
                txtURL.Text = dr["URL"].ToString();
                txtSortBy.Text = dr["SortBy"].ToString();
                Session["MainID"] = dr["MainID"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
            }
        }
        else if (e.CommandName == "Sil")
        {
            SqlCommand cmd = new SqlCommand("Delete from Main where MainID=" + e.CommandArgument.ToString(), Methods.SqlConn);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            GetMain();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
        {
        if (Session["MainID"].ToString() == "0")
        {
            SqlCommand cmd = new SqlCommand(@"Insert into Main Values(@MainName_AZ,@MainName_EN,@MainName_RU
                   ,@OrganID, @CategoryID, @Information_AZ, @Information_EN, @Information_RU, @Patalogy_AZ, @Patalogy_EN, @Patalogy_RU, @Serishte_AZ, @Serishte_EN, @Serishte_RU, @Seviyye_AZ, 
                  @Seviyye_EN, @Seviyye_RU, @Seviyye_telebe_AZ, @Seviyye_telebe_EN, @Seviyye_telebe_RU, @Seviyye_rezident_AZ, @Seviyye_rezident_EN, @Seviyye_rezident_RU, @Kurs, @Saat, @XBT_Kodu, @Acar_sozler_AZ, @Acar_sozler_EN, @Acar_sozler_RU, @DOI, 
                  @URL, @SortBy)", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainName_AZ", txtMainNameAZ.Text);
            cmd.Parameters.AddWithValue("MainName_EN", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("MainName_RU", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("OrganID", ddlorgan.SelectedValue);
            cmd.Parameters.AddWithValue("CategoryID", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("Information_AZ", txtInformationAZ.Text);
            cmd.Parameters.AddWithValue("Information_EN", txtInformationEN.Text);
            cmd.Parameters.AddWithValue("Information_RU", txtInformationRU.Text);
            cmd.Parameters.AddWithValue("Patalogy_AZ", txtPatalogyAZ.Text);
            cmd.Parameters.AddWithValue("Patalogy_EN", txtPatalogyEN.Text);
            cmd.Parameters.AddWithValue("Patalogy_RU", txtPatalogyRU.Text);
            cmd.Parameters.AddWithValue("Serishte_AZ", txtSerishteAZ.Text);
            cmd.Parameters.AddWithValue("Serishte_EN", txtSerishteEN.Text);
            cmd.Parameters.AddWithValue("Serishte_RU", txtSerishteRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_AZ", txtSeviyyeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_EN", txtSeviyyeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_RU", txtSeviyyeRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_AZ", SeviyyeTelebeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_EN", SeviyyeTelebeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_RU", SeviyyeTelebeRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_AZ", SeviyyeRezidentAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_EN", SeviyyeRezidentEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_RU", SeviyyeRezidentRU.Text);
            cmd.Parameters.AddWithValue("Kurs", txtKurs.Text);
            cmd.Parameters.AddWithValue("Saat", txtSaat.Text);
            cmd.Parameters.AddWithValue("XBT_Kodu", txtXBTKodu.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_AZ", AcarSozlerAZ.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_EN", AcarSozlerEN.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_RU", AcarSozlerRU.Text);
            cmd.Parameters.AddWithValue("DOI", txtDOI.Text);
            cmd.Parameters.AddWithValue("URL", txtURL.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            txtMainNameAZ.Text = "";
            txtMainNameEN.Text = "";
            txtMainNameRU.Text = "";
            txtInformationAZ.Text = "";
            txtInformationEN.Text = "";
            txtInformationRU.Text = "";
            txtPatalogyAZ.Text = "";
            txtPatalogyEN.Text = "";
            txtPatalogyRU.Text = "";
            txtSerishteAZ.Text = "";
            txtSerishteEN.Text = "";
            txtSerishteRU.Text = "";
            txtSeviyyeAZ.Text = "";
            txtSeviyyeEN.Text = "";
            txtSeviyyeRU.Text = "";
            SeviyyeTelebeAZ.Text = "";
            SeviyyeTelebeEN.Text = "";
            SeviyyeTelebeRU.Text = "";
            SeviyyeRezidentAZ.Text = "";
            SeviyyeRezidentEN.Text = "";
            SeviyyeRezidentRU.Text = "";
            txtKurs.Text = "";
            txtSaat.Text = "";
            txtXBTKodu.Text = "";
            AcarSozlerAZ.Text = "";
            AcarSozlerEN.Text = "";
            AcarSozlerRU.Text = "";
            txtDOI.Text = "";
            txtURL.Text = "";
            txtSortBy.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (Session["MainID"].ToString() != "0")
        {
            SqlCommand cmd = new SqlCommand(@"Update Main set MainName_AZ=@MainName_AZ,MainName_EN=@MainName_EN,MainName_RU=@MainName_RU
                   ,OrganID=@OrganID, CategoryID=@CategoryID, Information_AZ=@Information_AZ, Information_EN=@Information_EN, Information_RU=@Information_RU, Patalogy_AZ=@Patalogy_AZ, Patalogy_EN=@Patalogy_EN, Patalogy_RU=@Patalogy_RU, Serishte_AZ=@Serishte_AZ, Serishte_EN=@Serishte_EN, Serishte_RU=@Serishte_RU, Seviyye_AZ=@Seviyye_AZ, 
                  Seviyye_EN=@Seviyye_EN, Seviyye_RU=@Seviyye_RU, Seviyye_telebe_AZ=@Seviyye_telebe_AZ, Seviyye_telebe_EN=@Seviyye_telebe_EN, Seviyye_telebe_RU=@Seviyye_telebe_RU, Seviyye_rezident_AZ=@Seviyye_rezident_AZ, Seviyye_rezident_EN=@Seviyye_rezident_EN, Seviyye_rezident_RU=@Seviyye_rezident_RU, Kurs=@Kurs, Saat=@Saat, XBT_Kodu=@XBT_Kodu, Acar_sozler_AZ=@Acar_sozler_AZ, Acar_sozler_EN=@Acar_sozler_EN, Acar_sozler_RU=@Acar_sozler_RU, DOI=@DOI, 
                  URL=@URL, SortBy=@SortBy where MainID=@MainID", Methods.SqlConn);
            cmd.Parameters.AddWithValue("MainName_AZ", txtMainNameAZ.Text);
            cmd.Parameters.AddWithValue("MainName_EN", txtMainNameEN.Text);
            cmd.Parameters.AddWithValue("MainName_RU", txtMainNameRU.Text);
            cmd.Parameters.AddWithValue("OrganID", ddlorgan.SelectedValue);
            cmd.Parameters.AddWithValue("CategoryID", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("Information_AZ", txtInformationAZ.Text);
            cmd.Parameters.AddWithValue("Information_EN", txtInformationEN.Text);
            cmd.Parameters.AddWithValue("Information_RU", txtInformationRU.Text);
            cmd.Parameters.AddWithValue("Patalogy_AZ", txtPatalogyAZ.Text);
            cmd.Parameters.AddWithValue("Patalogy_EN", txtPatalogyEN.Text);
            cmd.Parameters.AddWithValue("Patalogy_RU", txtPatalogyRU.Text);
            cmd.Parameters.AddWithValue("Serishte_AZ", txtSerishteAZ.Text);
            cmd.Parameters.AddWithValue("Serishte_EN", txtSerishteEN.Text);
            cmd.Parameters.AddWithValue("Serishte_RU", txtSerishteRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_AZ", txtSeviyyeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_EN", txtSeviyyeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_RU", txtSeviyyeRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_AZ", SeviyyeTelebeAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_EN", SeviyyeTelebeEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_telebe_RU", SeviyyeTelebeRU.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_AZ", SeviyyeRezidentAZ.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_EN", SeviyyeRezidentEN.Text);
            cmd.Parameters.AddWithValue("Seviyye_rezident_RU", SeviyyeRezidentRU.Text);
            cmd.Parameters.AddWithValue("Kurs", txtKurs.Text);
            cmd.Parameters.AddWithValue("Saat", txtSaat.Text);
            cmd.Parameters.AddWithValue("XBT_Kodu", txtXBTKodu.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_AZ", AcarSozlerAZ.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_EN", AcarSozlerEN.Text);
            cmd.Parameters.AddWithValue("Acar_sozler_RU", AcarSozlerRU.Text);
            cmd.Parameters.AddWithValue("DOI", txtDOI.Text);
            cmd.Parameters.AddWithValue("URL", txtURL.Text);
            cmd.Parameters.AddWithValue("SortBy", txtSortBy.Text);
            cmd.Parameters.AddWithValue("MainID", Session["MainID"].ToString());
            Methods.SqlConn.Open();
            cmd.ExecuteNonQuery();
            Methods.SqlConn.Close();
            ddlCategory.SelectedIndex = 0;
            ddlorgan.SelectedIndex = 0;
            txtMainNameAZ.Text = "";
            txtMainNameEN.Text = "";
            txtMainNameRU.Text = "";
            txtInformationAZ.Text = "";
            txtInformationEN.Text = "";
            txtInformationRU.Text = "";
            txtPatalogyAZ.Text = "";
            txtPatalogyEN.Text = "";
            txtPatalogyRU.Text = "";
            txtSerishteAZ.Text = "";
            txtSerishteEN.Text = "";
            txtSerishteRU.Text = "";
            txtSeviyyeAZ.Text = "";
            txtSeviyyeEN.Text = "";
            txtSeviyyeRU.Text = "";
            SeviyyeTelebeAZ.Text = "";
            SeviyyeTelebeEN.Text = "";
            SeviyyeTelebeRU.Text = "";
            SeviyyeRezidentAZ.Text = "";
            SeviyyeRezidentEN.Text = "";
            SeviyyeRezidentRU.Text = "";
            txtKurs.Text = "";
            txtSaat.Text = "";
            txtXBTKodu.Text = "";
            AcarSozlerAZ.Text = "";
            AcarSozlerEN.Text = "";
            AcarSozlerRU.Text = "";
            txtDOI.Text = "";
            txtURL.Text = "";
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
        txtPatalogyAZ.Text = "";
        txtPatalogyEN.Text = "";
        txtPatalogyRU.Text = "";
        txtSerishteAZ.Text = "";
        txtSerishteEN.Text = "";
        txtSerishteRU.Text = "";
        txtSeviyyeAZ.Text = "";
        txtSeviyyeEN.Text = "";
        txtSeviyyeRU.Text = "";
        SeviyyeTelebeAZ.Text = "";
        SeviyyeTelebeEN.Text = "";
        SeviyyeTelebeRU.Text = "";
        SeviyyeRezidentAZ.Text = "";
        SeviyyeRezidentEN.Text = "";
        SeviyyeRezidentRU.Text = "";
        txtKurs.Text = "";
        txtSaat.Text = "";
        txtXBTKodu.Text = "";
        AcarSozlerAZ.Text = "";
        AcarSozlerEN.Text = "";
        AcarSozlerRU.Text = "";
        txtDOI.Text = "";
        txtURL.Text = "";
        txtSortBy.Text = "";
        Session["MainID"] = "0";
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }
    }
