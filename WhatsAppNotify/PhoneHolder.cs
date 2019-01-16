﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WhatsAppNotify
{
    public class PhoneHolder
    {
        /// <summary>
        /// Constructor that initialize list and instance of class to send
        /// whatsapp message
        /// </summary>
        private PhoneHolder()
        {
            tbs = new List<TextBox>();
        }

        // Singleton pattern, only require one phoneholder
        private static PhoneHolder instance = null;
        public static PhoneHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhoneHolder();

                } return instance;
            }
        }

        // stores textbox where they hold users phone numbers
        private List<TextBox> tbs;

        public void Add(TextBox tb)
        {
            tbs.Add(tb);
        }

        public List<TextBox> GetTBS()
        {
            return tbs;
        }

        public TextBox RemoveLastElement()
        {
            if (tbs.Count > 1)
            {
                TextBox boxRemoved = tbs[tbs.Count - 1];
                tbs.Remove(boxRemoved);
                return boxRemoved;
            }
            return null;
        }

        public void ClearTBS()
        {
            tbs.Clear();
        }

        /// <summary>
        /// Send a list of phone numbers, in string format, and a given message to another class
        /// </summary>
        /// <param name="message"></param>
        public List<string> NotifySender()
        {
            // get the text of each texbox
            List<string> nums = new List<string>();
            foreach (TextBox box in tbs)
            {
                // skip empty textboxes
                if(box.Text.Length > 0)
                    nums.Add(box.Text);
            }

            return nums;
        }
    }
}