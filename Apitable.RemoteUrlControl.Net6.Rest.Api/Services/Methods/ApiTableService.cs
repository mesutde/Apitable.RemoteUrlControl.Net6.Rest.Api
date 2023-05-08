using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Apitable.RemoteUrlControl.Net6.Rest.Api.Dto;

namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Services.Methods
{
    public static class ApiTable
    {
        public static string BearerAPITOKEN = "--";
        public static string APIURL = "https://apitable.com/fusion/v1/datasheets/xxxxxxxxxxx";
        public static string DeleteAPIURL = "https://apitable.com/fusion/v1/datasheets/xxxxxxxxx/records?";

        public static RootResponse GetFileControl()
        {
            try
            {
                string apiBaseUri = APIURL;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiBaseUri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", string.Format("Bearer {0}", BearerAPITOKEN));
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var setramReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = setramReader.ReadToEnd();
                    var FileControl = JsonConvert.DeserializeObject<RootResponse>(result);
                    return FileControl;
                }
            }
            catch (Exception ex)
            {
                return new RootResponse { success = false, message = ex.Message };
            }
        }

        public static async Task<RootResponse> AddFileControl(List<Fields> addApiTableRequest)
        {
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                List<Record> records = new List<Record>();

                foreach (var item in addApiTableRequest)
                {
                    Record record = new Record();
                    record.fields = item;
                    records.Add(record);
                }

                Root root = new Root();
                root.records = records;
                root.fieldKey = "name";

                var texst = JsonConvert.SerializeObject(root);

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(texst, Encoding.UTF8, "application/json");

                      
                        client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", BearerAPITOKEN);

                        var response = await client.PostAsync(APIURL, content);
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<RootResponse>(jsonString);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return new RootResponse { success = false, message = ex.Message };
                }

                return null;
            }
            catch (Exception ex)
            {
                // return new RootResponse { success = false, message = ex.Message };
                return new RootResponse { success = false, message = ex.Message };
            }
        }

        public static async Task<RootResponse> UpdateFileControl(List<Record> recordsx)
        {
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                List<Record> records = new List<Record>();

                foreach (var item in recordsx)
                {
                    Record record = new Record();
                    record.fields = item.fields;
                    record.recordId = item.recordId;
                    records.Add(record);
                }

                Root root = new Root();
                root.records = records;
                root.fieldKey = "name";

                var texst = JsonConvert.SerializeObject(root, Formatting.None,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

                using (var client = new HttpClient())
                {
                    var content = new StringContent(texst, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization =
new AuthenticationHeaderValue("Bearer", BearerAPITOKEN);

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Patch,
                        RequestUri = new Uri(APIURL),
                        Content = content
                    };

                    try
                    {
                        var response = await client.SendAsync(request);
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<RootResponse>(jsonString);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        // Failed
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // return new RootResponse { success = false, message = ex.Message };
                return new RootResponse { success = false, message = ex.Message };
            }
        }

        public static async Task<RootResponse> DeleteFileControl(List<string> recordsID)
        {
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                //string vRecords = string.Empty;

                //foreach (var record in recordsID)
                //{
                //    vRecords += "recordIds=" + record.ToString();

                //}

                string vRecords = "recordIds=" + string.Join("&recordIds=", recordsID);

                using (var client = new HttpClient())
                {
                    //var content = new StringContent(texst, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization =
new AuthenticationHeaderValue("Bearer", BearerAPITOKEN);

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(DeleteAPIURL + vRecords),
                    };

                    try
                    {
                        var response = await client.SendAsync(request);
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<RootResponse>(jsonString);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        // Failed
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // return new RootResponse { success = false, message = ex.Message };
                return new RootResponse { success = false, message = ex.Message };
            }
        }
    }
}