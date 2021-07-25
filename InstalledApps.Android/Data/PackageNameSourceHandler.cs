using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InstalledApps.Droid.Data;
using InstalledApps.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Bitmap = Android.Graphics.Bitmap;

[assembly: ExportImageSourceHandler(typeof(PackageNameSource), typeof(PackageNameSourceHandler))]
namespace InstalledApps.Droid.Data
{
    public class PackageNameSourceHandler : IImageSourceHandler, IImageViewHandler
    {
        public async Task<Bitmap> LoadImageAsync(ImageSource imagesource, Context context, CancellationToken cancelationToken = default(CancellationToken))
        {
            var packageName = ((PackageNameSource)imagesource).PackageName;
            using (var pm = Android.App.Application.Context.PackageManager)
            using (var info = pm.GetApplicationInfo(packageName, PackageInfoFlags.MetaData))
            using (var drawable = info.LoadIcon(pm))
            {
                Bitmap bitmap = null;
                await Task.Run(() =>
                {
                    bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
                    using (var canvas = new Canvas(bitmap))
                    {
                        drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
                        drawable.Draw(canvas);
                    }
                });
                return bitmap;
            }
        }

        public Task LoadImageAsync(ImageSource imagesource, ImageView imageView, CancellationToken cancellationToken = default(CancellationToken))
        {
            var packageName = ((PackageNameSource)imagesource).PackageName;
            using (var pm = Android.App.Application.Context.PackageManager)
            {
                var info = pm.GetApplicationInfo(packageName, PackageInfoFlags.MetaData);
                imageView.SetImageDrawable(info.LoadIcon(pm));
            }
            return Task.FromResult(true);
        }
    }
}