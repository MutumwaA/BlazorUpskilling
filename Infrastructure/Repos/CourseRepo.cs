using Application.Contracts;
using Application.DTOs.Response;
using Domain.Entity.CourseEntity;
using Domain.EntityVM;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class CourseRepo: ICourseRepo
    {
        private readonly AppDbContext _context;

        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }
        private static GeneralResponse OperationSuccessResponse(string message) => new(true, message);
        public async Task<List<CourseVM>> GetCoursesAsync(string userId)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .Select(c => new CourseVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsRegistered = c.Enrollments.Any(e => e.UserId == userId)
                })
                .ToListAsync();
        }
        public async Task<List<CourseVM>> GetRegisteredCoursesAsync(string userId)
        {
            var courses = await _context.Courses
                .Where(c => c.Enrollments.Any(e => e.UserId == userId))
                .Select(c => new CourseVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsRegistered = true
                })
                .ToListAsync();

            return courses;
        }

        public async Task<GeneralResponse> CreateCourseAsync(CourseVM courseVM)
        {
            if (courseVM == null)
            {
                throw new ArgumentNullException(nameof(courseVM));
            }

            var course = new Course
            {
                Name = courseVM.Name,
                Description = courseVM.Description
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return OperationSuccessResponse("Course data saved");
        }

        public async Task<GeneralResponse> UpdateCourseAsync(CourseVM courseVM)
        {
            if (courseVM == null)
            {
                throw new ArgumentNullException(nameof(courseVM));
            }

            var course = await _context.Courses.FindAsync(courseVM.Id);

            if (course == null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            course.Name = courseVM.Name;
            course.Description = courseVM.Description;

            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return OperationSuccessResponse("Course data updated");
        }

        public async Task<GeneralResponse> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return OperationSuccessResponse("Coursee data deleted");
        }
    }
}
