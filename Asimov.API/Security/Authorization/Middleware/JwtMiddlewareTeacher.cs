using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Security.Authorization.Settings;
using Asimov.API.Teachers.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Asimov.API.Security.Authorization.Middleware
{
    public class JwtMiddlewareTeacher
    {
        private readonly RequestDelegate _next;

        public JwtMiddlewareTeacher(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context, ITeacherService teacherService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var teacherId = handler.ValidateToken(token);
            if (teacherId != null)
            {
                context.Items["Teacher"] = await teacherService.GetByIdAsync(teacherId.Value);
            }

            await _next(context);
        }
    }
}