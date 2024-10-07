using LG_Assignment.Core.Entity;

namespace LG_Assignment.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<DeviceCategory>
    {
        Task UpdateAsync(DeviceCategory deviceCategory); // Change method to async
    }
}
