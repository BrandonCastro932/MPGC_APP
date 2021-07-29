using MPGC_APP.ViewModels;
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
    public partial class MainPage : ContentPage
    {
        GameViewModel vmGame;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vmGame = new GameViewModel();
            MyCollection.ItemsSource = vmGame.AllGames();

        }
    }
}