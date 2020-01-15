using System;

namespace ReportWebAPI.ReportViewModel
{
    public class PlatformReport
    {
        public string DateRange
        {
            get;
            set;
        }

        public string IdentityId
        {
            get;
            set;
        }

        public string IdentityName
        {
            get;
            set;
        }

        public int RegisterNumber
        {
            get;
            set;
        }

        public int NewPayNumber
        {
            get;
            set;
        }

        public int BetNumber
        {
            get;
            set;
        }

        public int InNumber
        {
            get;
            set;
        }

        public int OutNumber
        {
            get;
            set;
        }

        public int BetCount
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

        public decimal InMoney
        {
            get;
            set;
        }

        public int InCount
        {
            get;
            set;
        }

        public decimal OutMoney
        {
            get;
            set;
        }

        public int OutCount
        {
            get;
            set;
        }

        public decimal ActivityMoney
        {
            get;
            set;
        }

        public decimal RewardMoney
        {
            get;
            set;
        }

        public int RewardNumber
        {
            get;
            set;
        }

        public decimal Gross
        {
            get
            {
                return this.BetMoney - this.WinMoney;
            }
        }

        public string ProfitRate
        {
            get
            {
                return ((this.BetMoney > decimal.Zero) ? ((this.BetMoney - this.WinMoney - this.ActivityMoney - this.RebateMoney + this.AdminMoney + this.RejectMoney) / this.BetMoney * 100m) : decimal.Zero).ToString("0.00") + "%";
            }
        }

        public decimal RebateMoney
        {
            get;
            set;
        }

        public decimal AdminMoney
        {
            get;
            set;
        }

        public decimal RejectMoney
        {
            get;
            set;
        }
    }
}
