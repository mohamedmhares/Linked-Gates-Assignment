using LG_Assignment.Core.Entity;
using LG_Assignment.Core.Interfaces;
using LG_Assignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LG_Assignment.Infrastructure.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        private readonly TaskDbContext _dbContext;
        public DeviceRepository(TaskDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(Device device)
        {
            var deviceDB = await _dbContext.Devices.FirstOrDefaultAsync(x => x.Id == device.Id);
            if (deviceDB != null)
            {
                _dbContext.Entry(deviceDB).CurrentValues.SetValues(device);
            }
            else
            {
                throw new KeyNotFoundException($"Device with Id {device.Id} not found.");
            }
        }

        public async Task<Device> GetSingleAsync(Expression<Func<Device, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<Device> query = _dbContext.Devices.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
