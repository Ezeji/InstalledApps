using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;

namespace InstalledApps.Model
{
    public class InApp
    {
        public string AppName { get; set; }
        public string PackageName { get; set; }

        public InApp(string appName, string packageName)
        {
            AppName = appName;
            PackageName = packageName;
        }
    }
}
