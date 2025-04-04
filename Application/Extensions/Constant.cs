
namespace Application.Extensions
{
    public static class Constant
    {
        public const string RegisterRoute = "api/account/identity/create";
        public const string LoginRoute = "api/account/identity/login";
        public const string RefreshTokenRoute = "api/account/identity/refresh-token";
        public const string GetRolesRoute = "api/account/identity/role/list";
        public const string CreateRoleRoute = "api/account/identity/role/create";
        public const string CreateAdminRoute = "setting";
        public const string BrowserStorageKey = "x-key";
        public const string HttpClientName = "WebUIClient";
        public const string HttpClientHeaderScheme = "Bearer";
        public const string AuthenticationType = "JwtAuth";
        public const string GetUserWithRolesRoute = "api/account/identity/users-with-roles";
        public const string ChangeUserRoleRoute = "api/account/identity/change-role";
        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        public const string AddCourse = "api/courses/create-course";
        public const string GetRegisteredCourse = "api/courses/registered-courses";
        public const string GetCourse = "api/courses/get-course";

        public const string EditCourse = "api/courses/edit-course";
        public const string DeleteCourse = "api/courses/delete-course";

        public const string EnrollStudent = "/api/Enrollments/enroll-course";
        
    }
}
