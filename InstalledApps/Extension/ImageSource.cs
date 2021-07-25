using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InstalledApps.Extension
{
    [TypeConverter(typeof(PackageNameSourceConverter))]
    public sealed class PackageNameSource : ImageSource
    {
        public static readonly BindableProperty PackageNameProperty = BindableProperty.Create(nameof(PackageName), typeof(string), typeof(PackageNameSource), default(string));

        public static ImageSource FromPackageName(string packageName)
        {
            return new PackageNameSource { PackageName = packageName };
        }

        public string PackageName
        {
            get { return (string)GetValue(PackageNameProperty); }
            set { SetValue(PackageNameProperty, value); }
        }

        public override Task<bool> Cancel()
        {
            return Task.FromResult(false);
        }

        public override string ToString()
        {
            return $"PackageName: {PackageName}";
        }

        public static implicit operator PackageNameSource(string packageName)
        {
            return (PackageNameSource)FromPackageName(packageName);
        }

        public static implicit operator string(PackageNameSource packageNameSource)
        {
            return packageNameSource != null ? packageNameSource.PackageName : null;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == PackageNameProperty.PropertyName)
                OnSourceChanged();
            base.OnPropertyChanged(propertyName);
        }
    }
}
