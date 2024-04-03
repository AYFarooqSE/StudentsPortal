using Newtonsoft.Json;
using StudentPortal_Web.Services.IService;
using System.Net;

namespace StudentPortal_Web.Services
{
    public class BaseService : IBaseService
    {
        public ApiResponse ResponseModel { get; set; }
        private IHttpClientFactory _clientfactory;
        public BaseService(IHttpClientFactory clientfactory)
        {
            this.ResponseModel = new();
            _clientfactory = clientfactory;
        }

        public async Task<T> SendAsync<T>(ApiRequest apirequest)
        {
            try
            {
                var client = _clientfactory.CreateClient("MyAPIClient");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apirequest.ApiUrl);
                if (apirequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apirequest.Data), System.Text.Encoding.UTF8, "application/json");
                }
                switch (apirequest.Type)
                {
                    case StudentPortal_SD.SD.ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case StudentPortal_SD.SD.ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    case StudentPortal_SD.SD.ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Post;
                        break;

                }

                HttpResponseMessage apiresponse = null;
                apiresponse = await client.SendAsync(message);
                var apicontent = await apiresponse.Content.ReadAsStringAsync();
                var ApiResponse = JsonConvert.DeserializeObject<T>(apicontent);

                return ApiResponse;
            }
            catch (Exception ex)
            {
                var dto = new ApiResponse()
                {
                    ErrorMessages=new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess=false
                };
                var ErrorResponse= JsonConvert.SerializeObject(dto);
                var apiresponse = JsonConvert.DeserializeObject<T>(ErrorResponse);
                return apiresponse;
            }
            
        }
    }
}
