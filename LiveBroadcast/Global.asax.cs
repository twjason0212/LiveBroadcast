using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using LiveBroadcast.Models;
using TestAPI20171114.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Configuration;

namespace LiveBroadcast
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //using (var db = new livecloudEntities())
            //{
            //    // var SSS = (from dd in db.dt_liveList select dd);
            //    StaticTables.sdt_SensitiveSentences = (from p in db.dt_SensitiveSentences select p).ToList();
            //    StaticTables.sdt_SensitiveWords = (from p in db.dt_SensitiveWords select p).ToList();
            //    StaticTables.sdt_UserBarrageNoSpeak = (from p in db.dt_UserBarrageNoSpeak select p).ToList();
            //    StaticTables.sdt_BlackWords = (from p in db.dt_BlackWords select p).ToList();
            //}

            //ProcessBlockLogEmptyData();

            StaticObject.ReportUri = ConfigurationManager.AppSettings["ReportUri"] ?? "";
        }

       
    }
}
