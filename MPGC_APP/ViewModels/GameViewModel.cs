using MPGC_API.Models;
using System;
using System.Collections.Generic;
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


    }
}
