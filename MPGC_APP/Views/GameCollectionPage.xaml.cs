using MPGC_API.Models;
using MPGC_APP.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameCollectionPage : ContentPage
    {
        public GameCollectionPage()
        {
            InitializeComponent();
           
            MyCollection.ItemsSource = ObjetosGlobales.Completed;
            ResetColors();
            BtnCompleted.TextColor = Color.Red;
        }
        protected override void OnAppearing()
        {
            if (!ObjetosGlobales.isUserLogged)
            {
                EmptyLabel.Text = "Login or Register to Start a collection";
                BtnCompleted.TextColor = Color.White;
            }
            else
            {
                EmptyLabel.Text = "Add games to your collections!!";
            }
            base.OnAppearing();
        }
        private void BtnCompleted_Clicked(object sender, EventArgs e)
        {
            MyCollection.ItemsSource = ObjetosGlobales.Completed;
            ResetColors();
            BtnCompleted.TextColor = Color.Red;
        }

        private void BtnPlaying_Clicked(object sender, EventArgs e)
        {
            MyCollection.ItemsSource = ObjetosGlobales.Playing;
            ResetColors();
            BtnPlaying.TextColor = Color.Red;
        }

        private void BtnQueue_Clicked(object sender, EventArgs e)
        {
            MyCollection.ItemsSource = ObjetosGlobales.Queue;
            ResetColors();
            BtnQueue.TextColor = Color.Red;
        }

        private void BtnWishlist_Clicked(object sender, EventArgs e)
        {
            MyCollection.ItemsSource = ObjetosGlobales.Wishlist;
            ResetColors();
            BtnWishlist.TextColor = Color.Red;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            UserGame game = (UserGame)frame.BindingContext;
            Game wasd = game.IdgameNavigation;
            GameInfo gameInfo = new GameInfo();
            gameInfo.BindingContext = wasd;
            Navigation.PushAsync(gameInfo);
        }

        private void ResetColors()
        {
            BtnCompleted.TextColor = Color.White;
            BtnPlaying.TextColor = Color.White;
            BtnQueue.TextColor = Color.White;
            BtnWishlist.TextColor = Color.White;
        }
    }
}