using Asimov.API.Shared.Domain.Services.Communication;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Teachers.Domain.Services.Communication
{
    public class TeacherResponse : BaseResponse<Teacher>
    {
        public TeacherResponse(string message) : base(message)
        {
        }

        public TeacherResponse(Teacher resource) : base(resource)
        {
        }
    }
}