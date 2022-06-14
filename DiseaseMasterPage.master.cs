using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DiseaseMasterPage : System.Web.UI.MasterPage
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
        string lang = Config.getLang(Page);

        ltrlmainpage.Text = db.GetMenuHeader(lang, 8).Rows[0]["Name"].ToParseStr();

        ltrlorgancategory1.Text = ltrlorgancategory.Text = db.GetOrganByID(lang, organid).Rows[0]["Name"].ToParseStr() + ' ' +
            db.GetCateqoryByID(lang, categoryid).Rows[0]["Name"].ToParseStr();
        ltrlmain.Text = db.GetMainByID(lang, mainid).Rows[0]["Name"].ToParseStr();
       

        //ltrtlupdate.Text = db.GetMenuHeader(lang, 9).Rows[0]["Name"].ToParseStr() + ": " +
        //    db.GetInformationByMainID(lang, mainid).Rows[0]["UpdateTime104"].ToParseStr();

        //lrtlviewcount.Text = db.GetInformationByMainID(lang, mainid).Rows[0]["ViewCount"].ToParseStr();
        lrtlviewcount.Text = "0";


        ltrlshare.Text = db.GetMenuHeader(lang, 10).Rows[0]["Name"].ToParseStr();
        ltrlprint.Text = db.GetMenuHeader(lang, 11).Rows[0]["Name"].ToParseStr();
       
        DataTable dtleft =  db.GetMain(lang, organid, categoryid);

        foreach (DataRow item in dtleft.Rows)
        {
            string linkurl = db.GetURL(lang, "liverdisease", organid.ToParseInt(), categoryid.ToParseInt(),
                item["MainID"].ToParseInt(),0);


            string active = "";
            if (linkurl == db.GetURL(lang, "leadership", organid.ToParseInt(), categoryid.ToParseInt(),
                mainid.ToParseInt(), 0))
            {
                active = "active";
            }

            ltrlleftmenu.Text = ltrlleftmenu.Text + @" <li class='"+ active + @"'>
                                                    <a href='"+ linkurl + @"'>
                                                        " + item["Name"].ToParseStr() + @"
                                                    </a>
                                                </li>";

        }

    }
}
