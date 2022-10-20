using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorkspaceOne.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAWSDK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DlpPage : ContentPage
    {
        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        
        private string infoText = "Empty Page...";
        public string InfoText
        {
            get { return infoText; }
            set { infoText = value; OnPropertyChanged(); }
        }

        public DlpPage()
        {
            InitializeComponent();
            try
            {
                BindingContext = this;

                App.ProfilesReceived += HandleProfilesReceived;

                HandleProfilesReceived(null, null);
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "DlpPage", "DlpPage", "DlpPage");
            }
        }

        private void HandleProfilesReceived(object sender, EventArgs e)
        {
            try
            {
                if (App.Profiles == null || App.Profiles.Length <= 0)
                {
                    Items = new ObservableCollection<string>();
                    InfoText = "App.Profiles is Null, Kindly configure Restriction Payload - I am here 1";
                    Helper.Log("dlp page HandleProfilesReceived - App.Profiles null - I am here 1", "HandleProfilesReceived", "HandleProfilesReceived", "HandleProfilesReceived");
                }
                else
                {
                    if (App.Profiles[0] == null)
                    {
                        Items = new ObservableCollection<string>();
                        InfoText = "App.Profiles is Null, Kindly configure Restriction Payload - I am here 2";
                        Helper.Log("dlp page HandleProfilesReceived - App.Profiles null - I am here 2", "HandleProfilesReceived", "HandleProfilesReceived", "HandleProfilesReceived");
                    }
                    else
                    {
                        var restrictionPayloadControl = App.Profiles.Any(p => p.ProfileType == AWProfileType.SDKProfile);
                        if (restrictionPayloadControl)
                        {
                            var restrictionPayload = App.Profiles.FirstOrDefault(p => p.ProfileType == AWProfileType.SDKProfile)?.RestrictionsPayload;
                            if (restrictionPayload != null)
                            {
                                Helper.Log("dlp page HandleProfilesReceived - App.Profiles not null... Profiles" + JsonConvert.SerializeObject(App.Profiles), "HandleProfilesReceived", "HandleProfilesReceived", "HandleProfilesReceived");

                                Items = new ObservableCollection<string>
                                {
                                    $"Allow Camera: {restrictionPayload.EnableCameraAccess}",
                                    $"Allow Copy/Paste Into: {restrictionPayload.EnableCopyAndPasteInTo}",
                                    $"Allow Copy/Paste Out: {restrictionPayload.EnableCopyAndPasteOut}",
                                    $"Allow Open In: {restrictionPayload.AllowedApplications.Count().ToString()}",
                                    $"Enable Watermark: {restrictionPayload.EnableWatermark}",
                                    $"Open PDF"
                                };
                            }
                            else
                            {
                                Helper.Log("App.Profiles is Null, Kindly configure Restriction Payload - I am here 3", "HandleProfilesReceived", "HandleProfilesReceived", "HandleProfilesReceived");
                                InfoText = "Restriction Payload is Empty, Kindly configure Restriction Payload - I am here 3";
                                Items = new ObservableCollection<string>();
                            }
                        }
                        else
                        {
                            Helper.Log("App.Profiles is Null, Kindly configure Restriction Payload - I am here 4", "HandleProfilesReceived", "HandleProfilesReceived", "HandleProfilesReceived");
                            InfoText = "Restriction Payload is Null, Kindly configure Restriction Payload - I am here 4";
                            Items = new ObservableCollection<string>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.Log(ex, "HandleProfilesReceived Error", "HandleProfilesReceived Error", "HandleProfilesReceived Error");
                InfoText = "ArgumentNullException: " + ex.Message;
                Items = new ObservableCollection<string>();
            }

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            ((ListView)sender).SelectedItem = null;
        }
    }
}