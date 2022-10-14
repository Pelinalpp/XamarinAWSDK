using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WorkspaceOne.Forms;
using WorkspaceOne.Forms.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AppCenter.Crashes;

namespace XamarinAWSDK
{
    public partial class App : Application, IAWSDKDelegate
    {
        public delegate void ProfilesReceivedEventHandler(object sender, EventArgs e);
        public static event ProfilesReceivedEventHandler ProfilesReceived;

        public static AWProfile[] Profiles { get; private set; }
        public static bool InitialCheckDone { get; internal set; }
        public static bool RecievedProfiles { get; internal set; }

        public App()
        {
            InitializeComponent();
            try
            {
                if (DependencyService.Get<IWorkspaceOne>() is IWorkspaceOne ws)
                {
                    if (!DesignMode.IsDesignModeEnabled)
                    {
                        ws.SharedInstance.FormsDelegate = this;

                        Helper.Log($"[{this.GetType()}] FormsDelegate assigned...", "App", "App", "App");
                    }
                    else
                    {
                        Helper.Log($"[{this.GetType()}] IsDesignModeEnabled = {DesignMode.IsDesignModeEnabled}", "App", "App", "App");
                    }
                }
                else
                {
                    Helper.Log($"[{this.GetType()}] IWorkspaceOne == null", "App", "App", "App");
                }

                MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "AppException", "AppException", "AppException");
                Crashes.TrackError(ex);
            }

        }

