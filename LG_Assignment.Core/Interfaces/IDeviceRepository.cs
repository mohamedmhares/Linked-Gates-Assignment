using LG_Assignment.Core.Entity;

namespace LG_Assignment.Core.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task UpdateAsync(Device device); // Change method to async
    }
}
