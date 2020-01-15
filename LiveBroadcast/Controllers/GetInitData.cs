using LiveBroadcast.Models;
using ReportWebAPI.ReportModel;
using System;
using System.Web;

namespace LiveBroadcast.Controllers
{
    public class GetInitData
    {
        public GetInitData()
        {
        }

        public DafaResult Post(HttpRequest request)
        {
            DafaResult dafaResult;
            DafaResult dataList = new DafaResult();
            try
            {
                GetInitDataInfo getInitDataInfo = new GetInitDataInfo(request);
                if (getInitDataInfo.IsValid)
                {
                    getInitDataInfo.CheckExpiredCache();
                    if (!getInitDataInfo.GetNewestDataSuccess)
                    {
                        dataList.Code = -2;
                        dataList.StrCode = string.Concat("执行过程中发生错误！", getInitDataInfo.ErrorMessage);
                    }
                    else
                    {
                        dataList.Code = 1;
                        dataList.StrCode = "数据获取成功";
                        dataList.BackData = getInitDataInfo.DataResult.DataList;
                        dataList.CacheData = getInitDataInfo.DataResult.DataVersionDictionary;
                    }
                    return dataList;
                }
                else
                {
                    Log.Info("GetInitData", "GetInitData", string.Concat("校驗失敗:", getInitDataInfo.ErrorMessage), " - ");
                    dataList.Code = -1;
                    dataList.StrCode = getInitDataInfo.ErrorMessage;
                    dafaResult = dataList;
                }
            }
            catch (Exception exception)
            {
                Log.Info("GetInitData", "GetInitData 出錯", exception.Message, " - ");
                dataList.Code = -2;
                dataList.StrCode = "执行过程中发生错误！";
                dafaResult = dataList;
            }
            return dafaResult;
        }
    }
}