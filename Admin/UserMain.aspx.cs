using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



    public partial class UserMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["PersonalProfilID"] == null || Session["UsersID"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            if (!Page.IsPostBack)
            {

            }
        }
    }
