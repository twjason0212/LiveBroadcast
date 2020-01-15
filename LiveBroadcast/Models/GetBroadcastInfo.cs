using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveBroadcast.Models
{
    public class GetBroadcastInfo
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

        private List<dt_AdminBroadcastLog> _BroadcastList
        {
            get;
            set;
        }

        public List<dt_AdminBroadcastLog> BroadcastList
        {
            get
            {
                if (this._BroadcastList != null)
                {
                    return this._BroadcastList;
                }
                DateTime now = DateTime.Now;
                using (livecloudEntities livecloudEntities = new livecloudEntities())
                {
                    int tempGameId = int.Parse(this.GameID);
                    List<dt_AdminBroadcastLog> broadcastList = (from b in livecloudEntities.dt_AdminBroadcastLog
                                                                where b.LiveId == tempGameId && (int)b.Status > 0 && b.StartTime <= now && b.EndTime > now
                                                                orderby b.LiveId descending
                                                                select b).ToList<dt_AdminBroadcastLog>();
                    this._BroadcastList = broadcastList;
                }
                return this._BroadcastList;
            }
        }

        public GetBroadcastInfo(HttpRequest request)
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
