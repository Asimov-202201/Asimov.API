using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Competences.Domain.Models;
using Asimov.API.Competences.Domain.Services.Communication;

namespace Asimov.API.Competences.Domain.Services
{
    public interface ICompetenceService
    {
        Task<IEnumerable<Competence>> ListAsync();
        Task<CompetenceResponse> SaveAsync(Competence competence);
        Task<CompetenceResponse> UpdateAsync(int id, Competence competence);
        Task<CompetenceResponse> DeleteAsync(int id);
    }
}