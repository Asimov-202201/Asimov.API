using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Services.Communication;

namespace Asimov.API.Courses.Domain.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> ListAsync();
        Task<Course> FindByIdAsync(int id);

        Task<CourseResponse> SaveAsync(Course course);

        Task<CourseResponse> UpdateAsync(int id, Course course);

        Task<CourseResponse> DeleteAsync(int id);
    }
}