using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Competences.Domain.Models;

namespace Asimov.API.Competences.Domain.Repositories
{
    public interface ICompetenceRepository
    {
        Task<IEnumerable<Competence>> ListAsync();
        Task AddAsync(Competence competence);
        Task<Competence> FindByIdAsync(int id);
        void Update(Competence competence);
        void Remove(Competence competence);
    }
}