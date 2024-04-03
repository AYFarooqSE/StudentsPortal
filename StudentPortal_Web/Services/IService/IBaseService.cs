namespace StudentPortal_Web.Services.IService
{
    public interface IBaseService
    {
        ApiResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apirequest);
    }
}
