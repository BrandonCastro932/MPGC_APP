using MPGC_API.Models;
using MPGC_APP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MPGC_APP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public User user;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            user = new User();
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        public User LoginUser(string username, string password)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                user.Username = username;
                user.Password = password;
                return user.LoginUser();
            }
            catch
            {
                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public List<UserGame> GetUserGames(int id)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                user.Iduser = id;
                return user.GetUserGames();
            }
            catch
            {

                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
