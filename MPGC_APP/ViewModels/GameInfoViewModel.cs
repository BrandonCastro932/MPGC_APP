using MPGC_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPGC_APP.ViewModels
{
    public class GameInfoViewModel : BaseViewModel
    {
        UserGame userGame;
        public GameInfoViewModel()
        {
            userGame = new UserGame();
        }
        public async Task<bool> RegisterGame(int idgame, int idUser,int idgamestate)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                userGame.Iduser = idUser;
                userGame.Idgame = idgame;
                userGame.IdgameState = idgamestate + 1;
                return await userGame.RegisterGame();
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

        public async Task<bool> DeleteGame(int idgame, int idUser, int idgamestate)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                userGame.Iduser = idUser;
                userGame.Idgame = idgame;
                userGame.IdgameState = idgamestate + 1;
                return await userGame.DeleteGame();
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
