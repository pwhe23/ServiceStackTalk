
using System.Net;
using Funq;
using GtdApp.Domain;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.Razor;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace GtdApp.Web
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("GtdApp", 
			typeof(AppHost).Assembly, 
			typeof(TodoService).Assembly
		) { }

		public override void Configure(Container container)
		{
			LogManager.LogFactory = new ConsoleLogFactory();

			Plugins.Add(new RazorFormat());

			GtdDb.Init(container);

			SetConfig(new EndpointHostConfig
			{
				CustomHttpHandlers = {
                    { HttpStatusCode.NotFound, new RazorHandler("/notfound") },
                    { HttpStatusCode.Unauthorized, new RazorHandler("/login") },
                }
			});
			
			Plugins.Add(new AuthFeature(
				() => new AuthUserSession(),
				new IAuthProvider[] {
                    new CredentialsAuthProvider(),
                }
			));
		}
	};
}
