using Application.Contracts;
using Application.DTOs.Response;
using Domain.Entity.CourseEntity;
using Domain.EntityVM;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo _courseRepository;

        public CoursesController(ICourseRepo courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet("get-course/{UserId}")]
        public async Task<ActionResult<List<CourseVM>>> GetCourses(string UserId)
        {
            var courses = await _courseRepository.GetCoursesAsync(UserId);
            return Ok(courses);
        }
        [HttpGet("registered-courses/{userId}")]
        public async Task<ActionResult<List<CourseVM>>> GetRegisteredCourses(string userId)
        {
            var courses = await _courseRepository.GetRegisteredCoursesAsync(userId);
            return Ok(courses);
        }

        [HttpPost("create-course")]
        public async Task<ActionResult<GeneralResponse>> CreateCourse(CourseVM courseVM)
        {
            if (courseVM == null)
            {
                return BadRequest();
            }
            var createdCourseResponse = await _courseRepository.CreateCourseAsync(courseVM);
            return Ok(createdCourseResponse);
        }

        [HttpPut("edit-course/{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateCourse(int id, CourseVM courseVM)
        {
            if (id != courseVM.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _courseRepository.UpdateCourseAsync(courseVM);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

             
        }

        [HttpDelete("delete-course/{id}")]
        public async Task<ActionResult<GeneralResponse>> DeleteCourse(int id)
        {
            try
            {
                return await _courseRepository.DeleteCourseAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            
        }
    }
}
