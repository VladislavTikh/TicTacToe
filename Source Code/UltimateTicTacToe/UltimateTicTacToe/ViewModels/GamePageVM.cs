using DAL.Commands;
using DAL.GameModels;
using DAL.IService;
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

        private LocalBoard _activeBoard;

        private IGameService _gameService;

        public GamePageVM(IGameService gameService)
        {
            _gameService = gameService;
        }

        private RelayCommand _cellPressCommand;
        public RelayCommand CellPressCommand
        {
            get
            {
                return _cellPressCommand ??
                  (_cellPressCommand = new RelayCommand(obj =>
                  {
                      var cell = obj as BoardCell;
                      var currentTurn = _gameService.ChangeTurn();
                      switch (currentTurn)
                      {
                          case GameRoles.Me:
                              cell.Sign = "X";
                              break;
                          case GameRoles.Opponent:
                              cell.Sign = "O";
                              break;
                          default:
                              break;
                      }
                      _activeBoard = _gameService.GetActiveBoard(GlobalBoard, cell);
                      var outcome=_gameService.ProcessGameStage(GlobalBoard, cell);

                  },
                  obj =>
                  {
                      if (obj != null&&_activeBoard!=null)
                      {
                          if(_activeBoard.IsBoardPlayed)
                          {
                              return (obj as BoardCell).CanSelect;
                          }
                          return (obj as BoardCell).CanSelect && _activeBoard.Cells.Contains(obj);
                      }
                      else return true;
                  }));

            }
        }
    }
}
