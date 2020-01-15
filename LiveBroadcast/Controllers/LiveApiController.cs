using LiveBroadcast.Models;
using Newtonsoft.Json;
using ReportWebAPI.ReportModel;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LiveBroadcast.Controllers
{
    public class LiveApiController : ApiController
    {
        public LiveApiController()
        {
        }

        public DafaResult ProcessRequest()
        {
            var dafaResult = new DafaResult();
            var request = HttpContext.Current.Request;
            // HttpRequestBase request = base.get_HttpContext().Request;
            //DafaResult dafaResult = new DafaResult()
            //{
            //    Code = -1,
            //    StrCode = ""
            //};
            try
            {
                string item = request.Form["Action"] ?? "";
                if (item == "GetAnchor")
                {
                    GetAnchor getAnchor = new GetAnchor();
                    dafaResult = getAnchor.Post(request);
                }
                else if (item == "GetLiveBroadCast")
                {
                    dafaResult = (new GetLiveBroadCast()).Post(request);
                }
                else
                {
                    dafaResult = (item == "GetInitData" ? (new GetInitData()).Post(request) : new DafaResult()
                    {
                        Code = -1,
                        StrCode = "沒有對應街口"
                    });
                }
            }
            catch (Exception exception)
            {
                Log.Error("LiveApi", "LiveApi", exception.Message, " - ");
                dafaResult = new DafaResult()
                {
                    Code = -2,
                    StrCode = "执行过程中发生错误！！！"
                };
            }
            return dafaResult;
        }
    }
}