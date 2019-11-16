using DAL.GameModels;
using DAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class GameService : IGameService
    {

        private GameRoles CurrentRole = GameRoles.Me;

        public LocalBoard GetActiveBoard(GlobalBoard board, BoardCell cell)
        {
            var currentBoard = GetPlayedBoard(board, cell);
            return board.Boards.ElementAt(currentBoard.Cells.ToList().IndexOf(cell));
        }

        public GameRoles ChangeTurn()
        {
            var passedRole = CurrentRole;
            CurrentRole = (GameRoles)((int)CurrentRole ^ 1);
            return passedRole;
        }

        public Outcome ProcessGameStage(BaseBoard board, BoardCell cell, Outcome outcome=Outcome.Continue)
        {
            switch(board)
            {
                case LocalBoard lb:
                {                        
                    var cellIndex = ((LocalBoard)board).Cells.ToList().IndexOf(cell);
                    var positions = GetColumnRowPosition(cellIndex, board.Columns);
                    var rowIndex = positions.Item1;
                    var columnIndex = positions.Item2;
                    var point = CurrentRole == GameRoles.Me ? 1 : -1;
                    UpdateBoardScore(board, rowIndex, columnIndex, point);
                    return CheckForWin(board);
                }
                case GlobalBoard gb:
                    var currentBoard = GetPlayedBoard((GlobalBoard)board, cell);
                    var localBoardIndex = ((GlobalBoard)board).Boards.ToList().IndexOf(currentBoard);
                    var localBoardPositions = GetColumnRowPosition(localBoardIndex, board.Columns);
                    var localBoardRowIndex = localBoardPositions.Item1;
                    var localBoardColumnIndex = localBoardPositions.Item2;
                    var globalPoint = (outcome == Outcome.Cross) ? 1 : -1;
                    if (outcome == Outcome.Draw) globalPoint = 0;
                    UpdateBoardScore(board, localBoardRowIndex, localBoardColumnIndex, globalPoint);
                    return CheckForWin(board);
                default:
                    break;
            }
            return outcome;
        }

        public void ProcessEndStage(BaseBoard board)
        {
            throw new NotImplementedException();
        }

        private void UpdateBoardScore(BaseBoard board, int row, int column, int point)
        {
            var localScores = board.Scores;
            localScores[row] += point;
            localScores[board.Rows + column] += point;
            if (row == column) localScores[2 * board.Rows] += point;
            if (board.Rows - 1 - column == row) localScores[2 * board.Rows + 1] += point;
        }

        private Outcome CheckForWin(BaseBoard board)
        {
            var scores = board.Scores;

            for (var i = 0; i < 8; ++i)
            {
                if (scores[i] == 3)
                {
                    board.IsBoardPlayed = true;
                    board.WinnerSign = "X";
                    return Outcome.Cross;

                }
                if (scores[i] == -3)
                {
                    board.IsBoardPlayed = true;
                    board.WinnerSign = "O";
                    return Outcome.Nought;
                }
            }
            if (board is LocalBoard)
            {

                if (((LocalBoard)board).Cells.All(x => !x.CanSelect))
                {
                    board.IsBoardPlayed = true;
                    return Outcome.Draw;
                }
            }
            else
            {
                if (((GlobalBoard)board).Boards.All(x => x.IsBoardPlayed))
                {
                    board.IsBoardPlayed = true;
                    return Outcome.Draw;
                }
            }
            return Outcome.Continue;
        }

        private Tuple<int, int> GetColumnRowPosition(int cellIndex, int columnNumber)
        {
            var rowIndex = cellIndex / columnNumber;
            var columnIndex = cellIndex - (rowIndex * columnNumber);
            return Tuple.Create(rowIndex, columnIndex);
        }

        public LocalBoard GetPlayedBoard(GlobalBoard board, BoardCell cell)
        {
            return board.Boards.Where(x => x.Cells.Contains(cell)).FirstOrDefault();

        }

    }
}
