using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
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
        //string qisa = db.GetMenuHeader(lang, 12).Rows[0]["Name"].ToParseStr();
        //string aciqlama = db.GetMenuHeader(lang, 13).Rows[0]["Name"].ToParseStr();
        //string slide = db.GetMenuHeader(lang, 14).Rows[0]["Name"].ToParseStr();


        //DataTable dtheader = db.GetLeadershipHeader(lang, categoryid, organid, mainid, headerid);

        
            
            ltrlcontainer.Text = @"<div class='section_body clearfix'>
                                    <div class='sect_header clearfix '>
                                        <h2 class='sect_title '>" + "Kateqoriya1" + @"</h2>
                                    </div>
                                    <div class='section_body clearfix'>
                                        
                                    <div class='odds_row '>
                                            <div class='odds_row '>
                                                <div class='content_row '>
                                                    <h2 class='title_first '>" + "Kateqoriya2" + @" </h2>
                                                </div>
                                            </div>
                                            <div class='odds_row '>
                                                <div class='content_row row_inner " + "Kateqoriya3" + @"' style='" + 
                                                "Kateqoriya4" + @"'>
                                                    <h3 class='title_second '>" + "Kateqoriya5" + @"</h3>
                                                    <div class='" + "Kateqoriya6" + @" '>
                                                        <div class='content_inner clearfix'>
                                                         <div class='conten_text '>
                                                            " + "Kateqoriya7" + @"
                                                         </div>
                                                       </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='odds_row '>
                                                <div class='content_row row_inner " + "Kateqoriya8" + @"' style='" + "Kateqoriya9" + @"'>
                                                    <h3 class='title_second '>" + "Kateqoriya10" + @"</h3>
                                                    <div class='" + "Kateqoriya11" + @" '>
                                                        <div class='content_inner clearfix'>
                                                            <div class='conten_text '>
                                                              " + "Kateqoriya12" + @"
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                              </div></div>";
      
    }
}