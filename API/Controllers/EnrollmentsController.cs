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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollRepo _enrollRepo;

        public EnrollmentsController(IEnrollRepo enrollRepo)
        {
            _enrollRepo = enrollRepo;
        }

        [HttpPost("enroll-course")]
        public async Task<ActionResult> EnrollStudent([FromBody] EnrollmentVM request)
        {
            try
            {
                var result = await _enrollRepo.EnrollStudentAsync(request);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(); // Or another appropriate status code
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
