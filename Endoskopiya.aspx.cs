using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Endoskopiya : System.Web.UI.Page
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
        DataTable dthead = db.GetHeaders(lang, 1, 15);
        if (dthead.Rows.Count > 0)
        {
            ltrlendoskopiya.Text = dthead.Rows[0]["Name"].ToParseStr();
        }

        ltrladi.Text = db.GetMenuHeader(lang, 16).Rows[0]["Name"].ToParseStr();
        ltrlorgan.Text = db.GetMenuHeader(lang, 17).Rows[0]["Name"].ToParseStr();
        lrtlmuayineusulu.Text = db.GetMenuHeader(lang, 15).Rows[0]["Name"].ToParseStr();
        ltrlvideo.Text = db.GetMenuHeader(lang, 19).Rows[0]["Name"].ToParseStr();

        //ltrlmuellif.Text = db.GetMenuHeader(lang, 15).Rows[0]["Name"].ToParseStr();
        //ltrlmain.Text = db.GetMainByID(lang, mainid).Rows[0]["Name"].ToParseStr();

        ltrlorqan.Text = db.GetOrganByID(lang, organid).Rows[0]["Name"].ToParseStr();



        DataTable dtendoskopiya = db.GetEndoskopiya(lang, mainid);
        ltrlmuayine.Text = dtendoskopiya.Rows[0]["MuayineUsulu"].ToParseStr();

        ltrlendoscopiyaname.Text = dtendoskopiya.Rows[0]["EndoskopiyaName"].ToParseStr();
        //ltrlcourse.Text = dtlecture.Rows[0]["Kurs"].ToParseStr();
        ltrlvideo1.Text = dtendoskopiya.Rows[0]["Video"].ToParseStr();


        //string author = "";
        //DataTable dtauthors = db.GetAuthorsLecture(lang, dtlecture.Rows[0]["LectureID"].ToParseInt());
        //foreach (DataRow drauthor in dtauthors.Rows)
        //{
        //    author = author + "<p>" + drauthor["tamadi"].ToParseStr() + "</p>";
        //}
        //ltrlmuellif1.Text = author;
    }
}