namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Dto
{
    public class Fields
    {
        private DateTime updateDateTime;

        public string excelUrl { get; set; }

        public int UpdateVersion { get; set; }

        public DateTime UpdateDateTime
        {
            get
            {
                return Helper.Helpers.MilisecondToDatetime(UpdateTime);
            }
            set
            {
                this.updateDateTime = value;
            }
        }

        public long UpdateTime { get; set; }
    }
}