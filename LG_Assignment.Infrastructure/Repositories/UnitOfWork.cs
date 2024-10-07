using LG_Assignment.Core.Interfaces;
using LG_Assignment.Infrastructure.Data;
using System.Threading.Tasks;

namespace LG_Assignment.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _dbContext;

        public UnitOfWork(TaskDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "DbContext cannot be null");
            Category = new CategoryRepository(dbContext);
            Device = new DeviceRepository(dbContext);
        }

        public ICategoryRepository Category { get; private set; }
        public IDeviceRepository Device { get; private set; }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
