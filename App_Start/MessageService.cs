using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Common.Web;
using System.Net;

namespace ServiceStackPhoneMessageService
{
    public class MessageService : Service
    {
        public object Post(TextMessage message)
        {
            string phoneNumber = message.Target;
            Phone phone = TextMessagingProvider.Instance.GetPhone(phoneNumber);
            TextMessagingProvider.Instance.AddMessage(phone, message);
            return new HttpResult(new TextMessageResponse() { TextMessages = TextMessagingProvider.Instance.GetMessages(phone) })
            {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                    { HttpHeaders.Location, base.Request.AbsoluteUri + "/" + message.GetHashCode() }
                }
            };
        }
    }
}