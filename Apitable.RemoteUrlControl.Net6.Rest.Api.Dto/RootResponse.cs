namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Dto
{
    public class RootResponse
    {
        public int code { get; set; }
        public bool success { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}