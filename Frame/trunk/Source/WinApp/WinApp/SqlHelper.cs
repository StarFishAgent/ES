using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

namespace WinApp
{
   public class SqlHelper
    {
        
        public static string ServerUrl = "http://192.168.31.61:18801/webapi";

        public static DataTable EQ(string strSql)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static void ENQ(string strSql)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql }));
        }
        public static string UploadFile(byte[] Bytes, string FileName)
        {
            var hc = new HttpClient(new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } });
            var fd = new MultipartFormDataContent();

            var Key = Guid.NewGuid().ToString();
            fd.Add(new ByteArrayContent(Bytes), Key, FileName);
            fd.Add(new StringContent(JsonConvert.SerializeObject(new
            {
                //AbsolutePath = "",
                //RelativePath = "",
                //FileName = "2.jpg"
            }), Encoding.UTF8), Key);

            var Results = JsonConvert.DeserializeObject<Dictionary<string, object>>(hc.PostAsync($@"{ServerUrl}/UploadFile", fd).Result.Content.ReadAsStringAsync().Result);
            var SavePath = Convert.ToString(Results[Key]);

            return SavePath;
        }
    }
}
