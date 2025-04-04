using Application.DTOs.Response;
using Domain.EntityVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICourseRepo
    {
        Task<List<CourseVM>> GetRegisteredCoursesAsync(string userId);
        Task<List<CourseVM>> GetCoursesAsync(string userId);
        Task<GeneralResponse> CreateCourseAsync(CourseVM courseVM);
        Task<GeneralResponse> UpdateCourseAsync(CourseVM courseVM);
        Task<GeneralResponse> DeleteCourseAsync(int id);
    }
}
