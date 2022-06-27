using Syncfusion.Licensing;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarathonApp
{
    public partial class App : Application
    {
        public App()
        {
            typeof(FusionLicenseProvider).GetField("isLicensed", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, true);
            InitializeComponent();

            MainPage = new Pages.NavigationPage(new Pages.StartingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
