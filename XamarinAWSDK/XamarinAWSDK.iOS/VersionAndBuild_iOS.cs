using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using XamarinAWSDK.Interfaces;
using XamarinAWSDK.iOS;

[assembly: Dependency(typeof(VersionAndBuild_iOS))]
namespace XamarinAWSDK.iOS
{
    public class VersionAndBuild_iOS : IAppVersionAndBuild
    {
        public string GetVersionNumber()
        {
            //var VersionNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleShortVersionString")).ToString();   
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
        public string GetBuildNumber()
        {
            //var BuildNumber = NSBundle.MainBundle.InfoDictionary.ValueForKey(new NSString("CFBundleVersion")).ToString();   
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }

        public string GetPackageName()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleIdentifier").ToString();
        }
    }
}