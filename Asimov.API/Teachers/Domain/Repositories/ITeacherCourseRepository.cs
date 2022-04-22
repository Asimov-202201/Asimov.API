using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Teachers.Domain.Repositories
{
    public interface ITeacherCourseRepository
    {
        public Task<IEnumerable<TeacherCourse>> FindByTeacherId(int teacherId);
    }
}