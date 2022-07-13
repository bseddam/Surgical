using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Questions : System.Web.UI.Page
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
        DataTable dthead = db.GetHeaders(lang, 1, 6);
        if (dthead.Rows.Count > 0)
        {
            ltrlquestion.Text = dthead.Rows[0]["Name"].ToParseStr();
        }

        string detailtext = db.GetMenuHeader(lang, 13).Rows[0]["Name"].ToParseStr();
        string authortext = db.GetHeaders(lang, 1, 11).Rows[0]["Name"].ToParseStr();


        DataTable dtquestion = db.GetQuestions(lang, mainid);
        foreach (DataRow drquestion in dtquestion.Rows)
        {

            string author = "";
            DataTable dtauthors = db.GetAuthorsQeustions(lang, drquestion["QuestionID"].ToParseInt());
            foreach (DataRow drauthor in dtauthors.Rows)
            {
                author = author + "<p>" + drauthor["tamadi"].ToParseStr() + "</p>";
            }

            ltrlcontainer.Text = ltrlcontainer.Text + @"<div class='odds_row '>
                                <div class='content_row '>
                                    <h3 class='title_second '>" + drquestion["QuestionText"].ToParseStr() + @"</h3>
                                </div>
                            </div>
                            <div class='odds_row '>
                                <div class='content_row row_inner '>
                                    <div class='content_inner clearfix'>
                                        <div class='conten_text '>
                                           " + drquestion["AnswerText"].ToParseStr() + @"
                                            <div class='odds_row '>
                                                <p>
                                                    <strong style='color: #7cb44e;'>" + detailtext + @"
                                                    </strong>
                                                </p>
                                                <p>
                                                    " + drquestion["DetailsText"].ToParseStr() + @"
                                                </p>
                                            </div>
                                            <div class='odds_row '>
                                                <h3 class='title_second '>" + authortext + @" </h3>
                                               " + author + @"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>";
        }
    }
}