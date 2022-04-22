using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Security.Exceptions;
using Asimov.API.Shared.Domain.Repositories;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Repositories;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Domain.Services.Communication;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Asimov.API.Teachers.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IDirectorRepository directorRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponseTeacher> Authenticate(AuthenticateRequest request)
        {
            var teacher = await _teacherRepository.FindByEmailAsync(request.Email);
            
            if (teacher == null || !BCryptNet.Verify(request.Password, teacher.PasswordHash))
                throw new AppException("Email or password is incorrect.");
            
            var response = _mapper.Map<AuthenticateResponseTeacher>(teacher);
            response.Token = _jwtHandler.GenerateTokenForTeacher(teacher);
            return response;
        }

        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _teacherRepository.ListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _teacherRepository.FindByIdAsync(id);
            if (teacher == null) throw new KeyNotFoundException("User not found");
            return teacher;
        }

        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _teacherRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Teacher>> ListByDirectorIdAsync(int directorId)
        {
            return await _teacherRepository.FindByDirectorId(directorId);
        }

        public async Task RegisterAsync(RegisterRequestTeacher request)
        {
            if (_teacherRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            var teacher = _mapper.Map<Teacher>(request);
            
            teacher.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            try
            {
                await _teacherRepository.AddAsync(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequestTeacher request)
        {
            var teacher = GetById(id);
            
            if (_teacherRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            if (!string.IsNullOrEmpty(request.Password))
                teacher.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            _mapper.Map(request, teacher);
            
            try
            {
                _teacherRepository.Update(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = GetById(id);
            
            try
            {
                _teacherRepository.Remove(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");
            }
        }
        
        private Teacher GetById(int id)
        {
            var teacher = _teacherRepository.FindById(id);
            if (teacher == null) throw new KeyNotFoundException("Teacher not found.");
            return teacher;
        }
    }
    
    
}