using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Directors.Domain.Services;
using Asimov.API.Directors.Domain.Services.Communication;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Security.Exceptions;
using Asimov.API.Shared.Domain.Repositories;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Asimov.API.Directors.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponseDirector> Authenticate(AuthenticateRequest request)
        {
            var director = await _directorRepository.FindByEmailAsync(request.Email);
            
            if (director == null || !BCryptNet.Verify(request.Password, director.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            var response = _mapper.Map<AuthenticateResponseDirector>(director);
            response.Token = _jwtHandler.GenerateTokenForDirector(director);
            return response;
        }

        public async Task<IEnumerable<Director>> ListAsync()
        {
            return await _directorRepository.ListAsync();
        }

        public async Task<Director> GetByIdAsync(int id)
        {
            var director = await _directorRepository.FindByIdAsync(id);
            if (director == null) throw new KeyNotFoundException("User not found");
            return director;
        }

        public async Task RegisterAsync(RegisterRequestDirector request)
        {
            if (_directorRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            var director = _mapper.Map<Director>(request);
            
            director.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            try
            {
                await _directorRepository.AddAsync(director);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequestDirector request)
        {
            var director = GetById(id);
            
            if (_directorRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            if (!string.IsNullOrEmpty(request.Password))
                director.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            _mapper.Map(request, director);
            
            try
            {
                _directorRepository.Update(director);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var director = GetById(id);
            
            try
            {
                _directorRepository.Remove(director);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");
            }
        }
        
        private Director GetById(int id)
        {
            var director = _directorRepository.FindById(id);
            if (director == null) throw new KeyNotFoundException("Director not found.");
            return director;
        }
    }
}