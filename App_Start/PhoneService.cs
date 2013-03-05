using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;
using ServiceStack.Common.Web;
using System.Net;

namespace ServiceStackPhoneMessageService.App_Start
{
    public class PhoneService : Service
    {
        public object Get(Phone request)
        {
            return new PhoneResponse()
            {
                Phone = TextMessagingProvider.Instance.GetPhone(request.Number)
            };
        }

        public object Post(Phone phone)
        {
            TextMessagingProvider.Instance.AddPhone(phone);

            return new HttpResult(new PhoneResponse() { Phone = phone })
            {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                    { HttpHeaders.Location, base.Request.AbsoluteUri + "/" + phone.Number }
                }
            };
        }
    }
}