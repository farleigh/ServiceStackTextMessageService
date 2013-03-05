using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.Common.Web;
using System.Net;

namespace ServiceStackPhoneMessageService.App_Start
{
    public class MessagesService : Service
    {
        public object Get(TextMessages messagesRequest)
        {
            Phone phone = TextMessagingProvider.Instance.GetPhone(messagesRequest.Number);
            return new TextMessageResponse() { TextMessages = TextMessagingProvider.Instance.GetMessages(phone) };
        }

        public object Delete(TextMessages message)
        {
            Phone phone = TextMessagingProvider.Instance.GetPhone(message.Number);
            TextMessagingProvider.Instance.ClearMessages(phone);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                    { HttpHeaders.Location, this.RequestContext.AbsoluteUri + message.Number }
                }
            };
        }
    }
}