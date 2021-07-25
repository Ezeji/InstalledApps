using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InstalledApps.Droid.Data;
using InstalledApps.Model;
using InstalledApps.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidService))]
namespace InstalledApps.Droid.Data
{
    public class AndroidService : IAndroidService
    {
        public List<InApp> GetIntalledApps()
        {
            List<InApp> inApps = new List<InApp>();
            IList<ApplicationInfo> apps = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            for (int i = 0; i < apps.Count; i++)
            {
                inApps.Add(new InApp(apps[i].LoadLabel(Android.App.Application.Context.PackageManager), apps[i].PackageName));
            }
            return inApps;
        }
    }
}