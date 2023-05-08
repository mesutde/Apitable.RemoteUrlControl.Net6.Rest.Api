namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Services.Response
{
    public class Failure<T> : Response<T>
    {
        public Failure(string comment, string message = "Hata")
        {
            Result = false;
            ResultCode = -1;
            Message = message;
            Comment = comment;
        }
    }
}