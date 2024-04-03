using StudentPortal_SD;
namespace StudentPortal_Web
{
    public class ApiRequest
    {
        public SD.ApiType Type { get; set; }
        public string ApiUrl { get; set; }
        public object Data { get; set; }
    }
}
