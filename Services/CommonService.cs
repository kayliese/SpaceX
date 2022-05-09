using System;
using System.Text.RegularExpressions;

namespace spacex_explore.Services
{
    public class CommonService
    {
        public CommonService()
        {
        }

        public bool IsValidEmail(string email)
        {
            if (Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success)
            {
                return true;
            }

            return false;
        }

    }
}
