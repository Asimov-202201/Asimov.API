using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Items.Domain.Repositories;
using Asimov.API.Items.Domain.Services;
using Asimov.API.Items.Domain.Services.Communication;
using Asimov.API.Shared.Domain.Repositories;

namespace Asimov.API.Items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _itemRepository.ListAsync();
        }

        public async Task<IEnumerable<Item>> ListByCourseIdAsync(int courseId)
        {
            return await _itemRepository.FindByCourseId(courseId);
        }

        public async Task<ItemResponse> SaveAsync(Item item)
        {
            var existingCourse = _courseRepository.FindByIdAsync(item.CourseId);

            if (existingCourse == null)
                return new ItemResponse("Invalid Course");

            try
            {
                await _itemRepository.AddAsync(item);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(item);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error occurred while saving the item: {e.Message}");
            }
        }

        public async Task<ItemResponse> UpdateAsync(int id, Item item)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);

            if (existingItem == null)
                return new ItemResponse("Item not found");
            
            var existingCourse = _courseRepository.FindByIdAsync(item.CourseId);

            if (existingCourse == null)
                return new ItemResponse("Invalid Course");

            existingItem.Name = item.Name;
            existingItem.Value = item.Value;
            existingItem.State = item.State;
            existingItem.CourseId = item.CourseId;

            try
            {
                _itemRepository.Update(existingItem);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(existingItem);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error occurred while updating the item: {e.Message}");
            }
        }

        public async Task<ItemResponse> DeleteAsync(int id)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);

            if (existingItem == null)
                return new ItemResponse("Item not found");
            
            try
            {
                _itemRepository.Remove(existingItem);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(existingItem);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error occurred while deleting the item: {e.Message}");
            }
        }
    }
}