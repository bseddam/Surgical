using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MyExperience : System.Web.UI.Page
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
        DataTable dthead = db.GetHeaders(lang, 1, 12);
        if (dthead.Rows.Count > 0)
        {
            ltrlmyexperience.Text = dthead.Rows[0]["Name"].ToParseStr();
        }
        ltrladi.Text = db.GetMenuHeader(lang, 16).Rows[0]["Name"].ToParseStr();
        ltrlmenimtecrubem.Text = db.GetHeaders(lang, 1, 19).Rows[0]["Name"].ToParseStr();

        DataTable dtmain = db.GetMyExperinces(lang, mainid);
        if (dtmain.Rows.Count > 0)
        {
            ltrladitext.Text = dtmain.Rows[0]["MenimTecrubemName"].ToParseStr();
            ltrlmenimtecrubemtext.Text = dtmain.Rows[0]["MenimTecrubem"].ToParseStr();
        }


        



        string author = "";
        DataTable dtauthors = db.GetAuthorsMyExprerience(lang, dtmain.Rows[0]["MenimTecrubemID"].ToParseInt());

       
        foreach (DataRow drauthor in dtauthors.Rows)
        {
            author = author + "<p>" + drauthor["tamadi"].ToParseStr() + "</p>";
        }
        ltrlmuellif1.Text = author;
    }
}