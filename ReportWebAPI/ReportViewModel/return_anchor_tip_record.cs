using System;
using System.Collections.Generic;

namespace ReportWebAPI.ReportViewModel
{
    public class return_anchor_tip_record
    {
        public List<dt_anchor_tip_record> anchor_list
        {
            get;
            set;
        }

        public int anchor_count
        {
            get;
            set;
        }

        public int code
        {
            get;
            set;
        }
    }
}
