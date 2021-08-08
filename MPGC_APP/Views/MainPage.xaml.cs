using MPGC_API.Models;
using MPGC_APP.Tools;
using MPGC_APP.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        GameViewModel vmGame;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vmGame = new GameViewModel();
            ObservableCollection<Game> _Games = new ObservableCollection<Game>(vmGame.AllGames());

            MyCollection.ItemsSource = _Games;

        }

        protected override void OnAppearing()
        {
            Label r = new Label();
            r.TextColor = Color.White;
            r.FontSize = 20;
            r.Margin = 14;

            if (ObjetosGlobales.isUserLogged)
            {

                r.Text = "Welcome " + ObjetosGlobales.userLog.Username + "!!";
                Shell.SetTitleView(this, (View)r);
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
            if (!ObjetosGlobales.AppBusy)
            {
                ObjetosGlobales.AppBusy = true;
                Frame frame = (Frame)sender;
                Game game = (Game)frame.BindingContext;
                GameInfo gameInfo = new GameInfo();
                gameInfo.BindingContext = game;
                Navigation.PushAsync(gameInfo);
            }

        }

        private void BtnNext_Clicked(object sender, System.EventArgs e)
        {

        }

    }
}