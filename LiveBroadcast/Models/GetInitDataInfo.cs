using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveBroadcast.Models
{
    public class GetInitDataInfo
    {
        public List<string> RequirementList
        {
            get;
            set;
        }

        public Dictionary<string, string> CacheVersionList
        {
            get;
            set;
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

        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public bool GetNewestDataSuccess
        {
            get
            {
                bool result;
                try
                {
                    foreach (string current in this.RequirementList.Distinct<string>())
                    {
                        if (current == "DefaultBarrage")
                        {
                            List<DefaultBarrage> sysBarrageList = DefaultChatMessageManager.GetSysBarrageList();
                            this._DataResult.DataList.Add(current, sysBarrageList);
                            this._DataResult.DataVersionDictionary.Add(current, Utils.MD5(JsonConvert.SerializeObject(sysBarrageList)).Substring(0, 4));
                        }
                    }
                    result = true;
                }
                catch (Exception ex)
                {
                    this._ErrorMessage = ex.Message;
                    result = false;
                }
                return result;
            }
        }

        private InitDataResult _DataResult
        {
            get;
            set;
        }

        public InitDataResult DataResult
        {
            get
            {
                if (this._DataResult != null)
                {
                    return this._DataResult;
                }
                return null;
            }
        }

        public GetInitDataInfo(HttpRequest request)
        {
            this._DataResult = new InitDataResult();
            try
            {
                string text = request.Form["Requirement"] ?? "";
                if (!string.IsNullOrEmpty(text))
                {
                    this.RequirementList = JsonConvert.DeserializeObject<List<string>>(text).Distinct<string>().ToList<string>();
                }
                string text2 = request.Form["CacheData"] ?? "";
                if (!string.IsNullOrEmpty(text2))
                {
                    this.CacheVersionList = JsonConvert.DeserializeObject<Dictionary<string, string>>(text2);
                }
            }
            catch (Exception arg_79_0)
            {
                throw arg_79_0;
            }
            finally
            {
                if (this.RequirementList == null)
                {
                    this.RequirementList = new List<string>();
                }
                if (this.CacheVersionList == null)
                {
                    this.CacheVersionList = new Dictionary<string, string>();
                }
            }
        }

        public void CheckExpiredCache()
        {
            try
            {
                if (this.CacheVersionList.Count > 0)
                {
                    foreach (KeyValuePair<string, string> current in this.CacheVersionList)
                    {
                        string key = current.Key;
                        string value = current.Value;
                        if (key == "DefaultBarrage")
                        {
                            string b = Utils.MD5(JsonConvert.SerializeObject(DefaultChatMessageManager.GetSysBarrageList())).Substring(0, 4);
                            if (value != b && !this.RequirementList.Contains(key))
                            {
                                this.RequirementList.Add(key);
                            }
                            if (value == b && this.RequirementList.Contains(key))
                            {
                                this.RequirementList.Remove(key);
                            }
                        }
                    }
                }
            }
            catch (Exception arg_C6_0)
            {
                throw arg_C6_0;
            }
        }
    }
}
