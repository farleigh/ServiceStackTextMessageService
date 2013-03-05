namespace ServiceStackPhoneMessageService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceStack.ServiceHost;

    [Route("/phones/{Target}/messages", "POST")]
    public class TextMessage
    {
        public string Content { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}
