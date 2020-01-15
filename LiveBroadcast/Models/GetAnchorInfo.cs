using LiveBroadcast.Models;
using System;
using System.Linq;
using System.Web;

namespace LiveBroadcast.Models
{
    public class GetAnchorInfo
    {
        public string GameID
        {
            get;
            set;
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(this.GameID))
                {
                    this._ErrorMessage = "Bad parameter GameID.";
                    return false;
                }
                if (!this.GameIsExists)
                {
                    this._ErrorMessage = "GameID: " + this.GameID + " not exists.";
                    return false;
                }
                if (this.AnchorInfo == null)
                {
                    this._ErrorMessage = "Not found anchor info.";
                    return false;
                }
                return true;
            }
        }

        private string _ErrorMessage
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get
            {
                return this._ErrorMessage;
            }
        }

        public bool GameIsExists
        {
            get
            {
                bool result;
                using (livecloudEntities livecloudEntities = new livecloudEntities())
                {
                    result = ((from o in livecloudEntities.dt_live
                               where o.liveId == this.GameID
                               select o).FirstOrDefault<dt_live>() != null);
                }
                return result;
            }
        }

        private dt_dealer _AnchorInfo
        {
            get;
            set;
        }

        public dt_dealer AnchorInfo
        {
            get
            {
                if (this._AnchorInfo != null)
                {
                    return this._AnchorInfo;
                }
                using (livecloudEntities livecloudEntities = new livecloudEntities())
                {
                    dt_liveList liveStatus = (from s in livecloudEntities.dt_liveList
                                              where s.liveId == this.GameID
                                              select s).FirstOrDefault<dt_liveList>();
                    if (liveStatus == null)
                    {
                        return null;
                    }
                    IQueryable<dt_dealer> source = from d in livecloudEntities.dt_dealer
                                                   where d.id == liveStatus.dealerId
                                                   select d;
                    this._AnchorInfo = source.FirstOrDefault<dt_dealer>();
                }
                return this._AnchorInfo;
            }
        }

        public GetAnchorInfo(HttpRequest request)
        {
            try
            {
                this.GameID = (request.Form["GameID"] ?? "");
            }
            catch
            {
            }
        }
    }
}
