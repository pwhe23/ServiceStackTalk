
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace GtdApp.Web
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			RegisterRoutes(RouteTable.Routes);
			new AppHost().Init();
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("api/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"}); //Prevent exceptions for favicon
			//WebApiConfig.Register(GlobalConfiguration.Configuration);
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (Request.IsLocal)
				ServiceStack.MiniProfiler.Profiler.Start();
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(object src, EventArgs e)
		{
			ServiceStack.MiniProfiler.Profiler.Stop();
		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	};
}