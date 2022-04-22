using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Teachers.Persistence.Repositories
{
    public class TeacherCourseRepository : BaseRepository, ITeacherCourseRepository
    {
        public TeacherCourseRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<TeacherCourse>> FindByTeacherId(int teacherId)
        {
            return await _context.TeacherCourses
                .Where(p => p.TeacherId == teacherId)
                .Include(p => p.Course)
                .ToListAsync();
        }
    }
}