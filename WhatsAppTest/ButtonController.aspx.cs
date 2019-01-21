﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhatsAppTest
{
    public partial class ButtonController : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // empty the list and add first empty textbox
                PhoneHolder.Instance.ClearTBS();
                TextBox tb = new TextBox();
                tb.ID = "enterPhone0";
                tb.CssClass = "numberSpace";
                tb.CausesValidation = false;
                PhoneHolder.Instance.Add(tb);
            }
            DrawTextBoxes();
        }

        /// <summary>
        /// Have phoneholder convert list of textbox to be list of string.
        /// Send list to WhatsAppAPISend to carry out whatsapp messaging.
        /// Message is obtained from message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void sendBtn_Click(object sender, EventArgs e)
        {
            string message = messageBox.Text;

            List<string> convertedNums = PhoneHolder.Instance.ConvertStringList();
            if (convertedNums.Count > 0 && message.Length > 0)
            {
                TwilioSend.Instance.SendMessage(convertedNums, message);
            }
        }

        /// <summary>
        /// Get the latest textbox made, check if text is valid.
        /// Add it to the list and render another textbox and label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addPhone_Click(object sender, EventArgs e)
        {
            var phoneHolderTBS = PhoneHolder.Instance.GetTBS();
            TextBox newNum = phoneHolderTBS[phoneHolderTBS.Count - 1];

            int numLength = newNum.Text.Length;

            // for now, check if all in digits and non empty
            if (numLength > 0 && newNum.Text.All(c => c >= '0' && c <= '9'))
            {
                TextBox tb = new TextBox();
                tb.ID = "enterPhone" + phoneHolderTBS.Count;
                tb.CssClass = "numberSpace";
                tb.CausesValidation = false;
                PhoneHolder.Instance.Add(tb);

                var to = new Label();
                to.Text = "To: ";
                to.ID = tb.ID + "label";
                to.CssClass = "to";
                phonePanel.Controls.Add(to);
                phonePanel.Controls.Add(tb);
            }
        }

        /// <summary>
        /// For each page load, read all the textboxes and label
        /// to the page
        /// </summary>
        private void DrawTextBoxes()
        {
            foreach (TextBox tb in PhoneHolder.Instance.GetTBS())
            {
                var to = new Label();
                to.Text = "To: ";
                to.ID = tb.ID + "label";
                to.CssClass = "to";
                phonePanel.Controls.Add(to);
                phonePanel.Controls.Add(tb);
            }
        }

        protected void removePhone_Click(object sender, EventArgs e)
        {
            var box = PhoneHolder.Instance.RemoveLastElement();

            // if there is still more than 1 textboxes displayed
            if (box != null)
            {
                phonePanel.Controls.Remove(box);
                Label to = (Label)phonePanel.FindControl(box.ID + "label");
                phonePanel.Controls.Remove(to);
            }
        }
    }
}