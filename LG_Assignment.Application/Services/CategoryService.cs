using LG_Assignment.Core.Entity;
using LG_Assignment.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DeviceCategory>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.Category.GetAllAsync(null, "PropertyItems");

        }

        public async Task<DeviceCategory> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Category.GetSingleAsync(c => c.Id == id, "PropertyItems");
        }

        public async Task AddCategoryAsync(DeviceCategory category)
        {
            _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCategoryAsync(DeviceCategory category)
        {
            var existingCategory = await _unitOfWork.Category.GetSingleAsync(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.PropertyItems = category.PropertyItems;
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                _unitOfWork.Category.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
