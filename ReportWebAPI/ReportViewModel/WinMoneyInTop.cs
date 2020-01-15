using System;

namespace ReportWebAPI.ReportViewModel
{
    public class WinMoneyInTop
    {
        public int UserId
        {
            get;
            set;
        }

        public string IdentityId
        {
            get;
            set;
        }

        public decimal BetMoney
        {
            get;
            set;
        }

        public decimal WinMoney
        {
            get;
            set;
        }

        public decimal ProfitLoss
        {
            get;
            set;
        }
    }
}
