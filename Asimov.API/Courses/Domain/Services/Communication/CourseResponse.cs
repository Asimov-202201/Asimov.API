using Asimov.API.Courses.Domain.Models;
using Asimov.API.Shared.Domain.Services.Communication;

namespace Asimov.API.Courses.Domain.Services.Communication
{
    public class CourseResponse : BaseResponse<Course>
    {
        public CourseResponse(string message) : base(message)
        {
        }

        public CourseResponse(Course resource) : base(resource)
        {
        }
    }
}