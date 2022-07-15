using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reference : System.Web.UI.Page
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
            ltrlreference.Text = dthead.Rows[0]["Name"].ToParseStr();
        }
        ltrlmenbeadi.Text = db.GetMenuHeader(lang, 20).Rows[0]["Name"].ToParseStr();
        ltrldoi.Text = db.GetMenuHeader(lang, 21).Rows[0]["Name"].ToParseStr();
        ltrlurl.Text = db.GetMenuHeader(lang, 22).Rows[0]["Name"].ToParseStr();
        DataTable dtmain = db.GetMainByID(lang, mainid);
        if (dtmain.Rows.Count > 0)
        {
            ltrldoitext.Text = dtmain.Rows[0]["DOI"].ToParseStr();
            ltrlurltext.Text = dtmain.Rows[0]["URL"].ToParseStr();
        }

        string author = "";
        DataTable dtauthors = db.GetAuthors(lang, mainid);
        foreach (DataRow drauthor in dtauthors.Rows)
        {
            author = author + "<p>" + drauthor["tamadi"].ToParseStr() + "</p>";

            //author = author + @"  <tr>
            //                                                    <td style='width:40%'>
            //                                                        <strong>" + drauthor["tamadi"].ToParseStr() + @"</strong>
            //                                                    </td>
            //                                                    <td>
            //                                                      " + drauthor["vezife"].ToParseStr() + @"
            //                                                    </td>
            //                                                </tr>";
        }
        ltrlmuellif1.Text = author;
    }
}