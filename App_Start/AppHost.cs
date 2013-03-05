using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStackPhoneMessageService
{
    public class AppHost : AppHostBase
    {
        public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("TextMessageService", typeof(MessageService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
		
			//Configure User Defined REST Paths
            Routes.Add<PhoneResponse>("/{Phone*}");

			//Uncomment to change the default ServiceStack configuration
			//SetConfig(new EndpointHostConfig {
			//});

			//Enable Authentication
			//ConfigureAuth(container);

			//Register all your dependencies
			//container.Register(new TodoRepository());			
		}

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}