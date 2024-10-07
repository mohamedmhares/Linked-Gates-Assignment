using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Assignment.Core.Interfaces
{
    public interface IUnitOfWork
    {
       
            ICategoryRepository Category { get; }
            IDeviceRepository Device { get; }
            Task SaveAsync();
        
    }
}
