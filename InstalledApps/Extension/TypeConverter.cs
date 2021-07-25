using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstalledApps.Extension
{
    [TypeConversion(typeof(PackageNameSource))]
    public sealed class PackageNameSourceConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
                return PackageNameSource.FromPackageName(value);

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(PackageNameSource)));
        }
    }
}
