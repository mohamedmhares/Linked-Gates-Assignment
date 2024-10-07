using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LG_Assignment.Core.Entity
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SerialNo { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }

        public string Memo { get; set; }

        [Required]
        public int DeviceCategoryId { get; set; }
        public DeviceCategory DeviceCategory { get; set; }

        public ICollection<DevicePropertyValue> PropertyValues { get; set; } = new List<DevicePropertyValue>();
    }
}
