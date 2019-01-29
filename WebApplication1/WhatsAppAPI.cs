using System;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MessagingTest;
using System.Collections;

namespace MessagingTest
{
    public class WhatsAppAPI
    {
        private WhatsAppAPI()
        {
            string username = System.Environment.GetEnvironmentVariable("USERNAME");
            options = new ChromeOptions();
            options.AddArgument("user-data-dir=C://Users/"+username+"/AppData/Local/Google/Chrome/User Data/TempProfile");
        }

        // Singleton pattern, only require one instance.
        // Cannot have 1 whatsapp account be shared with multiple instances
        private static WhatsAppAPI instance = null;
        public static WhatsAppAPI Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WhatsAppAPI();

                } return instance;
            }
        }

        private IWebDriver driver;
        private ChromeOptions options;

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
        /// <param name="phoneNumber"></param>
        /// <param name="message"></param>
        private void SendMessage(string phoneNumber, string message)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(18); //Wait for maximun of 10 seconds if any element is not found
                driver.Navigate().GoToUrl("https://api.whatsapp.com/send?phone=" + phoneNumber + "&text=" + Uri.EscapeDataString(message));
                
                driver.FindElement(By.Id("action-button")).Click(); // Click SEND Buton
                
                // if phone number is invalid, skip to the next recipient.
                try
                {
                    driver.FindElement(By.CssSelector("button._35EW6")).SendKeys(Keys.Enter);//Click SEND Arrow Button
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Open google chrome and go to whatsapp web.
        /// Iteratively send message to each phone number
        /// </summary>
        /// <param name="nums"> list of recipients to get the message</param>
        /// <param name="message"></param>
        public void Run(List<string> phoneNumbers, string message)
        {
            // close browser if it is still opened
            CloseDriver();

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://web.whatsapp.com");

            while (true)
            {
                if (CheckLoggedIn())
                    break;
            }

            foreach (string num in phoneNumbers)
            {
                SendMessage(num, message);
                System.Threading.Thread.Sleep(5000);
            }

            CloseDriver();
        }

        /// <summary>
        /// Close a driver to prevent memory leak
        /// </summary>
        public void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        ~WhatsAppAPI()
        {
            CloseDriver();
        }
    }
}