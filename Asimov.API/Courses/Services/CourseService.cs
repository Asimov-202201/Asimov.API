using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Courses.Domain.Services;
using Asimov.API.Courses.Domain.Services.Communication;
using Asimov.API.Shared.Domain.Repositories;

namespace Asimov.API.Courses.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> ListAsync()
        {
            return await _courseRepository.ListAsync();
        }

        public async Task<Course> FindByIdAsync(int id)
        {
            return await _courseRepository.FindByIdAsync(id);
        }

        public async Task<CourseResponse> SaveAsync(Course course)
        {
            try
            {
                await _courseRepository.AddAsync(course);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(course);
            }
            catch (Exception e)
            {
                return new CourseResponse($"An error occurred while saving course: {e.Message}");
            }
        }

        public async Task<CourseResponse> UpdateAsync(int id, Course course)
        {
            var existingCourse = await _courseRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CourseResponse("Course not found");
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Grade = course.Grade;
            existingCourse.State = course.State;

            try
            {
                _courseRepository.Update(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception e)
            {
                return new CourseResponse($"An error occurred while updating course: {e.Message}");
            }
        }

        public async Task<CourseResponse> DeleteAsync(int id)
        {
            var existingCourse = await _courseRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CourseResponse("Course not found");

            try
            {
                _courseRepository.Remove(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception e)
            {
                return new CourseResponse($"An error occurred while deleting course: {e.Message}");
            }
        }
    }
}