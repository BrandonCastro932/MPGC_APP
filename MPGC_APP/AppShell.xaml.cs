﻿using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MPGC_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        UserViewModel uservm;
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            bool defaultlogin = false;
            int defaultuser = -1;
            int id;
            uservm = new UserViewModel();
            bool userlogged = Preferences.Get("UserLogged", defaultlogin);

            if (userlogged)
            {
                ObjetosGlobales.isUserLogged = true;
                id = Preferences.Get("UserId", defaultuser);

                ObjetosGlobales.userLog = uservm.GetUserID(id);

                if (ObjetosGlobales.userLog != null)
                {
                    ObjetosGlobales.isUserLogged = true;
                    UserLogged();

                }
                else
                {
                    Preferences.Set("UserId", defaultuser);
                    Preferences.Set("UserLogged", defaultlogin);
                }
            }
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

                bool defaultlogin = false;
                int defaultuser = -1;
                Preferences.Set("UserId", defaultuser);
                Preferences.Set("UserLogged", defaultlogin);

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
