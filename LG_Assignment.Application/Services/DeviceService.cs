using LG_Assignment.Core.Entity;
using LG_Assignment.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _unitOfWork.Device.GetAllAsync(null, "DeviceCategory,PropertyValues.PropertyItem");
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _unitOfWork.Device.GetSingleAsync(d => d.Id == id, "DeviceCategory,PropertyValues.PropertyItem");
        }

        public async Task AddDeviceAsync(Device device)
        {
            _unitOfWork.Device.AddAsync(device);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateDeviceAsync(Device device)
        {
            _unitOfWork.Device.UpdateAsync(device);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDeviceAsync(int id)
        {
            var device = await GetDeviceByIdAsync(id);
            if (device != null)
            {
                _unitOfWork.Device.DeleteAsync(device);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
