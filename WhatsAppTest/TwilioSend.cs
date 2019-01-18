using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WhatsAppTest
{
    public class TwilioSend
    {
        private static TwilioSend instance = null;
        public static TwilioSend Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TwilioSend();
                }
                return instance;
            }
        }

        private const string accountSID = "ACf29fb18d76781675f051500c7444758e";
        private const string token = "0f764e8bed0f55d7a98b1f1ce3eb5de4";

        public void Run(List<string> phoneNumber, string message)
        {
            TwilioClient.Init(accountSID, token);

            foreach (string number in phoneNumber)
            {
                SendMessage(number, message);
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void SendMessage(string phoneNumber, string message)
        {
            var messageOption = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+" + phoneNumber)
            );

            messageOption.From = new PhoneNumber("whatsapp:+14155238886");

            messageOption.Body = message;

            try
            {
                MessageResource.Create(messageOption);
            }
            catch (Exception)
            {
                Debug.WriteLine("Invalid number");
            }
        }
    }
}