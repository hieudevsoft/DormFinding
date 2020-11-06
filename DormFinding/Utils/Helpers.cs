using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding.Utils
{
    public class Helpers
    {
        static bool isValidEmail(String email)
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
    }
}
