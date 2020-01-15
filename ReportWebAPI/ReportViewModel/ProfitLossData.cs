using System;

namespace ReportWebAPI.ReportViewModel
{
    public class ProfitLossData
    {
        private decimal _balance;

        private decimal _betting;

        private decimal _bonusMoney;

        private decimal _activity;

        private decimal _rebate;

        private decimal _recharge;

        private decimal _withdraw;

        public string Balance
        {
            get
            {
                return this._balance.ToString("#0.00");
            }
            set
            {
                this._balance = Convert.ToDecimal(value);
            }
        }

        public string Betting
        {
            get
            {
                return this._betting.ToString("#0.00");
            }
            set
            {
                this._betting = Convert.ToDecimal(value);
            }
        }

        public string BonusMoney
        {
            get
            {
                return this._bonusMoney.ToString("#0.00");
            }
            set
            {
                this._bonusMoney = Convert.ToDecimal(value);
            }
        }

        public string Activity
        {
            get
            {
                return this._activity.ToString("#0.00");
            }
            set
            {
                this._activity = Convert.ToDecimal(value);
            }
        }

        public string Rebate
        {
            get
            {
                return this._rebate.ToString("#0.00");
            }
            set
            {
                this._rebate = Convert.ToDecimal(value);
            }
        }

        public string Recharge
        {
            get
            {
                return this._recharge.ToString("#0.00");
            }
            set
            {
                this._recharge = Convert.ToDecimal(value);
            }
        }

        public string Withdraw
        {
            get
            {
                return this._withdraw.ToString("#0.00");
            }
            set
            {
                this._withdraw = Convert.ToDecimal(value);
            }
        }

        public string AllProfitLoss
        {
            get
            {
                return (this._bonusMoney - this._betting + this._activity + this._rebate).ToString("#0.00");
            }
        }
    }
}
