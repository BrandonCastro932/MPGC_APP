//using MPGC_APP.Services;
using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MPGC_APP
{
    public partial class App : Application
    {
        UserViewModel uservm;

        public App()
        {
            InitializeComponent();

            






            MainPage = ObjetosGlobales.shell = new AppShell();

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
