using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LiveOutlook.LiveUIL.LiveCore
{
    class Interactive
    {
#region Declarations

        public static string STATUS = string.Empty;
        public static string PB = string.Empty;

#endregion

#region Message Dialogs

        public static DialogResult LInfo(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle+"\n"+StrMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult LInfoError(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle + "\n" + StrMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult LInfoWarning(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle + "\n" + StrMsg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult LInfoWarningOK(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle + "\n" + StrMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult LInfoConfirm(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle + "\n" + StrMsg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult LInfoRetryCancel(string StrMsg, string StrTitle)
        {
            return MessageBox.Show(StrTitle + "\n" + StrMsg, Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }

#endregion
    }
}
