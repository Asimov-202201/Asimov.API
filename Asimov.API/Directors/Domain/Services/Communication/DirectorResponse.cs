using Asimov.API.Directors.Domain.Models;
using Asimov.API.Shared.Domain.Services.Communication;

namespace Asimov.API.Directors.Domain.Services.Communication
{
    public class DirectorResponse : BaseResponse<Director>
    {
        public DirectorResponse(string message) : base(message)
        {
        }

        public DirectorResponse(Director resource) : base(resource)
        {
        }
    }
}