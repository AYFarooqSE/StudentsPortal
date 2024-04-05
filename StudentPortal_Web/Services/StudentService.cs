using StudentPortal_SD;
using StudentPortal_Web.Models;
using StudentPortal_Web.Models.Dto;
using StudentPortal_Web.Services.IService;

namespace StudentPortal_Web.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private IHttpClientFactory _ClientFactory;
        private string BaseUrl = string.Empty;
        public StudentService(IHttpClientFactory ClientFactory,IConfiguration config):base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            BaseUrl = config.GetValue<string>("ServiceUrls:StudentsAPIUrl");
        }
        public Task<T> CreateAsync<T>(StudentCreateDto model)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiUrl = BaseUrl+ "/api/Students",
                Data = model,
                Type=SD.ApiType.Post
            });
        }

        public Task<T> DeleteAsync<T>(int? ID)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiUrl = BaseUrl + "/api/Students/"+ID,
                Type = SD.ApiType.Delete
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiUrl = BaseUrl + "/api/Students",
                Type = SD.ApiType.Get
            });
        }

        public Task<T> GetAsync<T>(int ID)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiUrl = BaseUrl + "/api/Students/" + ID,
                Type = SD.ApiType.Get
            });
        }

        public Task<T> UpdateAsync<T>(StudentUpdateDto model)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiUrl = BaseUrl + "/api/Students/"+model.ID,
                Data = model,
                Type = SD.ApiType.Put
            });
        }
    }
}
