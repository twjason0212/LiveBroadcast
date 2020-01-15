using LiveBroadcast.Models;
using ReportWebAPI.ReportModel;
using ReportWebAPI.ReportViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace LiveBroadcast.Controllers
{
    public class GetAnchor
    {
        public GetAnchor()
        {
        }

        public DafaResult Post(HttpRequest request)
        {
            //var request = HttpContext.Current.Request;
            DafaResult dafaResult = new DafaResult()
            {
                Code = -1,
                StrCode = ""
            };
            try
            {
                GetAnchorInfo getAnchorInfo = new GetAnchorInfo(request);
                Log.Info("GetAnchorInfo", "GetAnchorInfo", getAnchorInfo.GameID, " - ");
                if (getAnchorInfo.IsValid)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    decimal minusOne = new decimal();
                    try
                    {
                        stopwatch.Reset();
                        stopwatch.Start();
                        NewResultInfoT<AnchorReport> anchorReport = LiveReport.GetAnchorReport<AnchorReport>();
                        List<dt_anchor_tip_record> dtAnchorTipRecords = anchorReport.data.result.ConvertAnchor<dt_anchor_tip_record>();
                        if (dtAnchorTipRecords != null && anchorReport.data.result.Count > 0)
                        {
                            dt_anchor_tip_record dtAnchorTipRecord = (
                                from x in dtAnchorTipRecords
                                where x.anchor_id == getAnchorInfo.AnchorInfo.id
                                select x).FirstOrDefault<dt_anchor_tip_record>();
                            minusOne = Math.Floor((dtAnchorTipRecord != null ? dtAnchorTipRecord.tipmoney_thismonth : decimal.Zero));
                        }
                        if (getAnchorInfo.AnchorInfo.id == 0)
                        {
                            minusOne = new decimal();
                        }
                        stopwatch.Stop();
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        stopwatch.Stop();
                        minusOne = decimal.MinusOne;
                        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                        Log.Info("GetAnchorInfo", string.Format("LiveAfterWebService TimeOut:{0}", elapsedMilliseconds.ToString()), exception.Message, " - ");
                    }
                    var variable = new { Type = "AnchorInfo", ID = getAnchorInfo.AnchorInfo.id, Name = getAnchorInfo.AnchorInfo.dealerName, Photo = getAnchorInfo.AnchorInfo.img, Image = getAnchorInfo.AnchorInfo.img2, Age = getAnchorInfo.AnchorInfo.age, Sex = getAnchorInfo.AnchorInfo.sex, City = getAnchorInfo.AnchorInfo.area, Height = (int)getAnchorInfo.AnchorInfo.height, Weight = (int)getAnchorInfo.AnchorInfo.weight, BWH = getAnchorInfo.AnchorInfo.bwh, Bouns = minusOne };
                    dafaResult.Code = 1;
                    dafaResult.StrCode = "数据获取成功";
                    dafaResult.BackData = variable;
                }
                else
                {
                    Log.Info("GetAnchorInfo", "GetAnchorInfo", string.Concat("校驗失敗:", getAnchorInfo.ErrorMessage), " - ");
                    dafaResult.Code = -1;
                    dafaResult.StrCode = getAnchorInfo.ErrorMessage;
                }
            }
            catch (Exception exception2)
            {
                Log.Info("GetAnchorInfo", "GetAnchorInfo 出錯", exception2.Message, " - ");
                dafaResult.Code = -2;
                dafaResult.StrCode = "执行过程中发生错误！";
            }
            return dafaResult;
        }
    }
}