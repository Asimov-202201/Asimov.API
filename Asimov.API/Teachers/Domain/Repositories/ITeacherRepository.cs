using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Teachers.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task AddAsync(Teacher teacher);
        Task<Teacher> FindByIdAsync(int id);
        Task<Teacher> FindByEmailAsync(string email);
        public bool ExistByEmail(string email);
        public Teacher FindById(int id);
        Task<IEnumerable<Teacher>> FindByDirectorId(int directorId);
        void Update(Teacher teacher);
        void Remove(Teacher teacher);
    }
}