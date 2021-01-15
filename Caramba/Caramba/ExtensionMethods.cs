using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Caramba
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Method for checking whether or not the input string is an email address
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>True if the input string is an email address</returns>
        public static bool IsEmail(this string input)
        {
            try
            {
                MailAddress addr = new MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }
    }
}
