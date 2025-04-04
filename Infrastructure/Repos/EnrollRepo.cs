using Application.Contracts;
using Domain.Entity.CourseEntity;
using Domain.EntityVM;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollRepo:IEnrollRepo
    {
        private readonly AppDbContext _context;

        public EnrollRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EnrollStudentAsync(EnrollmentVM request)
        {
            if (request.Action == "register")
            {
                // Register the student
                var enrollment = new Enrollment
                {
                    UserId = request.UserId,
                    CourseId = request.CourseId
                };

                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

                return true;
            }
            else if (request.Action == "unregister")
            {
                // Unregister the student
                var enrollment = await _context.Enrollments
                    .FirstOrDefaultAsync(e => e.UserId == request.UserId && e.CourseId == request.CourseId);

                if (enrollment == null)
                {
                    return false; // Enrollment not found
                }

                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();

                return true;
            }

            throw new ArgumentException("Invalid action");
        }
    }
}
