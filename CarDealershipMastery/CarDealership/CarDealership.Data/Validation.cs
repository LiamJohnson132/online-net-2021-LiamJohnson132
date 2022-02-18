using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Validation
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            string specialChar = @"%!#$%^&*()?/>.<,:;'\|}]{[_~`+=-""1234567890";
            char[] chars = specialChar.ToCharArray();

            if (password.Length < 8 || 
                !password.Any(char.IsUpper) ||
                !password.Any(char.IsLower))
            {
                return false;
            }

            foreach (char c in chars)
            {
                if (password.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
