using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Data.SqlClient;


public class Methods
{
    public static SqlConnection SqlConn
    {
        get { return new SqlConnection(@"Data Source=sql5102.site4now.net;Initial Catalog=db_a85441_elvinismayilov;User Id=db_a85441_elvinismayilov_admin;Password=Surgical2022;"); }
    }
    
    public DataTable GetInformationByMainID(string lang,int mainid)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select 
InfoID,MainID,FieldNamesID,SortBy,InsertTime,UpdateTime,convert(nvarchar,UpdateTime,104) UpdateTime104,InfoShort_" +
                lang + " as InfoShortName,InfoDetails_" +
                lang + " as InfoDetailsName,isnull(ViewCount,0) ViewCount FROM Informations where mainid=@mainid order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@mainid", mainid);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetMenuHeader(string lang, int typeid)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  MenuHeaderID,MenuHeaderName_" + 
                lang + " as Name,MenuURL FROM MenuHeader where typeid=@typeid  order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@typeid", typeid);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetHeaders(string lang)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select HeaderID,LnkURL,HeaderName_" 
+ lang + " as Name FROM Headers order by SortBy", SqlConn);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetHeaderByID(string lang,int HeaderID)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select HeaderID,LnkURL,HeaderName_"
+ lang + " as Name FROM Headers where HeaderID=@HeaderID order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@HeaderID", HeaderID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetHeadersLeftMenu(string lang, int mainid)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select * from 
(select distinct HeaderID,LnkURL,HeaderName_"
+ lang + @" as Name,hSortBy FROM allcolumn where mainid=@mainid) as k order by hSortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@mainid", mainid);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetTableHeader(string lang, int mainid,int headerid)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select * from 
(select distinct  TableHeaderID,HeaderID,TableHeader_" + lang +
@" as Name,thSortBy FROM allcolumn where mainid=@mainid and headerid=@headerid) as k order by thSortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@mainid", mainid);
            da.SelectCommand.Parameters.AddWithValue("@headerid", headerid);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetCateqory(string lang)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CategoryID,CategoryName_" +
                lang + " as Name FROM Category order by SortBy", SqlConn);
           
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetCateqoryByID(string lang,int CategoryID)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CategoryID,CategoryName_" +
                lang + " as Name FROM Category where CategoryID=@CategoryID order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetOrgans(string lang)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  OrganID,OrganName_" +
                lang + " as Name FROM Organs order by SortBy", SqlConn);

            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetOrganByID(string lang,int OrganID)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  OrganID,OrganName_" +
                lang + " as Name FROM Organs where OrganID=@OrganID order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@OrganID", OrganID);
          
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetMain(string lang,int OrganID, int CategoryID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  MainID,MainName_" +
              lang + " as Name FROM Main where organid=@organid and CategoryID=@CategoryID order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@OrganID", OrganID);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetMainByID(string lang, int MainID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  MainID,MainName_" +
              lang + " as Name FROM Main where MainID=@MainID order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetLeadershipHeader(string lang,int CategoryID,int OrganID,int MainID,int HeaderID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select distinct TableHeaderID,TableHeader_" +lang + @" as Name,thsortby FROM allcolumn where CategoryID=@CategoryID and OrganID=@OrganID and 
HeaderID=@HeaderID and MainID=@MainID order by thsortby", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@OrganID", OrganID);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            da.SelectCommand.Parameters.AddWithValue("@HeaderID", HeaderID);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }





    public DataTable GetShortDetails(string lang,int CategoryID,int OrganID,int MainID,int HeaderID,int TableHeaderID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Slide_Name_" + lang + " Slide_Name,Short_Name_" + lang+ " Short_Name,Detail_Name_" + lang +
                " Detail_Name,Adi_" + lang + @" as Name,InfoShort_" +lang + @" ShortName,
InfoDetails_" +lang + @" DetailName,case when a.Short=0 then 'display:none;' else '' end Short,
case when a.Detail=0 then 'display:none;' else '' end Detail,
case when a.Slide=0 then 'display:none;' else '' end Slide,
case when a.ShortView=0 then '' else 'collapse_btn' end ShortViewbtn,
case when a.ShortView=0 then '' else 'collapse_content' end ShortViewpnl,
case when a.DetailView=0 then '' else 'collapse_btn' end DetailViewbtn,
case when a.DetailView=0 then '' else 'collapse_content' end DetailViewpnl,TableHeaderID 
FROM allcolumn a where CategoryID=@CategoryID and OrganID=@OrganID and 
HeaderID=@HeaderID and MainID=@MainID and TableHeaderID=@TableHeaderID order by thsortby,fSortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@OrganID", OrganID);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            da.SelectCommand.Parameters.AddWithValue("@HeaderID", HeaderID);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.SelectCommand.Parameters.AddWithValue("@TableHeaderID", TableHeaderID);

            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }



    public DataTable Getalloperations(string lang, int CategoryID, int OrganID, int MainID, int HeaderID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select OrganName_"+lang + @" +' '+CategoryName_"+lang + @"  orqcat,CategoryName_"+lang + @" ,OrganName_"+lang + @" ,ConnHeaderInformationID,FieldID,FieldNamesID,HeaderID,HeaderName_"+lang + @" ,InfoDetails_"+lang + @" ,InfoID
,InfoShort_"+lang + @",LnkURL,MainID,Short,Detail,Slide,ShortView,DetailView,iSortBy
,hSortBy,TableHeaderID,thSortBy,fSortBy,TableHeader_"+lang + @" ,MainName_"+lang + @" ,OrganID,CategoryID
,Information_"+lang + @" ,Patalogy_"+lang + @" ,Serishte_"+lang + @" ,Seviyye_"+lang + @" ,Seviyye_telebe_"+lang + @" ,Seviyye_rezident_"+lang + @" 
,Kurs,Saat,XBT_Kodu,Acar_sozler_"+lang + @" ,DOI,URL
  FROM allcolumn", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@OrganID", OrganID);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            da.SelectCommand.Parameters.AddWithValue("@HeaderID", HeaderID);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


}