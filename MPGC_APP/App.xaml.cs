//using MPGC_APP.Services;
using MPGC_APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
