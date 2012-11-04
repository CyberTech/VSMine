using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSoft.VSMine.Services
{
    public interface ISettingsService
    {
        string LastSelectedProject { get; set; }
    }
}
