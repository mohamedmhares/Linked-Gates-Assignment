using LG_Assignment.Core.Entity;
using LG_Assignment.Core.Interfaces;
using LG_Assignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LG_Assignment.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<DeviceCategory>, ICategoryRepository
    {
        private readonly TaskDbContext _dbContext;
        public CategoryRepository(TaskDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(DeviceCategory deviceCategory)
        {
            var categoryDB = await _dbContext.DeviceCategories.FirstOrDefaultAsync(x => x.Id == deviceCategory.Id);
            if (categoryDB != null)
            {
                _dbContext.Entry(categoryDB).CurrentValues.SetValues(deviceCategory);
            }
            else
            {
                throw new KeyNotFoundException($"DeviceCategory with Id {deviceCategory.Id} not found.");
            }
        }
    }
}
