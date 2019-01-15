using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhatsAppNotify;

namespace WhatsAppNotify
{
    public partial class ButtonController : System.Web.UI.Page
    {

        protected int phoneCount
        {
            get { return Convert.ToInt32(ViewState["count"] ?? "1"); }
            set { ViewState["count"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PhoneHolder.Instance.ClearTBS();
                TextBox tb = new TextBox();
                tb.ID = "enterPhone1";
                PhoneHolder.Instance.Add(tb);
            }
            DrawTextBoxes();
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            // Get list of phone numbers
            // iterate each number, and send message
            //string message = GetMessage();

            PhoneHolder.Instance.NotifySender(PhoneHolder.Instance.GetTBS(), "Hello World");
        }

        protected void addPhone_Click(object sender, EventArgs e)
        {
            // get access to latest textbox
            // check if string is non empty and valid
            // add another textbox, send string to Class1
            TextBox newNum = PhoneHolder.Instance.GetTBS()[PhoneHolder.Instance.GetTBS().Count -1];

            int numLength = newNum.Text.Length;

            if (numLength == 0 || !newNum.Text.All(c => c >= '0' && c <= '9'))
                Debug.WriteLine("Invalid number");
            else
            {
                TextBox tb = new TextBox();
                tb.ID = "enterPhone" + (++phoneCount);
                PhoneHolder.Instance.Add(tb);

                var to = new Label();
                to.Text = "To:";
                to.ID = tb.ID + "label";

                Panel1.Controls.Add(to);
                Panel1.Controls.Add(tb);
            }
        }

        private void DrawTextBoxes()
        {
            foreach (TextBox tb in PhoneHolder.Instance.GetTBS())
            {
                var to = new Label();
                to.Text = "To:";
                to.ID = tb.ID + "label";
                Panel1.Controls.Add(to);
                Panel1.Controls.Add(tb);
            }
        }

        protected void removePhone_Click(object sender, EventArgs e)
        {
            PhoneHolder.Instance.RemoveLastElement();
            DrawTextBoxes();
        }
    }
}