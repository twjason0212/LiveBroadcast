using System;
using System.Collections.Generic;

namespace LiveBroadcast.Models
{
    public class AnchorReport
    {
        public int anchorId
        {
            get;
            set;
        }

        public string anchorCode
        {
            get;
            set;
        }

        public string anchorName
        {
            get;
            set;
        }

        public decimal currMonthAmount
        {
            get;
            set;
        }

        public decimal lastMonthAmount
        {
            get;
            set;
        }

        public decimal allAmount
        {
            get;
            set;
        }
    }
    public class anchorReport<T>
    {
        public List<T> result
        {
            get;
            set;
        }
    }
}
