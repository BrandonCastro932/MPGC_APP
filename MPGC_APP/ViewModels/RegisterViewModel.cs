using MPGC_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPGC_APP.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        /*
         
        public int Iduser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int IduserStatus { get; set; }
         */
        User user;
        public RegisterViewModel()
        {
            user = new User();
            user.IduserStatus = 1;
        }
        public async Task<bool> RegisterUser(string username,string email, string password,string phone, string name)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                user.Username = username;
                user.Email = email;
                user.Password = password;
                user.Phone = phone;
                user.Name = name;
                return await user.RegisterUser();
            }
            catch
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
