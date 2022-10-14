using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using XamarinAWSDK.Interfaces;
using XamarinAWSDK.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(StorageFolderPath))]
namespace XamarinAWSDK.iOS
{
    public class StorageFolderPath : IStorageFolderPath
    {
        public string GetStorageFolderPath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Documents");
            return libFolder;
        }
    }
}