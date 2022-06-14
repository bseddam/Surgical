using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leadership : System.Web.UI.Page
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
        string slide = db.GetMenuHeader(lang, 14).Rows[0]["Name"].ToParseStr();


        DataTable dtheader = db.GetLeadershipHeader(lang, categoryid, organid, mainid, headerid);

        foreach (DataRow drheader in dtheader.Rows)
        {
            string shortdetail = "";
            DataTable dtshortdetail = db.GetShortDetails(lang, categoryid, organid, mainid, headerid, drheader["TableHeaderID"].ToParseInt());
            foreach (DataRow drshortdetails in dtshortdetail.Rows)
            {
                string slidetext = "";
                DataTable dtslides = db.GetSlides(lang, drshortdetails["InfoID"].ToParseInt());
                foreach (DataRow drslide in dtslides.Rows)
                {
                    slidetext = slidetext + @"<li data-responsive='/" + drslide["SlideURL"].ToParseStr() + @"' data-src='/" + drslide["SlideURL"].ToParseStr() + @"' data-sub-html=''>
                                                                        <a href=' '>
                                                                            <img src='/" + drslide["SlideURL"].ToParseStr() + @"' alt='' class='product_gallery_images_upload img-responsive'>
                                                                            <div class='demo-gallery-poster'>
                                                                                <img src='/img/icons/zoom.png'>
                                                                            </div>
                                                                        </a>
                                                                    </li>";
                }

                shortdetail = shortdetail + @"<div class='odds_row '>
                                            <div class='odds_row '>
                                                <div class='content_row '>
                                                    <h2 class='title_first '>" + drshortdetails["Name"].ToParseStr() + @" </h2>
                                                </div>
                                            </div>
                                            <div class='odds_row '>
                                                <div class='content_row row_inner " + drshortdetails["ShortViewbtn"].ToParseStr() + @"' style='" + drshortdetails["Short"].ToParseStr() + @"'>
                                                    <h3 class='title_second '>" + drshortdetails["Short_Name"].ToParseStr() + @"</h3>
                                                    <div class='" + drshortdetails["ShortViewpnl"].ToParseStr() + @" '>
                                                        <div class='content_inner clearfix'>
                                                         <div class='conten_text '>
                                                            " + drshortdetails["ShortName"].ToParseStr() + @"
                                                         </div>
                                                       </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='odds_row '>
                                                <div class='content_row row_inner " + drshortdetails["DetailViewbtn"].ToParseStr() + @"' style='" + drshortdetails["Detail"].ToParseStr() + @"'>
                                                    <h3 class='title_second '>" + drshortdetails["Detail_Name"].ToParseStr() + @"</h3>
                                                    <div class='" + drshortdetails["DetailViewpnl"].ToParseStr() + @" '>
                                                        <div class='content_inner clearfix'>
                                                            <div class='conten_text '>
                                                              " + drshortdetails["DetailName"].ToParseStr() + @"
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='odds_row '>
                                                <div class='content_row row_inner ' style='" + drshortdetails["Slide"].ToParseStr() + @"'>
                                                    <h3 class='title_second '>" + drshortdetails["Slide_Name"].ToParseStr() + @" </h3>
                                                    <div class='content_inner clearfix'>

                                                        <!-----------Gallery Start------------->
                                                        <div class='news_in_gallery'>

                                                            <div class='demo-gallery'>
                                                                <ul id='lightgallery' class='prosmotr_ul lightgallery'>
                                                                    "+slidetext+@"
                                                                   
                                                                    
                                                                </ul>
                                                            </div>

                                                        </div>
                                                        <!-----------Gallery End------------->

                                                    </div>
                                                </div>
                                            </div>
                                        </div>";
            }
            ltrlcontainer.Text = ltrlcontainer.Text + @"<div class='section_body clearfix'>
                                    <div class='sect_header clearfix '>
                                        <h2 class='sect_title '>" + drheader["Name"].ToParseStr() + @"</h2>
                                    </div>
                                    <div class='section_body clearfix'>
                                        "+ shortdetail +
                                 @" </div></div>";
        }
    }
}