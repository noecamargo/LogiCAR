
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LogiCAR.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            //filters.Add(new IdentityBasicAuthenticationAttribute());
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

      

    }
}
