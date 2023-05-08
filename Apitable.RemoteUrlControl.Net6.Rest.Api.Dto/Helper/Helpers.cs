namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Helper
{
    public static class Helpers
    {
        public static DateTime MilisecondToDatetime(long milisecond)
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            //  DateTimeOffset localServerTime = DateTimeOffset.Now;

            DateTimeOffset localServerTime = DateTimeOffset.FromUnixTimeMilliseconds(milisecond).UtcDateTime;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            //  var finalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(localTime, "Turkey Standard Time");

            // DateTime des = finalDate.LocalDateTime;

            return localTime.LocalDateTime;
        }
    }
}