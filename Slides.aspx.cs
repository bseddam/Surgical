using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Slides : System.Web.UI.Page
{
    Methods db = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        int mainid = Page.RouteData.Values["mainid"].ToParseInt();
        int organid = Page.RouteData.Values["organid"].ToParseInt();
        int categoryid = Page.RouteData.Values["categoryid"].ToParseInt();
        int headerid = Page.RouteData.Values["headerid"].ToParseInt();
        string lang = Config.getLang(Page);
        DataTable dthead = db.GetHeaders(lang, 1, 7);
        if (dthead.Rows.Count > 0)
        {
            ltrlslide.Text = dthead.Rows[0]["Name"].ToParseStr();
        }

        //ltrladi.Text = db.GetMenuHeader(lang, 16).Rows[0]["Name"].ToParseStr();
        ltrlorgan.Text = db.GetMenuHeader(lang, 17).Rows[0]["Name"].ToParseStr();
        lrtlkurs.Text = db.GetMenuHeader(lang, 18).Rows[0]["Name"].ToParseStr();
        //ltrlvideo.Text = db.GetMenuHeader(lang, 19).Rows[0]["Name"].ToParseStr();
        ltrlmuellif.Text = db.GetHeaders(lang, 1, 11).Rows[0]["Name"].ToParseStr();
        //ltrlmain.Text = db.GetMainByID(lang, mainid).Rows[0]["Name"].ToParseStr();

        ltrlorqan.Text = db.GetOrganByID(lang, organid).Rows[0]["Name"].ToParseStr();



        DataTable dtlecture = db.GetLectures(lang, mainid);


        //ltrllecture.Text = dtlecture.Rows[0]["LectureName"].ToParseStr();
        ltrlcourse.Text = dtlecture.Rows[0]["Kurs"].ToParseStr();
        //ltrlvideo1.Text = dtlecture.Rows[0]["VideoURL"].ToParseStr();


        string author = "";
        DataTable dtauthors = db.GetAuthors(lang, mainid);
        foreach (DataRow drauthor in dtauthors.Rows)
        {
            author = author + "<p>" + drauthor["tamadi"].ToParseStr() + "</p>";
        }
        ltrlmuellif1.Text = author;
    }
}