using LiveBroadcast.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace LiveBroadcast.Controllers
{
    public static class LiveReport
    {
        public static string ReportUri = ConfigurationManager.AppSettings["NewReportUri"] ?? "http://3.0.64.219:8001/v1/report/anchorReport";

        public static NewResultInfoT<T> GetAnchorReport<T>()
        {
            return JsonConvert.DeserializeObject<NewResultInfoT<T>>(LiveReport.GetReport());
        }

        public static string GetReport()
        {
            string result;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 1);
                    httpClient.DefaultRequestHeaders.Add("authorization", "token {api token}");
                    new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                    result = httpClient.GetAsync(LiveReport.ReportUri).Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
    }
}
