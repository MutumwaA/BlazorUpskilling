
using Application.DTOs.Response;
using Domain.Entity.CourseEntity;
using Domain.Entity.VehicleEntity;
using Domain.EntityVM;


namespace Application.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseVM>> GetCoursesAsync(string UserId);
        Task<IEnumerable<CourseVM>> GetRegisteredCoursesAsync(string UserId);
        
        //Task<CourseVM> GetCourseByIdAsync(int id);
        Task<GeneralResponse> AddCourseAsync(CourseVM course);
        Task<GeneralResponse> EditCourseAsync(CourseVM model);
        Task<GeneralResponse> DeleteCourseAsync(int id);
    }
}
