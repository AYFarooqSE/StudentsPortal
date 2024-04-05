using StudentPortal_Web.Models;
using StudentPortal_Web.Models.Dto;

namespace StudentPortal_Web.Services.IService
{
    public interface IStudentService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int ID);
        Task<T> CreateAsync<T>(StudentCreateDto model);
        Task<T> DeleteAsync<T>(int? ID);
        Task<T> UpdateAsync<T>(StudentUpdateDto model);
    }
}
