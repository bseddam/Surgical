﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Methods db = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        //string lang = Config.getLang(Page);
        //DataTable dt = db.GetCateqory(lang);
        //rpcategory.DataSource = dt;
        //rpcategory.DataBind();
    }
    
}