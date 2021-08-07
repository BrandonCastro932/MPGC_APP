using MPGC_API.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MPGC_APP.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public Game game;
        public GameViewModel()
        {
            game = new Game();
        }

        //Se implementan todos los metodos async

        public  ObservableCollection<Game> AllGames()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return game.GetAllGames();
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }

        //wasd
        public Game GetGameId(int id)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return game.GetGameById(id);
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
