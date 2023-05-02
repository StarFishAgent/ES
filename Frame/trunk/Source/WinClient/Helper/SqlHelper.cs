using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;

namespace WinClient
{
   public static class SqlHelper
    {
        public static string ServerUrl = "http://127.0.0.1:18801/webapi";

        /// <summary>
        /// RtxStr To Byte[] 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToRtxBytes(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default;
            else
            {
                try
                {
                    return Encoding.UTF8.GetBytes(str);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return default;
                }
            }
        }

        /// <summary>
        /// OBJ To String
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public static string ToRtxBytesString(this object obj)
        {
            if (obj is byte[])
            {
                if (obj == default)
                    return default;
                else
                {
                    try
                    {
                        return Encoding.UTF8.GetString((byte[])obj);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        return null;
                    }
                }
            }
            return default;
        }
        public static DataTable ExecuteQuery(this string strSql)
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

        public static DataTable ExecuteQuery(this string strSql, Dictionary<string, object> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, object Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object, Type)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object, string)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object, Type)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object, string)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<DataTable>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, Dictionary<string, object> Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, object Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, List<(string, object)> Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, List<(string, object, Type)> Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, List<(string, object, string)> Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, params (string, object)[] Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, params (string, object, Type)[] Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static List<dynamic> ExecuteQueryListDynamic(this string strSql, params (string, object, string)[] Params)
        {
            List<dynamic> Result = new List<dynamic>();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            var ResultsJson = webClient.UploadString($@"{ServerUrl}/EQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));

            Result = JsonConvert.DeserializeObject<List<dynamic>>(ResultsJson);

            return Result;
        }

        public static void ExecuteNonQuery(this string strSql)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql }));
        }

        public static void ExecuteNonQuery(this string strSql, Dictionary<string, object> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, object Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, List<(string, object)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, List<(string, object, Type)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, List<(string, object, string)> Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, params (string, object)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, params (string, object, Type)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static void ExecuteNonQuery(this string strSql, params (string, object, string)[] Params)
        {
            DataTable Result = new DataTable();

            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/ENQ", JsonConvert.SerializeObject(new { strSql = strSql, Params = Params }));
        }

        public static string UploadFile(this byte[] Bytes, string FileName)
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

        public static void Insert(this string TableName, Dictionary<string, object> Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, object Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, List<(string, object)> Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, List<(string, object, Type)> Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, List<(string, object, string)> Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, params (string, object)[] Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, params (string, object, Type)[] Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static void Insert(this string TableName, params (string, object, string)[] Params)
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept"] = "application/json";
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString($@"{ServerUrl}/Insert", JsonConvert.SerializeObject(new { TableName = TableName, Params = Params }));
        }

        public static Image ToImage(this byte[] Bytes)
        {
            Image Result = null;

            if (Bytes != null)
            {
                Result = Image.FromStream(new MemoryStream(Bytes));
            }

            return Result;
        }

        public static Stream ToStream(this byte[] Bytes)
        {
            Stream Result = null;

            if (Bytes != null)
            {
                Result = new MemoryStream(Bytes);
            }

            return Result;
        }

        public static void ToFile(this byte[] Bytes, string filePath)
        {
            if (Bytes != null)
            {
                File.WriteAllBytes(filePath, Bytes);
            }
        }

        public static byte[] ToBytes(this Image img)
        {
            byte[] Result = null;

            if (img != null)
            {
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    Result = ms.ToArray();
                }
            }

            return Result;
        }

        public static Stream ToStream(this Image img)
        {
            Stream Result = null;

            if (img != null)
            {
                img.Save(Result, ImageFormat.Jpeg);
            }

            return Result;
        }

        public static void ToFile(this Image img, string filePath)
        {
            if (img != null)
            {
                img.Save(filePath);
            }
        }

        public static byte[] ToBytes(this Stream stream)
        {
            byte[] Result = null;

            if (stream != null)
            {
                Result = new byte[stream.Length];
                stream.Read(Result, 0, Result.Length);
            }

            return Result;
        }

        public static Image ToImage(this Stream stream)
        {
            Image Result = null;

            if (stream != null)
            {
                Result = Image.FromStream(stream);
            }

            return Result;
        }

        public static void ToFile(this Stream stream, string filePath)
        {
            if (stream != null)
            {
                var Bytes = stream.ToBytes();
                File.WriteAllBytes(filePath, Bytes);
            }
        }

        public static Image ToImage(this string filePath)
        {
            Image Result = null;

            if (string.IsNullOrWhiteSpace(filePath) == false)
            {
                Result = Image.FromFile(filePath);
            }

            return Result;
        }

        public static Stream ToStream(this string filePath)
        {
            Stream Result = null;

            if (string.IsNullOrWhiteSpace(filePath) == false)
            {
                var Bytes = File.ReadAllBytes(filePath);
                Result = new MemoryStream(Bytes);
            }

            return Result;
        }

        public static byte[] ToBytes(this string filePath)
        {
            byte[] Result = null;

            if (string.IsNullOrWhiteSpace(filePath) == false)
            {
                Result = File.ReadAllBytes(filePath);
            }

            return Result;
        }
       
    }
}
