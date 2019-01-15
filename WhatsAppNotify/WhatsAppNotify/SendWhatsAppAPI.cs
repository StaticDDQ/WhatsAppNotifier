using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WhatsAppNotify
{
    public class SendWhatsAppAPI
    {
        IWebDriver driver;

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

        private void SendMessage(string number, string message)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Wait for maximun of 10 seconds if any element is not found
            driver.Navigate().GoToUrl("https://api.whatsapp.com/send?phone=" + number + "&text=" + Uri.EscapeDataString(message));
            driver.FindElement(By.Id("action-button")).Click(); // Click SEND Buton
            driver.FindElement(By.CssSelector("button._2lkdt>span")).Click();//Click SEND Arrow Button
        }

        public void run(string message, string number)
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://web.whatsapp.com");

            while (true)
            {
                Console.WriteLine("Login to WhatsApp Web and Press Enter");
                Console.ReadLine();
                if (CheckLoggedIn())
                    break;
            }

            SendMessage(number, message); 
        }
    }
}