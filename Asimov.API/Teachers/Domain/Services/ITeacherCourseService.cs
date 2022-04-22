using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;

namespace Asimov.API.Teachers.Domain.Services
{
    public interface ITeacherCourseService
    {
        Task<IEnumerable<Course>> ListByTeacherId(int teacherId);
    }
}