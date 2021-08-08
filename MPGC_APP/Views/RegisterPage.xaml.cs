using MPGC_APP.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MPGC_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel registerVM;
        public RegisterPage()
        {
            InitializeComponent();
            registerVM = new RegisterViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void BtnRegister_ClickedAsync(object sender, EventArgs e)
        {
            
        }
        private bool validateData()
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text) &&
                !string.IsNullOrEmpty(TxtName.Text) && 
                !string.IsNullOrEmpty(TxtPassword.Text) && 
                !string.IsNullOrEmpty(TxtPhone.Text) && 
                !string.IsNullOrEmpty(TxtUser.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if (validateData())
            {
                if(await registerVM.RegisterUser(TxtUser.Text, TxtEmail.Text, TxtPassword.Text, TxtPhone.Text, TxtName.Text))
                {
                    await DisplayAlert("Success", "User registered", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "User not registered", "OK");
                }
            }
            else
            {
                await DisplayAlert("Warning", "Incorrect values", "OK");
            }
        }
    }
}