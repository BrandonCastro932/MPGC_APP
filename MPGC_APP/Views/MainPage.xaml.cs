using MPGC_API.Models;
using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        LoginViewModel loginVM;
        List<UserGame> games;
        GameViewModel vmGame;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vmGame = new GameViewModel();
            ObservableCollection<Game> _Games = new ObservableCollection<Game>(vmGame.AllGames());

            MyCollection.ItemsSource = _Games;
            games = new List<UserGame>();
            loginVM = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            this.IsEnabled = true;
            Label r = new Label();
            r.TextColor = Color.White;
            r.FontSize = 20;
            r.Margin = 14;

            if (ObjetosGlobales.isUserLogged)
            {
                r.Text = "Welcome " + ObjetosGlobales.userLog.Username + "!!";
                Shell.SetTitleView(this, (View)r);
                SortGames();
            }
            else
            {
                r.Text = "";
                Shell.SetTitleView(this, (View)r);
            }
            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

            this.IsEnabled = false;
            Frame frame = (Frame)sender;
            Game game = (Game)frame.BindingContext;
            GameInfo gameInfo = new GameInfo();
            gameInfo.BindingContext = game;
            Navigation.PushAsync(gameInfo);


        }

        private void BtnNext_Clicked(object sender, System.EventArgs e)
        {

        }

        private void SortGames()
        {
           if(ObjetosGlobales.Completed == null || ObjetosGlobales.Playing == null || ObjetosGlobales.Queue == null || ObjetosGlobales.Wishlist == null)
            {
                ObjetosGlobales.Completed.Clear();
                ObjetosGlobales.Playing.Clear();
                ObjetosGlobales.Queue.Clear();
                ObjetosGlobales.Wishlist.Clear();
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
        }

    }
}