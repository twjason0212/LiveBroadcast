using System;

namespace LiveBroadcast.Models
{
    public class NewResultInfoT<T>
    {
        public int Code
        {
            get;
            set;
        }

        public string StrCode
        {
            get;
            set;
        }

        public int DataCount
        {
            get;
            set;
        }

        public bool IsLogin
        {
            get;
            set;
        }

        public anchorReport<T> data
        {
            get;
            set;
        }
    }
}
