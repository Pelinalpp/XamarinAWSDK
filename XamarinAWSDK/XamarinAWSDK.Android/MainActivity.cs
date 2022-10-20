using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

using Com.Airwatch.Sdk.Context;
using Com.Airwatch.Login;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using static Com.Airwatch.Certpinning.Service.TrustServiceResponse;
using System.Threading.Tasks;
using AndroidX.Core.App;

namespace XamarinAWSDK.Droid
{
    [Activity(Label = "XamarinAWSDK", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, SDKGatewayActivityDelegate.ICallback
    {
        Exception workspaceOneException;
        SDKGatewayActivityDelegate sDKGatewayActivityDelegate;

        readonly string[] all_permissions =
        {
            Android.Manifest.Permission.WriteExternalStorage,
            Android.Manifest.Permission.ReadExternalStorage
        };
        const int RequestId = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                AppCenter.Start("6b39c34f-0ae7-421c-b47e-9f856850ac41",
                   typeof(Analytics), typeof(Crashes));

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                RequestPermissions();

                try
                {
                    WorkspaceOne.Android.WorkspaceOne.Instance.Init(this);
                    WorkspaceOne.Android.WorkspaceOne.Instance.OnCreate(savedInstanceState);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine($"{this.GetType()} {e}");
                    workspaceOneException = e;
                }

                var app = new App();
                LoadApplication(app);

                if (workspaceOneException != null)
                {
                    app.MainPage.DisplayAlert($"Error: {workspaceOneException.GetType()}", workspaceOneException.Message, "Ok");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        private async void RequestPermissions()
        {
            await Task.Yield();
            ActivityCompat.RequestPermissions(this, all_permissions, RequestId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnPostResume()
        {
            base.OnPostResume(); 
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnResume();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnDestroy();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }


        public void OnTimeOut(SDKBaseActivityDelegate p0)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine($"{this.GetType()}  OnTimeOut(SDKBaseActivityDelegate)");
                //App.Current.MainPage.DisplayAlert($"Error: {p0.GetType()}", "OnTimeOut", "Ok");
                Helper.Log($"{this.GetType()}  OnTimeOut(SDKBaseActivityDelegate)", "OnTimeOut1", "MainActivity", "OnTimeOut(SDKBaseActivityDelegate p0)");
                Helper.Log($"Error: {p0.GetType()}", "OnTimeOut2", "MainActivity", "OnTimeOut(SDKBaseActivityDelegate p0)");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnPause();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnStart();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnStop();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        public override void OnUserInteraction()
        {
            base.OnUserInteraction();
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.OnUserInteraction();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.DispatchKeyEvent(e);
                return base.DispatchKeyEvent(e);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public override bool DispatchKeyShortcutEvent(KeyEvent e)
        {
            try
            {

                WorkspaceOne.Android.WorkspaceOne.Instance.DispatchKeyShortcutEvent(e);
                return base.DispatchKeyShortcutEvent(e);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.DispatchTouchEvent(ev);
                return base.DispatchTouchEvent(ev);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public override bool DispatchTrackballEvent(MotionEvent ev)
        {
            try
            {
                WorkspaceOne.Android.WorkspaceOne.Instance.DispatchTrackballEvent(ev);
                return base.DispatchTrackballEvent(ev);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }
        
    }
}