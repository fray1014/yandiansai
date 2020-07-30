using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WFPlot
{
    class Comm
    {
        //contentType application/json or application/xml
        public static string HttpGet(string Url, string contentType)
        {
            try
            {
                string retString = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = contentType;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myResponseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string HttpPost(string Url, string postDataStr, string contentType, out bool isOK)
        {
            string retString = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = contentType;
                request.Timeout = 600000;//设置超时时间
                request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                Stream requestStream = request.GetRequestStream();
                StreamWriter streamWriter = new StreamWriter(requestStream);
                streamWriter.Write(postDataStr);
                streamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                isOK = true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(WebException))//捕获400错误
                {
                    var response = ((WebException)ex).Response;
                    Stream responseStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream);
                    retString = streamReader.ReadToEnd();
                    streamReader.Close();
                    responseStream.Close();
                }
                else
                {
                    retString = ex.ToString();
                }
                isOK = false;
            }

            return retString;
        }
        /// <summary>
        /// 发起httpPost 请求，可以上传文件
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="files">文件</param>
        /// <param name="input">表单数据</param>
        /// <param name="endoding">编码</param>
        /// <returns></returns>
        public static string PostResponse(string url, Dictionary<string, string> input, Encoding endoding)
        {

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.Expect = "";

            MemoryStream stream = new MemoryStream();


            byte[] line = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            byte[] enterER = Encoding.ASCII.GetBytes("\r\n");

            //提交文本字段
            if (input != null)
            {
                string format = "--" + boundary + "\r\nContent-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}\r\n";    //自带项目分隔符
                foreach (string key in input.Keys)
                {
                    string s = string.Format(format, key, input[key]);
                    byte[] data = Encoding.UTF8.GetBytes(s);
                    stream.Write(data, 0, data.Length);
                }

            }

            byte[] foot_data = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");      //项目最后的分隔符字符串需要带上--  
            stream.Write(foot_data, 0, foot_data.Length);



            request.ContentLength = stream.Length;
            Stream requestStream = request.GetRequestStream(); //写入请求数据
            stream.Position = 0L;
            stream.CopyTo(requestStream); //
            stream.Close();

            requestStream.Close();



            try
            {


                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    try
                    {
                        using (var responseStream = response.GetResponseStream())
                        using (var mstream = new MemoryStream())
                        {
                            responseStream.CopyTo(mstream);
                            string message = endoding.GetString(mstream.ToArray());
                            return message;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (WebException ex)
                {
                    //response = (HttpWebResponse)ex.Response;


                    //if (response.StatusCode == HttpStatusCode.BadRequest)
                    //{
                    //    using (Stream data = response.GetResponseStream())
                    //    {
                    //        using (StreamReader reader = new StreamReader(data))
                    //        {
                    //            string text = reader.ReadToEnd();
                    //            Console.WriteLine(text);
                    //        }
                    //    }
                    //}

                    throw ex;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
