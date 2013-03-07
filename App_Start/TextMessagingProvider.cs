using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackPhoneMessageService
{
    public class TextMessagingProvider
    {
        private IDictionary<string, Phone> phones = new Dictionary<string, Phone>();
        private IDictionary<Phone, List<TextMessage>> messages = new Dictionary<Phone, List<TextMessage>>();
        
        private static TextMessagingProvider instance = new TextMessagingProvider();

        public static TextMessagingProvider Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<TextMessage> GetMessages(Phone phone)
        {
            if (!messages.ContainsKey(phone))
            {
                return new TextMessage[] { };
            }

            return messages[phone];
        }

        public Phone GetPhone(string phoneNumber)
        {
            if (!phones.ContainsKey(phoneNumber))
            {
                return null;
            }

            return phones[phoneNumber];
        }

        public void AddPhone(Phone phone)
        {
            if (phones.ContainsKey(phone.Number))
            {
                phones.Remove(phone.Number);
            }

            phones.Add(phone.Number, phone);
        }

        public void AddMessage(Phone destination, TextMessage message)
        {
            if (destination == null)
            {
                return;
            }
            
            List<TextMessage> messagesForPhone = null;
            if (messages.ContainsKey(destination))
            {
                messagesForPhone = messages[destination];
            }
            else
            {
                messagesForPhone = new List<TextMessage>();
            }

            messagesForPhone.Add(message);
            messages[destination] = messagesForPhone;
        }

        public void ClearMessages(Phone phone)
        {
            messages.Remove(phone);
        }
    }
}