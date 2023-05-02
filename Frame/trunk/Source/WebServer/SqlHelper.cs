using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServer
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [DisableRequestSizeLimit]
    public static class SqlHelper
    {
        public static string strConn = "Data Source=.;Initial Catalog=kuade-Exam; Integrated Security=SSPI;";

        public static DataTable ExecuteQuery(this string strSql)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, Dictionary<string, object> Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Key;
                    var Value = item.Value;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, object Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params.GetType().GetProperties())
                {
                    var Key = item.Name;
                    var Value = item.GetValue(Params);
                    var ValueType = item.PropertyType.FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object)> Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object, Type)> Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image))
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]))
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image))
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, List<(string, object, string)> Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object)[] Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object, Type)[] Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image))
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]))
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image))
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static DataTable ExecuteQuery(this string strSql, params (string, object, string)[] Params)
        {
            var Result = new DataTable();

            var dba = new SqlDataAdapter(strSql, strConn);
            var cmd = dba.SelectCommand;
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            dba.Fill(Result);

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, Dictionary<string, object> Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Key;
                    var Value = item.Value;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, object Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params.GetType().GetProperties())
                {
                    var Key = item.Name;
                    var Value = item.GetValue(Params);
                    var ValueType = item.PropertyType.FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, List<(string, object)> Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, List<(string, object, string)> Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, params (string, object)[] Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = Value.GetType().FullName;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int ExecuteNonQuery(this string strSql, params (string, object, string)[] Params)
        {
            var Result = 0;

            var conn = new SqlConnection(strConn);
            conn.Open();

            var cmd = new SqlCommand(strSql, conn);
            if (Params != null)
            {
                foreach (var item in Params)
                {
                    var Key = item.Item1;
                    var Value = item.Item2;
                    var ValueType = item.Item3;

                    if (Value == null)
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else if (ValueType == typeof(byte[]).FullName)
                        {
                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, DBNull.Value);
                        }
                    }
                    else
                    {
                        if (ValueType == typeof(Image).FullName)
                        {
                            var img = (Image)Value;
                            byte[] PhotoBytes = null;
                            if (img != null)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    img.Save(ms, ImageFormat.Bmp);
                                    PhotoBytes = ms.ToArray();
                                }
                            }

                            cmd.Parameters.Add(Key, SqlDbType.Image).Value = PhotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Key, Value);
                        }
                    }
                }
            }
            Result = cmd.ExecuteNonQuery();

            conn.Close();

            return Result;
        }

        public static int Insert(this string TableName, Dictionary<string, object> Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Count > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Key;
                    var ColValue = keys.Value;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, object Parameters)
        {
            var Result = 0;

            if (Parameters != null)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters.GetType().GetProperties())
                {
                    var ColName = keys.Name;
                    var ColValue = keys.GetValue(Parameters);
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, List<(string, object)> Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Count > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, List<(string, object, Type)> Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Count > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, List<(string, object, string)> Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Count > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, params (string, object)[] Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Length > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, params (string, object, Type)[] Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Length > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }

        public static int Insert(this string TableName, params (string, object, string)[] Parameters)
        {
            var Result = 0;

            if (Parameters != null && Parameters.Length > 0)
            {
                var strInsert = "";

                var ColumnNames = new StringBuilder();
                var ColumnValues = new StringBuilder();

                foreach (var keys in Parameters)
                {
                    var ColName = keys.Item1;
                    var ColValue = keys.Item2;
                    var ParamName = "@" + ColName;

                    ColumnNames.Append(ColName + ",");
                    ColumnValues.Append(ParamName + ",");
                }

                var strColumnNames = ColumnNames.ToString().TrimEnd(new char[] { '，', ',', ' ' });
                var strColumnValues = ColumnValues.ToString().TrimEnd(new char[] { '，', ',', ' ' });

                var sb = new StringBuilder();
                sb.Append("insert into " + TableName);
                sb.Append("(");
                sb.Append(strColumnNames);
                sb.Append(")");
                sb.Append(" values (");
                sb.Append(strColumnValues);
                sb.Append(")");
                strInsert = sb.ToString();

                Result = ExecuteNonQuery(strInsert, Parameters);
            }

            return Result;
        }
    }
}