        protected override void OnStart()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnSleep()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        protected override void OnResume()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }


        void IAWSDKDelegate.InitialCheckFinished(bool error)
        {
            try
            {
                InitialCheckDone = error;
                try
                {
                    Helper.Log(new { MethodName = "IAWSDKDelegate.InitialCheckFinished", Log = "IAWSDKDelegate.InitialCheckFinished" }, "", "", "");
                }
                catch (Exception ex)
                {
                    Helper.Log(ex, "IAWSDKDelegate.InitialCheckFinished", "IAWSDKDelegate.InitialCheckFinished", "IAWSDKDelegate.InitialCheckFinished");
                }
                InitialCheckDone = error;
                try
                {
                    Helper.Log(new { MethodName = "IAWSDKDelegate.InitialCheckFinished", Log = $"[{this.GetType()}] InitialCheckFinished() error:" + error.ToString() }, "", "", "");
                }
                catch (Exception ex)
                {
                    Helper.Log(ex, "IAWSDKDelegate.InitialCheckFinished", "IAWSDKDelegate.InitialCheckFinished", "IAWSDKDelegate.InitialCheckFinished");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            
        }

        void IAWSDKDelegate.ProfilesReceived(AWProfile[] profiles)
        {
            try
            {
                if (profiles == null)
                    return;
                //CrossHud.Current.SetMessage("Profiles received...");
                RecievedProfiles = true;
                Profiles = profiles;
                if (ProfilesReceived != null)
                {
                    ProfilesReceived(this, new EventArgs());
                }

                //DismissHudAsync();

                try
                {
                    Helper.Log(new { MethodName = "IAWSDKDelegate.ProfilesReceived", Log = "IAWSDKDelegate.ProfilesReceived" }, "", "", "");
                }
                catch (Exception ex)
                {
                    Helper.Log(ex, "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived");
                    Crashes.TrackError(ex);
                }

                try
                {
                    Helper.Log(new { MethodName = "IAWSDKDelegate.ProfilesReceived", Log = $"[{this.GetType()}] ProfilesReceived(AWProfile[])" }, "", "", "");
                }
                catch (Exception ex)
                {
                    Helper.Log(ex, "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived");
                    Crashes.TrackError(ex);
                }

                try
                {
                    Helper.Log(new { MethodName = "IAWSDKDelegate.ProfilesReceived", Log = JsonConvert.SerializeObject(profiles) }, "", "", "");
                }
                catch (Exception ex)
                {
                    Helper.Log(ex, "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived", "IAWSDKDelegate.ProfilesReceived");
                    Crashes.TrackError(ex);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            
        }

        async void DismissHudAsync()
        {
            await Task.Delay(1250);
            //CrossHud.Current.Dismiss();
            try
            {
                Helper.Log(new { MethodName = "DismissHudAsync", Log = "DismissHudAsync" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "DismissHudAsync", "DismissHudAsync", "DismissHudAsync");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.Wipe()
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.Wipe", Log = "IAWSDKDelegate.Wipe" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.Wipe", "IAWSDKDelegate.Wipe", "IAWSDKDelegate.Wipe");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.Lock()
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.Lock", Log = "IAWSDKDelegate.Lock" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.Lock", "IAWSDKDelegate.Lock", "IAWSDKDelegate.Lock");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.Unlock()
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.Unlock", Log = "IAWSDKDelegate.Unlock" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.Unlock", "IAWSDKDelegate.Unlock", "IAWSDKDelegate.Unlock");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.StopNetworkActivity(AWNetworkActivityStatus status)
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.StopNetworkActivity", Log = "IAWSDKDelegate.StopNetworkActivity" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.StopNetworkActivity", "IAWSDKDelegate.StopNetworkActivity", "IAWSDKDelegate.StopNetworkActivity");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.StopNetworkActivity", Log = JsonConvert.SerializeObject(status) }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.StopNetworkActivity", "IAWSDKDelegate.StopNetworkActivity", "IAWSDKDelegate.StopNetworkActivity");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.ResumeNetworkActivity()
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.ResumeNetworkActivity", Log = "IAWSDKDelegate.ResumeNetworkActivity" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.ResumeNetworkActivity", "IAWSDKDelegate.ResumeNetworkActivity", "IAWSDKDelegate.ResumeNetworkActivity");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.UserChanged()
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.UserChanged", Log = "IAWSDKDelegate.UserChanged" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.UserChanged", "IAWSDKDelegate.UserChanged", "IAWSDKDelegate.UserChanged");
                Crashes.TrackError(ex);
            }
        }

        void IAWSDKDelegate.EnrollmentStatusReceived(object status)
        {
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.EnrollmentStatusReceived", Log = "IAWSDKDelegate.EnrollmentStatusReceived" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.EnrollmentStatusReceived", "IAWSDKDelegate.EnrollmentStatusReceived", "IAWSDKDelegate.EnrollmentStatusReceived");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "IAWSDKDelegate.EnrollmentStatusReceived", Log = JsonConvert.SerializeObject(status) }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "IAWSDKDelegate.EnrollmentStatusReceived", "IAWSDKDelegate.EnrollmentStatusReceived", "IAWSDKDelegate.EnrollmentStatusReceived");
                Crashes.TrackError(ex);
            }
        }

        public void OnHandleWork()
        {
            try
            {
                Helper.Log(new { MethodName = "OnHandleWork", Log = "OnHandleWork" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnHandleWork", "OnHandleWork", "OnHandleWork");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "OnHandleWork", Log = $"[{this.GetType()}] OnHandleWork()" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnHandleWork", "OnHandleWork", "OnHandleWork");
                Crashes.TrackError(ex);
            }
        }

        public void OnAnchorAppUpgrade()
        {
            try
            {
                Helper.Log(new { MethodName = "OnAnchorAppUpgrade", Log = "OnAnchorAppUpgrade" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnAnchorAppUpgrade", "OnAnchorAppUpgrade", "OnAnchorAppUpgrade");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "OnAnchorAppUpgrade", Log = $"[{this.GetType()}] OnAnchorAppUpgrade()" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnAnchorAppUpgrade", "OnAnchorAppUpgrade", "OnAnchorAppUpgrade");
                Crashes.TrackError(ex);
            }
        }

        public void OnAnchorAppStatusReceived()
        {
            try
            {
                Helper.Log(new { MethodName = "OnAnchorAppStatusReceived", Log = "OnAnchorAppStatusReceived" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnAnchorAppStatusReceived", "OnAnchorAppStatusReceived", "OnAnchorAppStatusReceived");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "OnAnchorAppStatusReceived", Log = $"[{this.GetType()}] OnAnchorAppStatusReceived()" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnAnchorAppStatusReceived", "OnAnchorAppStatusReceived", "OnAnchorAppStatusReceived");
                Crashes.TrackError(ex);
            }
        }

        public void OnApplicationConfigurationChange()
        {
            try
            {
                Helper.Log(new { MethodName = "OnApplicationConfigurationChange", Log = "OnApplicationConfigurationChange" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnApplicationConfigurationChange", "OnApplicationConfigurationChange", "OnApplicationConfigurationChange");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "OnApplicationConfigurationChange", Log = $"[{this.GetType()}] OnApplicationConfigurationChange()" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "OnApplicationConfigurationChange", "OnApplicationConfigurationChange", "OnApplicationConfigurationChange");
                Crashes.TrackError(ex);
            }
        }

        public void ApplicationProfileReceived(AWApplicationProfile profile)
        {
            try
            {
                Helper.Log(new { MethodName = "ApplicationProfileReceived", Log = "ApplicationProfileReceived" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "ApplicationProfileReceived", "ApplicationProfileReceived", "ApplicationProfileReceived");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "ApplicationProfileReceived", Log = $"[{this.GetType()}] ApplicationProfileReceived()" }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "ApplicationProfileReceived", "ApplicationProfileReceived", "ApplicationProfileReceived");
                Crashes.TrackError(ex);
            }
            try
            {
                Helper.Log(new { MethodName = "ApplicationProfileReceived", Log = JsonConvert.SerializeObject(profile) }, "", "", "");
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "ApplicationProfileReceived", "ApplicationProfileReceived", "ApplicationProfileReceived");
                Crashes.TrackError(ex);
            }
        }
    }
}
