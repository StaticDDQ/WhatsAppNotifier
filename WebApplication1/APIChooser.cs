using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public bool AlertAPI(int id, string message, string phoneNumber)
        {
            bool isSuccess = false;

            switch (id)
            {
                case 1:
                    isSuccess = messageAPI.SendMessage(phoneNumber, message);
                    break;
                case 2:
                    isSuccess = twilioApi.SendMessage(phoneNumber, message);
                    break;
                case 3:
                    isSuccess = whatsappAPI.SendMessage(phoneNumber, message);
                    break;
            }
            return isSuccess;
        }

        public List<string> AlertAPI(int id, string message, List<string> phoneNumbers)
        {
            List<string> failedNumbers = new List<string>();

            switch (id)
            {
                case 1:
                    failedNumbers = messageAPI.SendMessage(phoneNumbers, message);
                    break;
                case 2:
                    failedNumbers = twilioApi.SendMessage(phoneNumbers, message);
                    break;
                case 3:
                    failedNumbers = whatsappAPI.SendMessage(phoneNumbers, message);
                    break;
            }
            return failedNumbers;
        }
    }
}