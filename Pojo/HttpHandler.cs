using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public  class HttpHandler
    {
    //    private  String mesUrl = "http://172.18.55.89:9000/bcInterface/test";

        private String mesUrl = ConfigurationManager.AppSettings["mesUrl"];

        private  HttpClient client=new HttpClient();
        public String postHttpForMes(String evt_no, String trx_id, String message)
        {
            StringBuilder inStrbuf = new StringBuilder();

            inStrbuf.Append("[").Append(evt_no).Append("]");
            inStrbuf.Append("[TOMES]");


            inStrbuf.Append("[").Append(trx_id + "_" + "I").Append("]");
            inStrbuf.Append("[inTrx:").Append(message).Append("]");

            //   MultiValueMap<String, String> paramMap = new LinkedMultiValueMap<>();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("trxId", "BCTOMES");
            dic.Add("strInMsg", message);



            String returnMesg = null;


            //paramMap.add("trxId", "BCTOMES");
            //paramMap.add("strInMsg", message);

            return ";";



            return "";
        }

        public string DoPostIVT(Ew09 ew09)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew09);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public string DoPostDIF1(Ew03New ew03)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew03);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DoPostAdd(EWAdd ew03)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew03);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DoPostEH08(EH08 ew03)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew03);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public string DoPost1(Ew03 ew03)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew03);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DoPostPRT(Ew08 ew08)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(ew08);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DoPostTex(ew07 _ew07)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(_ew07);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DoPostTex1(ew071 _ew07)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(_ew07);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DoPostDIF(EH02 eh02)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(eh02);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DoPostMove(Move move)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(move);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BMMOVENOUT" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public string DoPost(Mew03ReqMesList mew03ReqMesList)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();
            
                var x = JsonConvert.SerializeObject(mew03ReqMesList);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result="{"+result+ ",\"trxId"+"\":"+"\"BCTOMES"+"\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DoPostRe(Meh02bcreqcsI meh02)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Dictionary<string, string> dic = new Dictionary<string, string>();

                var x = JsonConvert.SerializeObject(meh02);
                dic.Add("strInMsg", x);

                var result = ParseToString(dic);
                //      HttpContent content = new StringContent(JsonConvert.SerializeObject(dic));
                result = "{" + result + ",\"trxId" + "\":" + "\"BCTOMES" + "\"}";
                HttpContent content = new StringContent(result);

                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage res = client.PostAsync(mesUrl, content).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = res.Content.ReadAsStringAsync().Result;
                    return str;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string ParseToString(IDictionary<string, string> parameters)
        {
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            StringBuilder query = new StringBuilder();
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append("\"").Append(key).Append("\"").Append(":").Append(value).Append(",");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }
    }
}
