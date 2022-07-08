using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChildMasterPage : System.Web.UI.MasterPage
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
        ltrlmainpage.Text = db.GetMenuHeader(lang, 8).Rows[0]["Name"].ToParseStr();
        DataTable dtorgan = db.GetOrganByID(lang, organid);
        DataTable dtcateqory = db.GetCateqoryByID(lang, categoryid);
        if (dtorgan.Rows.Count > 0 && dtcateqory.Rows.Count>0)
        {
            ltrlorgancategory.Text = dtorgan.Rows[0]["Name"].ToParseStr() + ' ' +
            dtcateqory.Rows[0]["Name"].ToParseStr();
        }

        DataTable dtmain = db.GetMainByID(lang, mainid);
        if (dtmain.Rows.Count > 0)
        {
            ltrlmain1.Text = ltrlmain.Text = dtmain.Rows[0]["Name"].ToParseStr();
        }
        DataTable dtheader = db.GetHeaderByID(lang, headerid);
        if (dtheader.Rows.Count > 0)
        {
            ltrlheader.Text = dtheader.Rows[0]["Name"].ToParseStr();
        }
        lrtlviewcount.Text = "0";
        DataTable dtInformationByMainID = db.GetInformationByMainID(lang, mainid);
        if (dtInformationByMainID.Rows.Count != 0)
        {
            ltrtlupdate.Text = db.GetMenuHeader(lang, 9).Rows[0]["Name"].ToParseStr() + ": " +
                dtInformationByMainID.Rows[0]["UpdateTime104"].ToParseStr();

            lrtlviewcount.Text = dtInformationByMainID.Rows[0]["ViewCount"].ToParseStr();
        }


        ltrlshare.Text = db.GetMenuHeader(lang, 10).Rows[0]["Name"].ToParseStr();
        ltrlprint.Text = db.GetMenuHeader(lang, 11).Rows[0]["Name"].ToParseStr();
       
        DataTable dtleft = db.GetHeaders(lang,1);
        
        rptHeaderMenu.DataSource = dtleft;
        rptHeaderMenu.DataBind();
      

    }
}