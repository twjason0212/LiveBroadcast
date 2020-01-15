using System;
using System.Collections.Generic;
using System.Reflection;

namespace LiveBroadcast.Models
{
    public static class ConvertExtensionMethods
    {
        public static List<T> ConvertAnchor<T>(this List<AnchorReport> anchorReports) where T : class, new()
        {
            PropertyInfo[] properties = Activator.CreateInstance<T>().GetType().GetProperties();
            List<T> list = new List<T>();
            foreach (AnchorReport current in anchorReports)
            {
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] array = properties;
                for (int i = 0; i < array.Length; i++)
                {
                    PropertyInfo propertyInfo = array[i];
                    string name = propertyInfo.Name;
                    if (!(name == "anchor_id"))
                    {
                        if (!(name == "tipmoney_thismonth"))
                        {
                            if (!(name == "tipmoney_lastmonth"))
                            {
                                if (name == "tipmoney_total")
                                {
                                    propertyInfo.SetValue(t, Convert.ChangeType(current.allAmount, propertyInfo.PropertyType));
                                }
                            }
                            else
                            {
                                propertyInfo.SetValue(t, Convert.ChangeType(current.lastMonthAmount, propertyInfo.PropertyType));
                            }
                        }
                        else
                        {
                            propertyInfo.SetValue(t, Convert.ChangeType(current.currMonthAmount, propertyInfo.PropertyType));
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue(t, Convert.ChangeType(current.anchorId, propertyInfo.PropertyType));
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}
