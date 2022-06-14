<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        System.Web.Routing.RouteCollection routes = System.Web.Routing.RouteTable.Routes;
        routes.MapPageRoute("home", "{lang}/home", "~/Default.aspx");

        routes.MapPageRoute("leadership", "{lang}/leadership/{organid}/{categoryid}/{mainid}/{headerid}", "~/leadership.aspx");
      
        routes.MapPageRoute("alloperations", "{lang}/alloperations/{organid}/{categoryid}/{mainid}/{headerid}", "~/all_operations.aspx");
        routes.MapPageRoute("liverdisease", "{lang}/liverdisease/{organid}/{categoryid}/{mainid}", "~/liverdisease.aspx");

        //routes.MapPageRoute("leadership", "{lang}/leadership/{mainid}/{headerid}", "~/leadership.aspx");
        //routes.MapPageRoute("leadershipOptional", "leadership/{mainid}/{headerid}", "~/leadership.aspx");


    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
