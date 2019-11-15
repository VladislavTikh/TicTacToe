using DAL.GameModels;

namespace DAL.IService
{
    public interface IGameService
    {
        LocalBoard GetActiveBoard(GlobalBoard board, BoardCell cell);

        GameRoles ChangeTurn();

        Outcome ProcessGameStage(GlobalBoard board, BoardCell cell);

    }
}
