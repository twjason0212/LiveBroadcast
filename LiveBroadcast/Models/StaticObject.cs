using System;
using System.Runtime.Caching;

namespace LiveBroadcast.Models
{
    public class StaticObject
    {
        public static MemoryCache SettingCache = new MemoryCache("LiveData", null);

        public static string ReportUri = "";
    }
}
