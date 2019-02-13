using System.Collections.Generic;

namespace MessagingTest
{
    public class APIChooser
    {
        private static APIChooser instance = null;
        public static APIChooser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APIChooser();
                }
                return instance;
            }
        }

        private MessengerAPI messageAPI;
        private TwilioAPI twilioApi;
        private WhatsAppAPI whatsappAPI;

        private APIChooser()
        {
            messageAPI = new MessengerAPI();
            twilioApi = new TwilioAPI();
            whatsappAPI = new WhatsAppAPI();
        }

        /*
         * 1 - CloudRail
         * 2 - Twilio
         * 3 - Selenium
         */

        /// <summary>
        /// Send message to 1 phone number
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>true if message sent successfully</returns>
        public bool AlertAPI(int id, string message, string phoneNumber)
        {
            switch (id)
            {
                case 1:
                    return messageAPI.SendMessage(phoneNumber, message);
                case 2:
                    return twilioApi.SendMessage(phoneNumber, message);
                case 3:
                    return whatsappAPI.SendMessage(phoneNumber, message);
            }
            return false;
        }

        /// <summary>
        /// Send message to 1 or more phone numbers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <param name="phoneNumbers"></param>
        /// <returns>list of numbers that failed to receive message</returns>
        public List<string> AlertAPI(int id, string message, List<string> phoneNumbers)
        {
            switch (id)
            {
                case 1:
                    return messageAPI.SendMessage(phoneNumbers, message);
                case 2:
                    return twilioApi.SendMessage(phoneNumbers, message);
                case 3:
                    return whatsappAPI.SendMessage(phoneNumbers, message);
            }
            return null;
        }
    }
}