using MPGC_API.Models;
using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameInfo : ContentPage
    {
        GameViewModel vmGame;
        GameInfoViewModel gameInfo;
        Game game;
        LoginViewModel loginVM;
        List<UserGame> games;

        public GameInfo()
        {
            InitializeComponent();
            vmGame = new GameViewModel();
            gameInfo = new GameInfoViewModel();
            loginVM = new LoginViewModel();
            games = new List<UserGame>();

            mediaPlayer.HeightRequest = 1;

            /*Esto pone un titulo en el shell bar
            Label r = new Label();
            r.Text = "Nier";
            Shell.SetTitleView(this, (View)r);
            */
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            game = vmGame.GetGameId(((Game)BindingContext).Idgame);

            TxtGenre.Text = game.IdgenreNavigation.NameGenre;
            ScreenshotView.ItemsSource = game.GameScreenshots;

            string r = game.Released.ToString("MMMM dd, yyyy");
            string fecha = DateTime.Parse(r).ToShortDateString();
            TxtReleased.Text = "Release date: " + fecha;

            VideoView.ItemsSource = game.GameMovies;
            BindableLayout.SetItemsSource(PlatformsView, game.GamePlatforms);
            GetYTGameMusicAsync(((Game)BindingContext).UrlMusicTheme);
            SetButtonText();
            ObjetosGlobales.AppBusy = false;

        }

        protected override bool OnBackButtonPressed()
        {
            if (Content.IsVisible)
            {
                mediaPlayer.Pause();
                Navigation.PopAsync();
                base.OnBackButtonPressed();
            }

            return true;
        }


        private void CmdGameStateChange(object sender, EventArgs e)
        {

            if (ObjetosGlobales.isUserLogged)
            {
                if (!PkPicker.IsFocused)
                {
                    PkPicker.IsVisible = true;

                    PkPicker.Focus();
                }
            }
            else
            {
                DisplayAlert("Login Or Register", "Login or Register to start a collection", "OK");
            }
        }

        private void CmdHidePicker(object sender, FocusEventArgs e)
        {
            PkPicker.IsVisible = false;

        }

        public async void GetYTGameMusicAsync(string videoId)
        {
            var youtube = new YoutubeClient();
            Loading.IsVisible = true;
            Content.IsVisible = false;
            PageBackground.IsVisible = false;
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (streamInfo != null)
            {
                string source = streamInfo.Url;

                mediaPlayer.Source = source;

                mediaPlayer.Volume = 15;
                mediaPlayer.HeightRequest = 0;
                mediaPlayer.AutoPlay = true;
                while (mediaPlayer.State == Octane.Xamarin.Forms.VideoPlayer.Constants.PlayerState.Idle)
                {

                }


            }
            TxtLoading.Text = TxtName.Text;
            PageBackground.IsVisible = true;
            PageBackground.Opacity = 0;
            await PageBackground.FadeTo(1, 500);
            Task.Delay(3000).Wait();
            Loading.IsVisible = false;
            Content.IsVisible = true;
            Content.Opacity = 0;

            await Content.FadeTo(1, 3000);

        }

        private void PkPicker_Focused(object sender, FocusEventArgs e)
        {
            PkPicker.IsVisible = false;
        }

        private async void PkPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameState.IsEnabled = false;
            if (PkPicker.SelectedIndex >= 0 && PkPicker.SelectedIndex <= 3)
            {
                if (await gameInfo.RegisterGame(((Game)BindingContext).Idgame, ObjetosGlobales.userLog.Iduser, PkPicker.SelectedIndex))
                {
                    SortGames();
                    GameState.Text = PkPicker.SelectedItem.ToString();
                    GameState.IsEnabled = true;
                    SetButtonText();
                }
                else
                {
                    await DisplayAlert("Error", "There was a problem trying to add the game", "Borrar");

                }
            }
            else
            {
                if (PkPicker.SelectedIndex == 4)
                {
                    if (await gameInfo.DeleteGame(((Game)BindingContext).Idgame, ObjetosGlobales.userLog.Iduser, PkPicker.SelectedIndex))
                    {
                        GameState.BackgroundColor = Color.FromHex("#B51919");
                        GameState.Text = "Add to";
                        GameState.IsEnabled = true;
                        SortGames();

                    }

                }
            }
            GameState.IsEnabled = true;
        }
        private void SetButtonText()
        {
            if (ObjetosGlobales.isUserLogged)
            {
                foreach (UserGame game in ObjetosGlobales.Completed)
                {
                    if (((Game)BindingContext).Idgame == game.Idgame)
                    {
                        GameState.Text = "Completed";
                        GameState.BackgroundColor = Color.FromHex("#9DC73B");
                    }
                }

                foreach (UserGame game in ObjetosGlobales.Playing)
                {
                    if (((Game)BindingContext).Idgame == game.Idgame)
                    {
                        GameState.Text = "Playing";
                        GameState.BackgroundColor = Color.FromHex("#FF0066");
                    }
                }

                foreach (UserGame game in ObjetosGlobales.Queue)
                {
                    if (((Game)BindingContext).Idgame == game.Idgame)
                    {
                        GameState.Text = "In Queue";
                        GameState.BackgroundColor = Color.FromHex("#3D4ED3");
                    }
                }

                foreach (UserGame game in ObjetosGlobales.Wishlist)
                {
                    if (((Game)BindingContext).Idgame == game.Idgame)
                    {
                        GameState.Text = "Wishlist";
                        GameState.BackgroundColor = Color.FromHex("#9250AA");
                    }
                }
            }
        }
        private void SortGames()
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