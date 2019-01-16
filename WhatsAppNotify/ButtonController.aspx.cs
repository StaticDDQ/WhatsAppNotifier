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
            if (!Page.IsPostBack)
            {
                // empty the list and add first empty textbox
                PhoneHolder.Instance.ClearTBS();
                TextBox tb = new TextBox();
                tb.ID = "enterPhone1";
                PhoneHolder.Instance.Add(tb);
            }
            DrawTextBoxes();
        }

        /// <summary>
        /// Have phoneholder convert list of textbox to be list of string.
        /// Send list to WhatsAppAPISend to carry out whatsapp messaging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void sendBtn_Click(object sender, EventArgs e)
        {
            //string message = GetMessage();
            
            List<string> convertedNums = PhoneHolder.Instance.NotifySender();
            if(convertedNums.Count > 0)
                WhatsAppAPISend.Instance.run(convertedNums, "Hello World");
        }

        /// <summary>
        /// Get the latest textbox made, check if the text is valid.
        /// Add it to the list and render another textbox and label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addPhone_Click(object sender, EventArgs e)
        {
            TextBox newNum = PhoneHolder.Instance.GetTBS()[PhoneHolder.Instance.GetTBS().Count -1];
            Debug.WriteLine(newNum.Text);
            int numLength = newNum.Text.Length;
            
            // for now, check if all in digits and non empty
            if (numLength > 0 && newNum.Text.All(c => c >= '0' && c <= '9'))
            {
                TextBox tb = new TextBox();
                tb.ID = "enterPhone" + (++phoneCount);
                tb.CssClass = "numberSpace";
                PhoneHolder.Instance.Add(tb);

                var to = new Label();
                to.Text = "To:";
                to.ID = tb.ID + "label";
                Panel1.Controls.Add(to);
                Panel1.Controls.Add(tb);
            }
        }

        /// <summary>
        /// For each page load, readd all the textboxes and label
        /// to the page
        /// </summary>
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
            var box = PhoneHolder.Instance.RemoveLastElement();

            if (box != null)
            {
                Panel1.Controls.Remove(box);
                Label to = (Label)Panel1.FindControl(box.ID + "label");
                Panel1.Controls.Remove(to);
            }
        }
    }
}