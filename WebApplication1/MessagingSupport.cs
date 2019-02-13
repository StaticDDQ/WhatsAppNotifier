using System;
using System.IO;

    namespace MessagingTest
{
    public partial class Messaging : System.Web.UI.Page 
    {

        private static string filePath;

        /// <summary>
        /// Set file name to be uploaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileUploadComplete(object sender, EventArgs e)
        {
            filePath = Path.GetFileName(uploadSpace.FileName);
        }

        /// <summary>
        /// Disable file upload if Text radio button is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void text_CheckedChanged(object sender, EventArgs e)
        {
            filePath = "";
            messageBox.Text = "";
            messageBox.Style["display"] = "inline-block";
            uploadSpace.Style["display"] = "none";
        }

        /// <summary>
        /// Disable message box if File radio button is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void file_CheckedChanged(object sender, EventArgs e)
        {
            filePath = "";
            messageBox.Text = "";
            messageBox.Style["display"] = "none";
            uploadSpace.Style["display"] = "inline-block";
        }
    }
}