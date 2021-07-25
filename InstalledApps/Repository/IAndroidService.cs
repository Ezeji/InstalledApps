using InstalledApps.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstalledApps.Repository
{
    public interface IAndroidService
    {
        List<InApp> GetIntalledApps();
    }
}
