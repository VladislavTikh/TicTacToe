using DAL.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.ViewModels
{
    public class GamePageVM : PageVM
    {
        public GlobalBoard GlobalBoard { get; set; } = new GlobalBoard();

        public GamePageVM()
        {

        }
    }
}
