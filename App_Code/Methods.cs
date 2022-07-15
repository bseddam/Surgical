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

    public DataTable getDT(string sql)
    {
        try
        {
            SqlConn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, SqlConn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            SqlConn.Close();

            return dt;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sql + ")");
        }
    }

    public DataTable getDTCMD(SqlCommand sql)
    {
        try
        {
            SqlConn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            SqlConn.Close();

            return dt;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sql + ")");
        }
    }
    public string getfooternote()
    {
        string a = "Qeyd: <b style='font - size:18px; '>*</b> ilə qeyd olunan xanalar mütləq doldurulmalıdır.";
        return a;
    }

    public static void MsgBox(string mstx, Page P)
    {
        P.ClientScript.RegisterClientScriptBlock(P.GetType(), "PopupScript", "window.focus(); alert('" + mstx + "');", true);
    }



    public DataTable GetInformationByMainID(string lang,int mainid)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select InfoID,MainID,FieldNamesID,SortBy,InsertTime,UpdateTime,
convert(nvarchar,UpdateTime,104) UpdateTime104,InfoShort_" + lang + " as InfoShortName,InfoDetails_" + lang + 
" as InfoDetailsName,isnull(ViewCount,0) ViewCount FROM Informations where mainid=@mainid order by SortBy", SqlConn);
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
            SqlDataAdapter da = new SqlDataAdapter(@"select HeaderID,LnkURL,HeaderName_" + lang + 
                " as Name FROM Headers order by SortBy", SqlConn);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetHeaders(string lang, int typeid)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select HeaderID,LnkURL,HeaderName_" + lang +
                " as Name from Headers where typeid=@typeid order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@typeid", typeid);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetHeaders(string lang, int typeid,int headerid)
    {
        //try
        //{

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select HeaderID,LnkURL,HeaderName_" + lang +
                " as Name FROM Headers where typeid=@typeid and headerid=@headerid  order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@typeid", typeid);
            da.SelectCommand.Parameters.AddWithValue("@headerid", headerid);
            da.Fill(dt);
            return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
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


    public DataTable GetHeadersLeftMenu(string lang, int typeid)
    {
        //try
        //{
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select  MenuHeaderID,MenuHeaderName_" +
                lang + " as Name,MenuURL from MenuHeader where typeid=@typeid  order by SortBy", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@typeid", typeid);
            da.Fill(dt);
            return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
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
                lang + " as Name,SUBSTRING(CategoryName_" +
                lang + ",1,len(CategoryName_" +
                lang + ")-1) as Name1,Link " +
                "FROM Category order by SortBy", SqlConn);
           
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
            SqlDataAdapter da = new SqlDataAdapter(@"select  MainID,MainName_" +
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
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  MainID,MainName_" + lang + " as Name,Information_" +
              lang + @" as Information,DOI,URL
      ,SortBy FROM Main where MainID=@MainID order by SortBy", SqlConn);
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
            SqlDataAdapter da = new SqlDataAdapter(@"select distinct TableHeaderID,TableHeader_" +lang + 
                @" as Name,thsortby FROM allcolumn where CategoryID=@CategoryID and OrganID=@OrganID and 
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



    public DataTable GetKateqory(string lang, int CategoryID, int OrganID, int MainID, int HeaderID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select TableHeader_" + lang +
                @" as Name,thsortby FROM Kateqoriya where CategoryID=@CategoryID and OrganID=@OrganID and 
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
            SqlDataAdapter da = new SqlDataAdapter(@"select Slide_Name_" + lang + " Slide_Name,Short_Name_" + lang+ 
" Short_Name,Detail_Name_" + lang +" Detail_Name,InfoID,Adi_" + lang + @" as Name,InfoShort_" +lang + @" ShortName,
InfoDetails_" +lang + @" DetailName,case when a.Short=0 then 'display:none;' else '' end Short,
case when a.Detail=0 then 'display:none;' else '' end Detail,
case when a.Slide=0 then 'display:none;' else '' end Slide,
case when a.ShortView=0 then 'collapse_btn' else '' end ShortViewbtn,
case when a.ShortView=0 then 'collapse_content' else '' end ShortViewpnl,
case when a.DetailView=0 then 'collapse_btn' else '' end DetailViewbtn,
case when a.DetailView=0 then 'collapse_content' else '' end DetailViewpnl,TableHeaderID 
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
            string filter = "";
            if(CategoryID != 0)
            {
                filter = filter + " and a.CategoryID=@CategoryID";
            }

            if (OrganID != 0)
            {
                filter = filter + " and a.OrganID=@OrganID";
            }
            if (MainID != 0)
            {
                filter = filter + " and a.MainID=@MainID";
            }
            if (HeaderID != 0)
            {
                filter = filter + " and a.HeaderID=@HeaderID";
            }


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select upper(replace(OrganName_"+lang + @"  +' '+CategoryName_"+lang
                + @" ,'i',N'İ')) orqcat,a.infoid, a.HeaderID,HeaderName_"+lang + @"  HeaderName,a.MainID,MainName_"+lang + @"  MainName,
a.OrganID,a.CategoryID,a.headercolor,convert(nvarchar(300),InfoDetails_"+lang + @" ) InfoDetails from allcolumn a inner join (
select min(infoid) infoid, a.HeaderID,HeaderName_"+lang + @"  HeaderName,a.MainID,MainName_"+lang + @"  MainName,
OrganID,CategoryID,headercolor from allcolumn a 
group by a.HeaderID,HeaderName_"+lang + @" ,a.MainID,MainName_"+lang + @" ,
OrganID,CategoryID,headercolor) kk on kk.infoid=a.InfoID and kk.MainID=a.MainID and kk.HeaderID=a.HeaderID
where 1=1 "+filter+@"
order by a.MainID,a.HeaderID", SqlConn);
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



    public DataTable GetSlides(string lang, int InfoID, string TableName)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select SlideID,SlideName_" + lang + @" Name,SlideURL_" + lang + @" SlideURL,
InfoID,TableName from Slides where InfoID=@InfoID and TableName=@TableName", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@InfoID", InfoID);
            da.SelectCommand.Parameters.AddWithValue("@TableName", TableName);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetAuthorsQeustions(string lang, int QuestionID)
    {
        //try
        //{
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select isnull(a.AuthorName_" + lang + @",'')+isnull(' '+a.AuthorFName_" + lang + @",'')+
case when a.Gender=1 and AuthorFName_" + lang + @" is not null then N' oğlu ' 
when a.Gender=2 and AuthorFName_" + lang + @" is not null then N' qızı ' 
else ' ' end + isnull(a.AuthorSurName_" + lang + @",'') + isnull(' - '+Position_" + lang + @",'') tamadi
from ConnAuthorAll ca inner join authors a on ca.AuthorsID=a.AuthorID 
inner join Questions q on q.QuestionID=ca.tableid where q.QuestionID=@QuestionID and TableName=N'Questions' ", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@QuestionID", QuestionID);
  
            da.Fill(dt);
            return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }

    public DataTable GetAuthorsLecture(string lang, int LectureID)
    {
        //try
        //{
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(@"select isnull(a.AuthorName_" + lang + @",'')+isnull(' '+a.AuthorFName_" + lang + @",'')+
case when a.Gender=1 and AuthorFName_" + lang + @" is not null then N' oğlu ' 
when a.Gender=2 and AuthorFName_" + lang + @" is not null then N' qızı ' 
else ' ' end + isnull(a.AuthorSurName_" + lang + @",'') + isnull(' - '+Position_" + lang + @",'') tamadi
from ConnAuthorAll ca inner join authors a on ca.AuthorsID=a.AuthorID 
inner join Lectures l on l.LectureID=ca.tableid where l.LectureID=@LectureID and TableName=N'Mühazirə' ", SqlConn);
        da.SelectCommand.Parameters.AddWithValue("@LectureID", LectureID);
        da.Fill(dt);
        return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }



    public DataTable GetAuthorsMyExprerience(string lang, int MenimTecrubemID)
    {
        //try
        //{
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(@"select isnull(a.AuthorName_" + lang + @",'')+isnull(' '+a.AuthorFName_" + lang + @",'')+
case when a.Gender=1 and AuthorFName_" + lang + @" is not null then N' oğlu ' 
when a.Gender=2 and AuthorFName_" + lang + @" is not null then N' qızı ' 
else ' ' end + isnull(a.AuthorSurName_" + lang + @",'') + isnull(' - '+Position_" + lang + @",'') tamadi
from ConnAuthorAll ca inner join authors a on ca.AuthorsID=a.AuthorID 
inner join MenimTecrubem m on m.MenimTecrubemID=ca.tableid where m.MenimTecrubemID=1 and TableName=N'MenimTecrubem' ", SqlConn);
        da.SelectCommand.Parameters.AddWithValue("@MenimTecrubemID", MenimTecrubemID);
        da.Fill(dt);
        return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }


    public DataTable GetAuthors(string lang,int MainID)
    {
        //try
        //{
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(@"select isnull(a.AuthorName_" + lang + @",'')+isnull(' '+a.AuthorFName_" + lang + @",'')+
case when a.Gender=1 and AuthorFName_" + lang + @" is not null then N' oğlu ' 
when a.Gender=2 and AuthorFName_" + lang + @" is not null then N' qızı ' 
else ' ' end + isnull(a.AuthorSurName_" + lang + @",'') + isnull(' - '+Position_" + lang + @",'') tamadi
from ConnAuthorAll ca inner join authors a on ca.AuthorsID=a.AuthorID 
left join Questions q on q.QuestionID=ca.tableid left join Lectures l on l.LectureID=ca.tableid
where (ca.TableName=N'Questions' or ca.TableName=N'Mühazirə' or ca.TableName=N'MenimTecrubem' ) 
and q.MainID=@MainID and l.MainID=@MainID", SqlConn);
        da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
        da.Fill(dt);
        return dt;
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }


//    public DataTable GetAuthorsSlide(string lang, int SlideID)
//    {
//        //try
//        //{
//        DataTable dt = new DataTable();
//        SqlDataAdapter da = new SqlDataAdapter(@"select isnull(a.AuthorName_" + lang + @",'')+isnull(' '+a.AuthorFName_" + lang + @",'')+
//case when a.Gender=1 and AuthorFName_" + lang + @" is not null then N' oğlu ' 
//when a.Gender=2 and AuthorFName_" + lang + @" is not null then N' qızı ' 
//else ' ' end + isnull(a.AuthorSurName_" + lang + @",'') + isnull(' - '+Position_" + lang + @",'') tamadi
//from ConnAuthorAll ca inner join authors a on ca.AuthorsID=a.AuthorID 
//inner join Slides s on s.SlideID=ca.tableid where s.SlideID=@SlideID and ca.TableName=N'Slide' ", SqlConn);
//        da.SelectCommand.Parameters.AddWithValue("@SlideID", SlideID);

//        da.Fill(dt);
//        return dt;
//        //}
//        //catch (Exception ex)
//        //{
//        //    return null;
//        //}
//    }



    public static string GetURL(string lang, string pagename, int organid, int categoryid, int mainid, int headerid)
    {
        string geturl = "";

        try
        {
           
                geturl = string.Format("/{0}/{1}/{2}/{3}/{4}/{5}", lang, pagename, organid, categoryid, mainid, headerid);
         
        }
        catch (Exception ex)
        {
         
        }
        return geturl;

    }

    public DataTable GetAbout(string lang)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select AboutID,About" + lang +@" Name from About", SqlConn);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public DataTable GetContact(string lang)
    {
        try
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select  ContactID,Contact" + lang + @" Name from Contact", SqlConn);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataTable GetQuestions(string lang, int MainID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"
SELECT  QuestionID,MainID,QuestionTypeID,QuestionText_" + lang +@" as QuestionText ,AnswerText_" + lang +@" as AnswerText,ValidAnswer_" + lang +
    @" as ValidAnswer,DetailsText_" + lang + @" as DetailsText FROM Questions where MainID=@MainID order by sortby", SqlConn);
            
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetLectures(string lang, int MainID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select LectureID,LectureName,MainID,Kurs,VideoURL_" + lang + @" VideoURL,SortBy
  FROM Lectures where MainID=@MainID", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetMyExperinces(string lang, int MainID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select  MenimTecrubemID
      ,MenimTecrubemName" + lang + @" MenimTecrubemName,MainID
      ,MenimTecrubem" + lang + @" MenimTecrubem from MenimTecrubem where MainID=@MainID", SqlConn);
            da.SelectCommand.Parameters.AddWithValue("@MainID", MainID);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable GetEndoskopiya(string lang, int MainID)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select EndoskopiyaID,EndoskopiyaName" + lang + @" EndoskopiyaName,
MainID,MuayineUsulu" + lang + @" MuayineUsulu,Video" + lang + @" Video
  FROM Endoskopiya where MainID=@MainID", SqlConn);
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