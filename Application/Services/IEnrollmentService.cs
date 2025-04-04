using Application.DTOs.Response;
using Domain.Entity.CourseEntity;
using Domain.Entity.VehicleEntity;
using Domain.EntityVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEnrollmentService
    {
        Task<GeneralResponse> EnrollStudentAsync(string studentId, int courseId,string action);
        
    }
}
