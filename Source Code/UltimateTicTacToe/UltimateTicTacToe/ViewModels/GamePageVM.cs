using DAL;
using DAL.Commands;
using DAL.GameModels;
using DAL.IService;
using DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace UltimateTicTacToe.ViewModels
{
    public class GamePageVM : PageVM
    {
        public GlobalBoard GlobalBoard { get; set; } = new GlobalBoard();

        private LocalBoard _activeBoard;

        private IGameService _gameService;

        private IUserService _userService;

        public delegate void GameEndHandler();

        public event GameEndHandler Notify;

        public string GameEndIcon { get; set; }

        public string GameEndText { get; set; }

        public GamePageVM(IGameService gameService, IUserService userService, User user)
        {
            _gameService = gameService;
            _userService = userService;
            CurrentUser = user;
        }

        public User CurrentUser { get; set; }

        private RelayCommand _cellPressCommand;
        public RelayCommand CellPressCommand
        {
            get
            {
                return _cellPressCommand ??
                  (_cellPressCommand = new RelayCommand(async obj =>
                  {
                      var values = (object[])obj;
                      var cell = values[0] as BoardCell;
                      var grid = values[1] as Grid;
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
                      var playedBoard = _gameService.GetPlayedBoard(GlobalBoard, cell);
                      var localOutcome = _gameService.ProcessGameStage(playedBoard, cell);
                      if (localOutcome != Outcome.Continue)
                      {
                          var text = _gameService.GenerateGameText(localOutcome, false);
                          AnimationService.AnimateGrid(grid, text);
                          var globalOutcome = _gameService.ProcessGameStage(GlobalBoard, cell,localOutcome);
                          if (globalOutcome != Outcome.Continue)
                          {
                              GameEndText = _gameService.GenerateGameText(globalOutcome, true);
                              GameEndIcon = _gameService.GenerateIcon(globalOutcome);
                              Notify?.Invoke();
                              _gameService.UpdateUserProfile(CurrentUser, globalOutcome);
                              await _userService.UpdateUserAsync(CurrentUser);
                          }
                      }
                      _activeBoard = _gameService.GetActiveBoard(GlobalBoard, cell);
                  },
                  obj =>
                  {
                      var values = (object[])obj;
                      if (values != null && _activeBoard != null)
                      {
                          var cell = values[0] as BoardCell;

                          if (_activeBoard.IsBoardPlayed)
                          {
                              return cell.CanSelect;
                          }
                          return cell.CanSelect && _activeBoard.Cells.Contains(cell);
                      }
                      else return true;
                  }));

            }
        }
    }
}
