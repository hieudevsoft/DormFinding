using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public static void MakeErrorMessage(Window w,string title,string message)=> MessageBox.Show(title, message, MessageBoxButton.OK, MessageBoxImage.Error);
        public static void MakeConfirmMessage(Window w, string title, string message) => MessageBox.Show(title, message, MessageBoxButton.OK, MessageBoxImage.Information);
        public static string GetTextTextBox(TextBox t) => t.Text.Trim();
        public static string GetTextPassWord(PasswordBox p) => p.Password.Trim();

        public static byte ConverCheckedToInt(CheckBox cb)
        {
            if (cb.IsChecked == true) return 1; else return 0;
        }

        public static string tbUser = "tb_user";
        public static string colEmail = "_email";
        public static string colPassword = "_password";
        public static string colRemember = "_isRemember";

        public static string tbUserProfile = "tb_user_profile";
        public static string colEmailProfile = "_email_profile";
        public static string colNameProfile = "_name_profile";
        public static string colDateProfile = "_date_profile";
        public static string colPhoneProfile = "_email_profile";
        public static string colAdressProfile = "_address_profile";
        public static string colHintProfile = "_hintanswer_profile";
        public static string colGenderProfile = "_gender_profile";
        public static string colImageProfile = "_image_profile";
    }
}
