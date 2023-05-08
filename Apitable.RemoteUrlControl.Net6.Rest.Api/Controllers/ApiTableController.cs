using Microsoft.AspNetCore.Mvc;
using Apitable.RemoteUrlControl.Net6.Rest.Api.Dto;

namespace Apitable.RemoteUrlControl.Net6.Rest.Api.Controllers
{
    public class ApiTableController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        public ApiTableController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [Route("GetFileControl")]
        [HttpGet]
        public async Task<RootResponse> GetFileControl()
        {
            var rValue = Services.Methods.ApiTable.GetFileControl();

            if (rValue != null) return rValue; else return new RootResponse { success = false };
        }

        [Route("AddFileControl")]
        [HttpPost]
        public async Task<RootResponse> AddFileControl([FromBody] List<Fields> addApiTableRequests)
        {
            Task<RootResponse> rValue = Services.Methods.ApiTable.AddFileControl(addApiTableRequests);

            if (rValue != null)
            {
                return await Task.Run(() =>
                {
                    return rValue;
                });
            }
            else return new RootResponse { success = false };
        }

        [Route("UpdateFileControl")]
        [HttpPut]
        public async Task<RootResponse> UpdateFileControl([FromBody] List<Record> addApiTableRequests)
        {
            Task<RootResponse> rValue = Services.Methods.ApiTable.UpdateFileControl(addApiTableRequests);

            if (rValue != null)
            {
                return await Task.Run(() =>
                {
                    return rValue;
                });
            }
            else return new RootResponse { success = false };
        }

        [Route("DeleteFileControl")]
        [HttpDelete]
        public async Task<RootResponse> DeleteFileControl([FromBody] List<string> addApiTableRequests)
        {
            Task<RootResponse> rValue = Services.Methods.ApiTable.DeleteFileControl(addApiTableRequests);

            if (rValue != null)
            {
                return await Task.Run(() =>
                {
                    return rValue;
                });
            }
            else return new RootResponse { success = false };
        }
    }
}