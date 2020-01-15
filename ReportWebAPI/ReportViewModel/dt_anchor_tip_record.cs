using System;

namespace ReportWebAPI.ReportViewModel
{
    public class dt_anchor_tip_record
    {
        public string identityid
        {
            get;
            set;
        }

        public int anchor_id
        {
            get;
            set;
        }

        public decimal tipmoney_today
        {
            get;
            set;
        }

        public decimal tipmoney_thismonth
        {
            get;
            set;
        }

        public decimal tipmoney_lastmonth
        {
            get;
            set;
        }

        public decimal tipmoney_total
        {
            get;
            set;
        }
    }
}
