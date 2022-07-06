using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;



    public partial class Login : System.Web.UI.Page
    {
    Methods clSsql = new Methods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        Session["UsersID"] = null;
        //Response.Write(Config.Sha1(PassText.Text.ToString()));
        //return;
        try
            {
                Methods clSsql = new Methods();
                SqlCommand cmd = new SqlCommand("Select * from UsersTB where Login_name=@Login_name and Passvord=@Passvord", Methods.SqlConn);
                cmd.Parameters.AddWithValue("Login_name", EmailText.Text.ToString());
                cmd.Parameters.AddWithValue("Passvord", Config.Sha1(PassText.Text.ToString()));
            Methods.SqlConn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
            Methods.SqlConn.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["UsersID"] = int.Parse(dt.Rows[0][0].ToString());
                Response.Redirect("UserMain.aspx");
                //Session["ElmiMuessiseID"] = int.Parse(dt.Rows[0][3].ToString());
                // DataTable dtshexsiprofil = clSsql.getDT("select * from TbShexsiProfil where UsersID=" + Session["UsersID"].ToString());
                //if (dtshexsiprofil.Rows.Count > 0)
                //{
                //Session["PersonalProfilID"] = dtshexsiprofil.Rows[0][0].ToString();
                //Session["PersonalTesdiq"] = dtshexsiprofil.Rows[0]["Tesdiq"].ToString();
                //Session["UsersName"] = dtshexsiprofil.Rows[0][1].ToString() + " " + dtshexsiprofil.Rows[0][2].ToString();
                //Session["UsersNameMuellif"] = dtshexsiprofil.Rows[0][1].ToString() + " " + dtshexsiprofil.Rows[0][2].ToString() + " " + dtshexsiprofil.Rows[0][3].ToString();
                //Session["Foto"] = dtshexsiprofil.Rows[0][8].ToString();

                //}
            }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message + "(" + ex.Message + ")");
            }
            //catch
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            Response.Redirect("UserMain.aspx");
        }
    }
