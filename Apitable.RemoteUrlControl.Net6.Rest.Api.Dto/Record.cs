namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Dto
{
    public class Record
    {
        private DateTime createdAtDateTime;
        private DateTime updatedAtDateTime;

        public Fields fields { get; set; }
        public string? recordId { get; set; }

        public DateTime CreatedAtDateTime
        {
            get
            {
                return Helper.Helpers.MilisecondToDatetime(createdAt);
            }
            set
            {
                this.createdAtDateTime = value;
            }
        }

        public DateTime UpdatedAtDateTime
        {
            get
            {
                return Helper.Helpers.MilisecondToDatetime(updatedAt);
            }
            set
            {
                this.updatedAtDateTime = value;
            }
        }

        public long createdAt { get; set; }
        public long updatedAt { get; set; }
    }
}