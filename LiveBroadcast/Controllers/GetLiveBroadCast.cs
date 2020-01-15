using LiveBroadcast.Models;
using ReportWebAPI.ReportModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace LiveBroadcast.Controllers
{
    public class GetLiveBroadCast
    {
        public GetLiveBroadCast()
        {
        }

        public DafaResult Post(HttpRequest request)
        {

            DafaResult dafaResult = new DafaResult()
            {
                Code = -1,
                StrCode = ""
            };
            try
            {
                GetBroadcastInfo getBroadcastInfo = new GetBroadcastInfo(request);
                Log.Info("GetLiveBroadCast", "GetLiveBroadCast", getBroadcastInfo.GameID, " - ");
                if (getBroadcastInfo.IsValid)
                {
                    var broadcastList =
                        from b in getBroadcastInfo.BroadcastList
                        select new { ID = b.Id, Content = b.BroadcastText, StartTime = b.StartTime, EndTime = b.EndTime };
                    dafaResult.Code = 1;
                    dafaResult.StrCode = "数据获取成功";
                    dafaResult.BackData = broadcastList;
                }
                else
                {
                    Log.Info("GetLiveBroadCast", "GetLiveBroadCast", string.Concat("校驗失敗:", getBroadcastInfo.ErrorMessage), " - ");
                    dafaResult.Code = -1;
                    dafaResult.StrCode = getBroadcastInfo.ErrorMessage;
                }
            }
            catch (Exception exception)
            {
                Log.Info("GetAnchorInfo", "GetAnchorInfo 出錯", exception.Message, " - ");
                dafaResult.Code = -2;
                dafaResult.StrCode = "执行过程中发生错误！";
            }
            return dafaResult;
        }
    }
}