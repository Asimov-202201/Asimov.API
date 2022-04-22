using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Courses.Persistence.Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> ListAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task<Course> FindByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Remove(Course course)
        {
            _context.Courses.Remove(course);
        }
    }
}