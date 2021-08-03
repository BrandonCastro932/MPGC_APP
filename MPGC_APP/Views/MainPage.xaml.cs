using MPGC_API.Models;
using MPGC_APP.ViewModels;
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
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Frame frame = (Frame)sender;
            Game game = (Game)frame.BindingContext;
            GameInfo gameInfo = new GameInfo();
            gameInfo.BindingContext = game;
            Navigation.PushAsync(gameInfo);
        }

        private void BtnNext_Clicked(object sender, System.EventArgs e)
        {
            bool isBusy = false;

            if (!isBusy)
            {
                isBusy = true;




            }
        }

        protected override async void OnAppearing()
        {


            base.OnAppearing();

            MyCollection.ItemsSource = vmGame.AllGames();

        }

    }
}