using System;
using System.Diagnostics;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WhatsAppNotify;

namespace WhatsAppNotify
{
    public class WhatsAppAPISend
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); //Wait for maximun of 10 seconds if any element is not found
            driver.Navigate().GoToUrl("https://api.whatsapp.com/send?phone=" + number + "&text=" + Uri.EscapeDataString(message));
            driver.FindElement(By.Id("action-button")).Click(); // Click SEND Buton
            driver.FindElement(By.CssSelector("button._2lkdt>span")).Click();//Click SEND Arrow Button
            Debug.WriteLine("hasClicked");
        }

        public void run(List<string> nums, string message)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://web.whatsapp.com");
            while (true)
            {
                Debug.WriteLine("Login to WhatsApp Web and Press Enter");
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