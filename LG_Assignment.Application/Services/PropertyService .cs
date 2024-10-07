using LG_Assignment.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ICategoryService _categoryService;

        public PropertyService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<PropertyItem>> GetPropertiesForCategoryAsync(int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            return category?.PropertyItems?.ToList() ?? new List<PropertyItem>();
        }
    }
}
