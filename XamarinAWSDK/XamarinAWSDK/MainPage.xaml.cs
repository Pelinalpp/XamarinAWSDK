using Xamarin.Forms;
using XamarinAWSDK.Interfaces;

namespace XamarinAWSDK
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();

            Version.Text = DependencyService.Get<IAppVersionAndBuild>().GetVersionNumber();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DlpPage());
        }
    }
}
