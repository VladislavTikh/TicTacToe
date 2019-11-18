using DAL.GameModels;
using DAL.Service;
using System.Threading.Tasks;

namespace DAL.IService
{
    public interface IGameService
    {
        LocalBoard GetActiveBoard(GlobalBoard board, BoardCell cell);

        GameRoles ChangeTurn();

        Outcome ProcessGameStage(BaseBoard board, BoardCell cell, Outcome outcome = Outcome.Continue);

        LocalBoard GetPlayedBoard(GlobalBoard board, BoardCell cell);

        void UpdateUserProfile(User user, Outcome outcome);

        string GenerateGameText(Outcome outcome, bool isFinalStage);

        string GenerateIcon(Outcome outcome);
    }
}
