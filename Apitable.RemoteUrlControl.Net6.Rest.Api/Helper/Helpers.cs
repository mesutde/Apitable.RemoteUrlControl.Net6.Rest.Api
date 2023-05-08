using Newtonsoft.Json;

namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Helper
{
    public static class Helpers
    {
        public static DateTime MilisecondToDatetime(long milisecond)
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            return localTime.UtcDateTime;
        }

        public static List<T> ReadAll<T>(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());

                return data;
            }
        }

        public static List<T> Read<T>(string path, Func<T, bool> f)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd()).Where(f).ToList();

                return data;
            }
        }
    }
}