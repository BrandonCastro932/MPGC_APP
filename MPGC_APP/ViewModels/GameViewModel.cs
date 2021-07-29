using MPGC_API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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

        public ObservableCollection<Game> AllGames()
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
    }
}
