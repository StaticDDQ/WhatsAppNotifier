using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WhatsAppNotify
{
    public class PhoneHolder
    {
        private PhoneHolder()
        {
            tbs = new List<TextBox>();
            sender = new WhatsAppAPISend();
        }
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

        private List<TextBox> tbs;
        private WhatsAppAPISend sender;

        public void Add(TextBox tb)
        {
            tbs.Add(tb);
        }

        public List<TextBox> GetTBS()
        {
            return tbs;
        }

        public void RemoveLastElement()
        {
            if (tbs.Count > 1)
            {
                tbs.RemoveAt(tbs.Count - 1);
            }
        }

        public void ClearTBS()
        {
            tbs.Clear();
        }

        public void NotifySender(List<TextBox> phoneNums, string message)
        {
            List<string> nums = new List<string>();
            foreach (TextBox box in phoneNums)
            {
                nums.Add(box.Text);
            }

            if (sender != null)
            {
                sender.run(nums, message);
            }
        }
    }
}