using DAL.GameModels;

namespace DAL.IService
{
    public interface IGameService
    {
        LocalBoard GetActiveBoard(GlobalBoard board, BoardCell cell);

        GameRoles ChangeTurn();

        Outcome ProcessGameStage(BaseBoard board, BoardCell cell, Outcome outcome = Outcome.Continue);

        LocalBoard GetPlayedBoard(GlobalBoard board, BoardCell cell);

    }
}
