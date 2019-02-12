using Com.CloudRail.SI;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.Services;
using Com.CloudRail.SI.Types;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MessagingTest
{
    public class MessengerAPI : Messageable<string>
    {
        private static IMessaging service;

        /// <summary>
        /// Using cloudrail, send a message to a user by providing their user id
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        /// <param name="useLine"></param>
        /// <returns></returns>
        public bool SendMessage(string userID, string message)
        {
            Init(true);

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

        /// <summary>
        /// Iterate through each number using cloudrail sdk
        /// </summary>
        /// <param name="phoneNumbers"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public List<string> SendMessage(List<string> phoneNumbers, string message)
        {
            Init(true);

            List<string> failedNumbers = new List<string>();

            foreach (string number in phoneNumbers)
            {
                try
                {
                    Message result = service.SendMessage(number, message);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    failedNumbers.Add(number);
                }
            }

            return failedNumbers;
        }

        /// <summary>
        /// Initialize cloudrail account and login service
        /// </summary>
        /// <param name="useLine">choose either line or telegram</param>
        private void Init(bool useLine)
        {
            CloudRail.AppKey = "5c454f1421b62e5228da6b18";

            // Locate bot accounts Line and Telegram using bot token
            Line line = new Line(null, "Nt1tBYsLrnyq/NbS6C1oWhSt9FSwpG3sKL01xGkapDK43Ly68F5bi4fq7Zz39RsmSEYDGbdpTRTHECTaZfJwu7sjeefV0DstGqgpJXoMvtoQ0BJVwuMAD8zY07fiZfro03DbQcyALMO2PNzpp3F6DwdB04t89/1O/w1cDnyilFU=");
            Telegram telegram = new Telegram(null, "766364749:AAGI8yDvdNA_VWgXBYF8KFqdvohWid1o3k", "");

            service = (useLine) ? (IMessaging)line : telegram;
        }
    }
}