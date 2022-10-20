using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Airwatch.App;
using Java.Security.Cert;
using WorkspaceOne.Android;
using Com.Airwatch.Gateway.UI;
using Microsoft.AppCenter.Crashes;

namespace XamarinAWSDK.Droid
{
    [Application]
    public class MainApplication : WorkspaceOneApplication//AWApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        public override Intent MainActivityIntent
        {
            get
            {
                return new Intent(AwAppContext, typeof(MainActivity));
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            try
            {

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        /*
        public override Intent MainLauncherIntent
        {
            get
            {
                var intent = new Intent(ApplicationContext, typeof(GatewaySplashActivity));
                return intent;
            }
        }

        public override void OnPostCreate()
        {
            base.OnPostCreate(); 

        }


        public override void OnSSLPinningRequestFailure(string host, X509Certificate serverCACert)
        {
            Crashes.TrackError(new Exception(host));
        }

        public override void OnSSLPinningValidationFailure(string host, X509Certificate serverCACert)
        {
            Crashes.TrackError(new Exception(host));
        }


        public override bool MagCertificateEnable
        {
            get
            {
                return true; // to fetch mag certificate during initial setup
            }
        }

        public override bool IsInputLogoBrandable
        {
            get
            {
                return true; // to brand application logo
            }
        }
        */
    }
}