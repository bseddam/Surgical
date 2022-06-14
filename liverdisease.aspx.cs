using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class liverdisease : System.Web.UI.Page
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
        
        ltrlmain.Text = db.GetMainByID(lang, mainid).Rows[0]["Name"].ToParseStr();
        ltrlcontainer.Text = db.GetMainByID(lang, mainid).Rows[0]["Information"].ToParseStr();

    }
}