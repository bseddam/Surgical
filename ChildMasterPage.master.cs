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
        DataTable tableheader;
        DataTable dtleft = db.GetHeadersLeftMenu(lang, mainid);
        
        foreach (DataRow item in dtleft.Rows)
        {
            string linkurl= Methods.GetURL(lang ,"leadership" , organid.ToParseInt() , categoryid.ToParseInt() ,
                mainid.ToParseInt() , item["HeaderID"].ToParseInt());

            string icmenu="";
               tableheader = db.GetTableHeader(lang, mainid, item["HeaderID"].ToParseInt());
            foreach (DataRow item1 in tableheader.Rows)
            {
                icmenu = icmenu + "<li><a href='"+ linkurl + "'> - " + item1["Name"].ToParseStr()+ @"</a></li >";
            }  

            string active="";
            if (linkurl == Methods.GetURL(lang, "leadership", organid.ToParseInt(), categoryid.ToParseInt(),
                mainid.ToParseInt(), headerid))
            {
                active = "active";
            }

            ltrlleftmenu.Text = ltrlleftmenu.Text + @"
<li class='"+ active + @"'>
 <a href='"+ linkurl + @"'>" + item["Name"].ToParseStr() + @"</a>
  <ul class='dropdown_menu'>
" + icmenu + @"
  </ul>
</li>";
        }
       
    }
}