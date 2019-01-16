using System;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WhatsAppNotify;
using System.Collections;

namespace WhatsAppNotify
{
    public class WhatsAppAPISend
    {
        // Singleton pattern, only require one phoneholder
        private static WhatsAppAPISend instance = null;
        public static WhatsAppAPISend Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WhatsAppAPISend();

                } return instance;
            }
        }


        private IWebDriver driver;

        // check if user is still in the login page for whatsapp web
        private bool CheckLoggedIn()
        {
            try
            {
                return driver.FindElement(By.ClassName("_2Uo0Z")).Displayed;

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Manually go through the recipient's whatsapp and send the message through
        /// whatsapp web.
        /// Give time to find page element before going to next recipient.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="message"></param>
        private void SendMessage(string number, string message)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Wait for maximun of 10 seconds if any element is not found
            driver.Navigate().GoToUrl("https://api.whatsapp.com/send?phone=" + number + "&text=" + Uri.EscapeDataString(message));
            driver.FindElement(By.Id("action-button")).Click(); // Click SEND Buton
            
            // if phone number is invalid, skip to the next recipient.
            try
            {
                driver.FindElement(By.CssSelector("button._35EW6")).SendKeys(Keys.Enter);//Click SEND Arrow Button
            }
            catch (Exception)
            {
                return;
            }

            System.Threading.Thread.Sleep(5000);
            
        }

        /// <summary>
        /// Open google chrome and go to whatsapp web.
        /// Send message once the user logs in to whatsapp
        /// </summary>
        /// <param name="nums"> list of recipients to get the message</param>
        /// <param name="message"></param>
        public void run(List<string> nums, string message)
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://web.whatsapp.com");
            while (true)
            {
                if (CheckLoggedIn())
                    break;
            }

            foreach (string num in nums)
            {
                SendMessage(num, message);
            }
        }
    }
}