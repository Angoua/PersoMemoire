using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCollectorApp.Models
{
    public class mHelpers
    {
        public static string Url_Prefix = "http://localhost:4150";
        public static string login_key = "login";

        public static string GetLoginName(HttpSessionStateBase session)
        {
            return session[login_key] == null ? string.Empty : (string)session[login_key];
        }
    }
}