using Com.CloudRail.SI;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.Services;
using Com.CloudRail.SI.Types;

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MessagingTest
{
    public class MessengerAPI
    {
        private static MessengerAPI instance = null;
        public static MessengerAPI Instance
        {
            get
            {
                if (instance == null)
                    instance = new MessengerAPI();
                return instance;
            }
        }

        private static IMessaging service;

        /// <summary>
        /// Using cloudrail, send a message to a user by providing their user id
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        /// <param name="useLine"></param>
        /// <returns></returns>
        public bool SendMessage(string userID, string message, bool useLine)
        {
            // Using cloudrail service
            CloudRail.AppKey = "5c454f1421b62e5228da6b18";

            // Locate bot accounts Line and Telegram
            Line line = new Line(null, "Nt1tBYsLrnyq/NbS6C1oWhSt9FSwpG3sKL01xGkapDK43Ly68F5bi4fq7Zz39RsmSEYDGbdpTRTHECTaZfJwu7sjeefV0DstGqgpJXoMvtoQ0BJVwuMAD8zY07fiZfro03DbQcyALMO2PNzpp3F6DwdB04t89/1O/w1cDnyilFU=");
            Telegram telegram = new Telegram(null, "737341810:AAGN82CUC2pWVdUH7G0oJVEnqQC4dV4d7Mc", "");

            service = (useLine) ? (IMessaging) line : telegram;

            // To check if user id is valid
            try
            {
                Message result = service.SendMessage(userID, message);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}