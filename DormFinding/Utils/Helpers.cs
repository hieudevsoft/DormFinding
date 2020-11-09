using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DormFinding.Utils
{
    public class Helpers
    {
        public static bool isValidEmail(String email)
        {
            try
            {
                MailAddress maiAddress = new MailAddress(email);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static string GetTextTextBox(TextBox t) => t.Text.Trim();
        public static string GetTextPassWord(PasswordBox p) => p.Password.Trim();
    }
}
