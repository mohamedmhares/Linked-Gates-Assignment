using LG_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<DeviceCategory>> GetAllCategoriesAsync();
        Task<DeviceCategory> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(DeviceCategory category);
        Task UpdateCategoryAsync(DeviceCategory category);
        Task DeleteCategoryAsync(int id);
    }
}
