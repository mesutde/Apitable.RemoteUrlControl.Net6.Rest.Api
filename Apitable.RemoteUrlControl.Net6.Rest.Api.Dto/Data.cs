namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Dto
{
    public class Data
    {
        public int total { get; set; }
        public List<Record> records { get; set; }
        public int pageNum { get; set; }
        public int pageSize { get; set; }
    }
}