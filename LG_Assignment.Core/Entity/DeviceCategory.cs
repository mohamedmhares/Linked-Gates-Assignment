using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LG_Assignment.Core.Entity
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<PropertyItem> PropertyItems { get; set; } = new List<PropertyItem>();

        public ICollection<Device> Devices { get; set; } = new List<Device>(); // This line is important

    }
}
