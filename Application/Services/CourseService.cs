using Application.DTOs.Response;
using Application.Extensions;
using Application.Services;
using Domain.EntityVM;
using System.Net.Http.Json;

namespace Application.Services
{
    public class CourseService(HttpClientService httpClientService) : ICourseService
    {
        private async Task<HttpClient> PrivateClient() => (await httpClientService.GetPrivateClient());

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return $"Sorry unknown error occurred.{Environment.NewLine}Error Description:{Environment.NewLine}Status Code: {response.StatusCode}{Environment.NewLine}Reason Phrase: {response.ReasonPhrase}";
            return null;
        }

        private static GeneralResponse ErrorOperation(string message) => new(false, message);

        public async Task<IEnumerable<CourseVM>> GetCoursesAsync(string UserId)
            => await (await PrivateClient()).GetFromJsonAsync<IEnumerable<CourseVM>>($"{Constant.GetCourse}/{UserId}");
        public async Task<IEnumerable<CourseVM>> GetRegisteredCoursesAsync(string UserId)
            => await (await PrivateClient()).GetFromJsonAsync<IEnumerable<CourseVM>>($"{Constant.GetRegisteredCourse}/{UserId}");
        public async Task<GeneralResponse> AddCourseAsync(CourseVM model)
        {
            var result = await (await PrivateClient()).PostAsJsonAsync(Constant.AddCourse, model);
            var errorMessage = CheckResponseStatus(result);
            if (!string.IsNullOrEmpty(errorMessage)) return ErrorOperation(errorMessage);
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> EditCourseAsync(CourseVM model)
        {
            var result = await (await PrivateClient()).PutAsJsonAsync($"{Constant.EditCourse}/{model.Id}", model);
            var errorMessage = CheckResponseStatus(result);
            if (!string.IsNullOrEmpty(errorMessage)) return ErrorOperation(errorMessage);
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> DeleteCourseAsync(int id)
        {
            var result = await (await PrivateClient()).DeleteAsync($"{Constant.DeleteCourse}/{id}");
            var errorMessage = CheckResponseStatus(result);
            if (!string.IsNullOrEmpty(errorMessage)) return ErrorOperation(errorMessage);
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }
    }
}
