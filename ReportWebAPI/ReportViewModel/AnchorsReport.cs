using System;

namespace ReportWebAPI.ReportViewModel
{
    public class AnchorsReport
    {
        public int AnchorId
        {
            get;
            set;
        }

        public decimal TipMoneyToday
        {
            get;
            set;
        }

        public decimal TipMoneyThisMonth
        {
            get;
            set;
        }

        public decimal TipMoneyLastMonth
        {
            get;
            set;
        }

        public decimal TipMoneyTotal
        {
            get;
            set;
        }
    }
}
