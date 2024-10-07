using LG_Assignment.Application.Dtos;
using LG_Assignment.Application.Services;
using LG_Assignment.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LG_Assignment.Presentation.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly ICategoryService _categoryService;
        private readonly IPropertyService _propertyService;


        public DeviceController(IDeviceService deviceService, ICategoryService categoryService, IPropertyService propertyService)
        {
            _deviceService = deviceService;
            _categoryService = categoryService;
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return View(devices); 
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? categoryId, int deviceID)
        {
            var deviceDto = new DeviceDto();
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", categoryId);

            
            if (categoryId.HasValue)
            {
                var properties = await _propertyService.GetPropertiesForCategoryAsync(categoryId.Value);
                ViewBag.PropertyItems = properties.Select(p => new { p.Id, p.Description }).ToList();
            }
            if (deviceID != 0)
            {
                var device = await _deviceService.GetDeviceByIdAsync(deviceID);
                deviceDto.AcquisitionDate = device.AcquisitionDate;
                deviceDto.SerialNo = device.SerialNo;
                deviceDto.Name = device.Name;
                deviceDto.propertyValueDTOs = device.PropertyValues.Select(x => new PropertyValueDTO()
                {
                    Id = x.PropertyItemId,
                    Value = x.Value,
                }).ToList();

            }

            return View(deviceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceDto deviceDto)
        {
            if (ModelState.IsValid)
            {
                var device = new Device();
                device.Id = deviceDto.Id;
                device.Name = deviceDto.Name;
                device.AcquisitionDate = deviceDto.AcquisitionDate;
                device.SerialNo = deviceDto.SerialNo;
                device.Memo = deviceDto.Memo;
                device.DeviceCategoryId = deviceDto.DeviceCategoryId;
                device.PropertyValues = deviceDto.propertyValueDTOs.Select(x => new DevicePropertyValue
                {
                    PropertyItemId = x.Id,
                    Value = x.Value
                }).ToList();
                await _deviceService.AddDeviceAsync(device);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create), deviceDto);

        }

        public async Task<IActionResult> GetProperties(int categoryId)
        {
            var properties = await _propertyService.GetPropertiesForCategoryAsync(categoryId);

            if (properties == null || !properties.Any())
            {
                return Json(new { message = "No properties found for this category." });
            }

            var propertyList = properties.Select(pi => new
            {
                Id = pi.Id,
                Description = pi.Description
            }).ToList();

            return Json(propertyList);
        }
    }
}
