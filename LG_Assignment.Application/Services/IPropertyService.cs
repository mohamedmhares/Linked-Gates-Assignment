using LG_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Assignment.Application.Services
{
    public interface IPropertyService
    {
      Task<List<PropertyItem>> GetPropertiesForCategoryAsync(int categoryId);

    }
}
