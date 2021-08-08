using MPGC_API.Models;

namespace MPGC_APP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User user;
        public UserViewModel()
        {
            user = new User();
        }


        public User GetUserID(int id)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                user.Iduser = id;

                return user.GetID();
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
