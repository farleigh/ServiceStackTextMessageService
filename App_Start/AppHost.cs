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
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
        }

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}