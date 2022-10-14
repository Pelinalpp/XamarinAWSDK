using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinAWSDK.Droid;
using XamarinAWSDK.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(StorageFolderPath))]
namespace XamarinAWSDK.Droid
{
    public class StorageFolderPath : IStorageFolderPath
    {
        public string GetStorageFolderPath()
        {
            try
            {
                return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return "";
            }
        }
    }
}