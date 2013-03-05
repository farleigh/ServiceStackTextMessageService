namespace ServiceStackPhoneMessageService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceStack.ServiceHost;

    [Route("/phones", "POST")]
    [Route("/phones/{Number}", "GET, DELETE")]
    public class Phone
    {
        public string Number { get; set; }
        public IEnumerable<TextMessage> Messages { get; set; }
    }
}
