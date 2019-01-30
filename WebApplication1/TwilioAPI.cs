using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessagingTest
{
    public class TwilioAPI : Messageable<string>
    {
        private TwilioAPI() {}

        // Only require one instance for sending messages
        private static TwilioAPI instance = null;
        public static TwilioAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TwilioAPI();
                }
                return instance;
            }
        }

        // if possible, store this in server
        private const string accountSID = "ACa51e68669a0d5ea0f490887f0c236aab";
        private const string token = "0ebf6936e63ec4efaa1bac7d4e7c3c39";

        /// <summary>
        /// Initialize twilio using given SID and token.
        /// Iteratively send the message to all phone numbers.
        /// Can only send 1 message per second
        /// </summary>
        /// <param name="phoneNumbers"></param>
        /// <param name="message"></param>
        public List<string> SendMessage(List<string> phoneNumbers, string message)
        {
            TwilioClient.Init(accountSID, token);
            List<string> failedNumbers = new List<string>();

            foreach (string number in phoneNumbers)
            {
                if (!RunTwilio(number, message))
                {
                    failedNumbers.Add(number);
                }
                
                System.Threading.Thread.Sleep(2000);
            }

            return failedNumbers;
        }

        /// <summary>
        /// Initialize twilio using given SID and token.
        /// Send a message to one phone number. 
        /// Returns true if message sent successfully
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        public bool SendMessage(string phoneNumber, string message)
        {
            TwilioClient.Init(accountSID, token);

            return RunTwilio(phoneNumber, message);
        }

        /// <summary>
        /// Using the Twilio client, send a message from testing account to given number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        private bool RunTwilio(string phoneNumber, string message)
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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}