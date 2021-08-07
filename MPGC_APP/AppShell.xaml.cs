using MPGC_APP.Tools;
using System;
using Xamarin.Forms;

namespace MPGC_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            if (ObjetosGlobales.isUserLogged)
            {
                ObjetosGlobales.userLog = null;
                ObjetosGlobales.isUserLogged = false;
                ObjetosGlobales.Completed.Clear();
                ObjetosGlobales.Playing.Clear();
                ObjetosGlobales.Queue.Clear();
                ObjetosGlobales.Wishlist.Clear();
                LoginBtn.Text = "Login or Register";
                LoginBtn.IconImageSource = "Login.png";
                
            }
            await Shell.Current.GoToAsync("//LoginPage");
        }
      
        public void UserLogged()
        {
            LoginBtn.Text = "Logout";
            LoginBtn.IconImageSource = "Logout.png";
        }
    }
}
