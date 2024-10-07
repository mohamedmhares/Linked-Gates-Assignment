using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Dtos
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }
        public int DeviceCategoryId { get; set; }
        public List<PropertyValueDTO> propertyValueDTOs { get; set;} = new List<PropertyValueDTO>();
    }
}