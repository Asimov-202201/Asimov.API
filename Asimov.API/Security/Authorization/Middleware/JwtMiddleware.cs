using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Services;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Security.Authorization.Settings;
using Asimov.API.Teachers.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Asimov.API.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context, IDirectorService directorService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var directorId = handler.ValidateToken(token);
            if (directorId != null)
            {
                context.Items["Director"] = await directorService.GetByIdAsync(directorId.Value);
            }

            await _next(context);
        }
    }
}