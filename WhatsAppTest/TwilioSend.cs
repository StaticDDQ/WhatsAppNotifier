using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WhatsAppTest
{
    public class TwilioSend
    {
        private TwilioSend() {}

        // Only require one instance for sending messages
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

        // if possible, store this in server
        private const string accountSID = "ACf29fb18d76781675f051500c7444758e";
        private const string token = "0f764e8bed0f55d7a98b1f1ce3eb5de4";

        /// <summary>
        /// Initialize twilio using given SID and token.
        /// Iteratively send the message to all phone numbers.
        /// Can only send 1 message per second
        /// </summary>
        /// <param name="phoneNumbers"></param>
        /// <param name="message"></param>
        public void SendMessage(List<string> phoneNumbers, string message)
        {
            TwilioClient.Init(accountSID, token);

            foreach (string number in phoneNumbers)
            {
                RunTwilio(number, message);
                System.Threading.Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Initialize twilio using given SID and token.
        /// Send a message to one phone number.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        public void SendMessage(string phoneNumber, string message)
        {
            TwilioClient.Init(accountSID, token);

            RunTwilio(phoneNumber, message);
        }

        private void RunTwilio(string phoneNumber, string message)
        {
            var messageOption = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+" + phoneNumber)
            );

            // Hard-coded number for testing purposes
            messageOption.From = new PhoneNumber("whatsapp:+14155238886");

            messageOption.Body = message;

            // if phone number is valid
            try
            {
                MessageResource.Create(messageOption);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number:" + phoneNumber);
            }
        }
    }
}