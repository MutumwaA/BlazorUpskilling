using Application.DTOs.Response;
using Application.Extensions;
using Application.Services;
using Domain.Entity.CourseEntity;
using Domain.Entity.VehicleEntity;
using Domain.EntityVM;
using System;
using System.Net.Http.Json;

namespace Application.Services
{
    public class EnrollmentService :IEnrollmentService
    {
        private readonly HttpClientService _httpClientService;
        public EnrollmentService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            
        }
        private async Task<HttpClient> PrivateClient() => await _httpClientService.GetPrivateClient();
        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return $"Sorry, an unknown error occurred.{Environment.NewLine}Error Description:{Environment.NewLine}Status Code: {response.StatusCode}{Environment.NewLine}Reason Phrase: {response.ReasonPhrase}";
            return null;
        }
        private static GeneralResponse ErrorOperation(string message) => new(false, message);
        public async Task<GeneralResponse> EnrollStudentAsync(string studentId, int courseId, string action)
        {

            var client = await PrivateClient();
            var enrollmentData = new { UserId = studentId, CourseId = courseId, Action = action };
            var response = await client.PostAsJsonAsync(Constant.EnrollStudent, enrollmentData);

            if (!string.IsNullOrEmpty(CheckResponseStatus(response)))
                return ErrorOperation(CheckResponseStatus(response));

            //return await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return new GeneralResponse(true, "Operation successful.");
        }
    }
}
