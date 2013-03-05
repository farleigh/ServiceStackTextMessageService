using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace ServiceStackPhoneMessageService
{
    [Route("/phones/{Number}/messages", "GET, DELETE")]
    public class TextMessages
    {
        public string Number { get; set; }
    }
}