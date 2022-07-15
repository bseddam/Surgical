using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Authors : System.Web.UI.Page
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
        DataTable dthead = db.GetHeaders(lang, 1, 11);
        if (dthead.Rows.Count > 0)
        {
            ltrlmuellif.Text = dthead.Rows[0]["Name"].ToParseStr();
        }

        

        ltrlmuellif.Text = db.GetHeaders(lang, 1, 11).Rows[0]["Name"].ToParseStr();

     

        string author = "";
        DataTable dtauthors = db.GetAuthors(lang);
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