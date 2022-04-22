using Asimov.API.Competences.Domain.Models;
using Asimov.API.Shared.Domain.Services.Communication;

namespace Asimov.API.Competences.Domain.Services.Communication
{
    public class CompetenceResponse : BaseResponse<Competence>
    {
        public CompetenceResponse(string message) : base(message)
        {
        }

        public CompetenceResponse(Competence resource) : base(resource)
        {
        }
    }
}