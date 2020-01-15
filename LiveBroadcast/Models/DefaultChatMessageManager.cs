using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;

namespace LiveBroadcast.Models
{
    public class DefaultChatMessageManager
    {
        private static object _dbLock;

        private static string _cacheKey;

        private static MemoryCache _cache
        {
            get
            {
                return StaticObject.SettingCache;
            }
        }

        static DefaultChatMessageManager()
        {
            DefaultChatMessageManager._dbLock = new object();
            DefaultChatMessageManager._cacheKey = "DefaultBarrage";
        }

        public DefaultChatMessageManager()
        {
        }

        public static List<DefaultBarrage> GetSysBarrageList()
        {
            List<DefaultBarrage> defaultBarrages;
            List<DefaultBarrage> list = DefaultChatMessageManager._cache.Get(DefaultChatMessageManager._cacheKey, null) as List<DefaultBarrage>;
            if (list != null)
            {
                return list;
            }
            lock (DefaultChatMessageManager._dbLock)
            {
                list = DefaultChatMessageManager._cache.Get(DefaultChatMessageManager._cacheKey, null) as List<DefaultBarrage>;
                if (list == null)
                {
                    using (livecloudEntities livecloudEntity = new livecloudEntities())
                    {
                        list = (
                            from s in livecloudEntity.dt_SystemBarrage
                            where (int)s.state > 0
                            orderby s.id
                            select new DefaultBarrage()
                            {
                                ID = s.id,
                                Content = s.content
                            }).ToList<DefaultBarrage>();
                    }
                    MemoryCache memoryCaches = DefaultChatMessageManager._cache;
                    string str = DefaultChatMessageManager._cacheKey;
                    DateTimeOffset now = DateTimeOffset.Now;
                    memoryCaches.Set(str, list, now.AddSeconds(10), null);
                    return list;
                }
                else
                {
                    defaultBarrages = list;
                }
            }
            return defaultBarrages;
        }
    }
}