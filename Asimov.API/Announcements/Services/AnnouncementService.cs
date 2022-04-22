using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Announcements.Domain.Repositories;
using Asimov.API.Announcements.Domain.Services;
using Asimov.API.Announcements.Domain.Services.Communication;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Shared.Domain.Repositories;

namespace Asimov.API.Announcements.Services
{
    public class AnnouncementService :IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IDirectorRepository directorRepository, IUnitOfWork unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _announcementRepository.ListAsync();
        }

        public async Task<IEnumerable<Announcement>> ListByDirectorIdAsync(int directorId)
        {
            return await _announcementRepository.FindByDirectorId(directorId);
        }

        public async Task<AnnouncementResponse> SaveAsync(Announcement announcement)
        {
            var existingDirector = _directorRepository.FindByIdAsync(announcement.DirectorId);

            if (existingDirector == null)
                return new AnnouncementResponse("Invalid Director");

            try
            {
                await _announcementRepository.AddAsync(announcement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(announcement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while saving the announcement: {e.Message}");
            }
        }

        public async Task<AnnouncementResponse> UpdateAsync(int id, Announcement announcement)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);

            if (existingAnnouncement == null)
                return new AnnouncementResponse("Announcement not found");
            
            var existingDirector = _directorRepository.FindByIdAsync(announcement.DirectorId);

            if (existingDirector == null)
                return new AnnouncementResponse("Invalid Director");

            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Description = announcement.Description;
            existingAnnouncement.DirectorId = announcement.DirectorId;

            try
            {
                _announcementRepository.Update(existingAnnouncement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(existingAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while updating the announcement: {e.Message}");
            }
        }

        public async Task<AnnouncementResponse> DeleteAsync(int id)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);

            if (existingAnnouncement == null)
                return new AnnouncementResponse("Announcement not found");
            
            try
            {
                _announcementRepository.Remove(existingAnnouncement);
                await _unitOfWork.CompleteAsync();

                return new AnnouncementResponse(existingAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while deleting the announcement: {e.Message}");
            }
        }
    }
}