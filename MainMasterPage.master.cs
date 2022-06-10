using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMasterPage : System.Web.UI.MasterPage
{
    Methods db = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
     
        
        if (IsPostBack)
        {
            return;
        }
        string lang = Config.getLang(Page);
        if (lang == "en")
        {
            ltrLink.Text = string.Format("<div class='lang_btn'>EN</div><ul class='langs'>" +
                "<li><a href='{0}'>AZ</a></li><li><a href='{1}'>RU</a> </li></ul>", getURL("az"), getURL("ru"));
        }
        else if (lang == "ru")
        {
            ltrLink.Text = string.Format("<div class='lang_btn'>RU</div><ul class='langs'>" +
                "<li><a href='{0}'>AZ</a></li><li><a href='{1}'>EN</a> </li></ul>", getURL("az"), getURL("en"));
        }
        else
        {
            ltrLink.Text = string.Format("<div class='lang_btn'>AZ</div><ul class='langs'>" +
                "<li><a href='{0}'>EN</a></li><li><a href='{1}'>RU</a> </li></ul>", getURL("en"), getURL("ru"));
        }

        DataTable dtHeader = db.GetMenuHeader(lang,1);
        rptHeaderMenu.DataSource = dtHeader;
        rptHeaderMenu.DataBind();


        DataTable dtright = db.GetHeaders(lang);
        rprightmenu.DataSource = dtright;
        rprightmenu.DataBind();


        ltrlsurcicalplatform.Text = db.GetMenuHeader(lang, 4).Rows[0]["Name"].ToParseStr();
        ltrlcopyright.Text= db.GetMenuHeader(lang, 6).Rows[0]["Name"].ToParseStr();
        txtsearchkeyword.Attributes.Add("placeholder", db.GetMenuHeader(lang, 5).Rows[0]["Name"].ToParseStr());
        txtsearchplatform.Attributes.Add("placeholder", db.GetMenuHeader(lang, 2).Rows[0]["Name"].ToParseStr());
        
        componentsload(lang);
    }
    void componentsload(string lang)
    {
        DataTable dt = db.GetCateqory(lang);
        ddlcateqory.DataValueField = "CategoryID";
        ddlcateqory.DataTextField = "Name";
        ddlcateqory.DataSource = dt;
        ddlcateqory.DataBind();
        ddlcateqory.Items.Insert(0, new ListItem(db.GetMenuHeader(lang, 7).Rows[0]["Name"].ToParseStr(), "-1"));
        ddlcateqory.SelectedIndex = 0;
        
        DataTable dt1 = db.GetOrgans(lang);
        ddlorgans.DataValueField = "OrganID";
        ddlorgans.DataTextField = "Name";
        ddlorgans.DataSource = dt1;
        ddlorgans.DataBind();
        ddlorgans.Items.Insert(0, new ListItem(db.GetMenuHeader(lang, 7).Rows[0]["Name"].ToParseStr(), "-1"));
        ddlorgans.SelectedIndex = 0;
       
    }

    void loadmain()
    {
        string lang = Config.getLang(Page);
        DataTable dt2 = db.GetMain(lang, ddlorgans.SelectedValue.ToParseInt(), ddlcateqory.SelectedValue.ToParseInt());
        ddlmain.DataValueField = "MainID";
        ddlmain.DataTextField = "Name";
        ddlmain.DataSource = dt2;
        ddlmain.DataBind();
        ddlmain.Items.Insert(0, new ListItem(db.GetMenuHeader(lang, 7).Rows[0]["Name"].ToParseStr(), "-1"));
        ddlmain.SelectedIndex = 0;
    }
    public string getURL(string lang)
    {
        string url = Request.Url.ToString();
        string result = "";
        if (url.IndexOf("/az/") > -1 || url.IndexOf("/en/") > -1 || url.IndexOf("/ru/") > -1)
        {
            result = url.Replace("/en/", "/" + lang + "/").Replace("/ru/", "/" + lang + "/").Replace("/az/", "/" + lang + "/");
        }
        
        return result;
    }

    protected void ddlcateqory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string lang = Config.getLang(Page);
        ltrlcateqory.Text = db.GetCateqoryByID(lang, ddlcateqory.SelectedValue.ToParseInt()).Rows[0]["Name"].ToParseStr();
        loadmain();
    }

    protected void ddlorgans_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadmain();
    }
}
