namespace ServiceStackPhoneMessageService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TextMessageResponse
    {
        public IEnumerable<TextMessage> TextMessages { get; set; }
    }
}
