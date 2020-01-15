using System;
using System.Collections.Generic;

namespace LiveBroadcast.Models
{
    public class InitDataResult
    {
        public Dictionary<string, object> DataList
        {
            get;
            set;
        }

        public Dictionary<string, string> DataVersionDictionary
        {
            get;
            set;
        }

        public InitDataResult()
        {
            this.DataList = new Dictionary<string, object>();
            this.DataVersionDictionary = new Dictionary<string, string>();
        }
    }
}
