using MPGC_API.Models;
using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginVM;
        List<UserGame> games;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            loginVM = new LoginViewModel();
            games = new List<UserGame>();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            ObjetosGlobales.userLog = loginVM.LoginUser(TxtUser.Text, TxtPassword.Text);

            if (ObjetosGlobales.userLog != null)
            {
                ObjetosGlobales.isUserLogged = true;
                SortGames();
                ObjetosGlobales.shell.UserLogged();



                Preferences.Set("UserLogged", true);
                Preferences.Set("UserId", ObjetosGlobales.userLog.Iduser);


                Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                DisplayAlert("Error", "Incorrect user or password", "OK");
            }
        }

        private void SortGames()
        {
            games = loginVM.GetUserGames(ObjetosGlobales.userLog.Iduser);
            if (games != null)
            {
                foreach (UserGame game in games)
                {
                    switch (game.IdgameState)
                    {
                        case 1:
                            ObjetosGlobales.Completed.Add(game);
                            break;
                        case 2:
                            ObjetosGlobales.Playing.Add(game);
                            break;
                        case 3:
                            ObjetosGlobales.Queue.Add(game);
                            break;
                        case 4:
                            ObjetosGlobales.Wishlist.Add(game);
                            break;
                    }
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}