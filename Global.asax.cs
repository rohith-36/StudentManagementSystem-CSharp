using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            // Log error here
            // Response.Redirect("/Error");
        }
    }
}
