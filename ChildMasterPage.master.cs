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

        ltrlorgancategory.Text = db.GetOrganByID(lang, organid).Rows[0]["Name"].ToParseStr() + ' ' +
            db.GetCateqoryByID(lang, categoryid).Rows[0]["Name"].ToParseStr();
        ltrlmain1.Text=ltrlmain.Text = db.GetMainByID(lang, mainid).Rows[0]["Name"].ToParseStr();
        ltrlheader.Text = db.GetHeaderByID(lang, headerid).Rows[0]["Name"].ToParseStr();
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
            string linkurl= "/" + lang + "/leadership/" + organid.ToParseInt() + "/" + categoryid.ToParseInt() + "/"
        + mainid.ToParseInt() + "/" + item["HeaderID"].ToParseInt();

            string aa="";
               tableheader = db.GetTableHeader(lang, mainid, item["HeaderID"].ToParseInt());
            foreach (DataRow item1 in tableheader.Rows)
            {
                aa = aa + "<li><a href='"+ linkurl + "'> - " + item1["Name"].ToParseStr()+ @"</a></li >";
            }
           
//            ltrlleftmenu.Text = ltrlleftmenu.Text + @"
//<li class=''>
// <a href=' '>"+ item["Name"].ToParseStr() + @"</a>
//  <ul class='dropdown_menu'>

// " + aa + @"

//  </ul>
//</li>";



            ltrlleftmenu.Text = ltrlleftmenu.Text + @"
<li class='active'>
 <a href='"+ linkurl + @"'>" + item["Name"].ToParseStr() + @"</a>
  <ul class='dropdown_menu'>

 " + aa + @"

  </ul>
</li>";
        }
       
    }
}