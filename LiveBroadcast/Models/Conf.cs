using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveBroadcast.Models
{
    public class Conf
    {
        public static string WSUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["WSUrl"] ?? "";
            }
        }
    }
}