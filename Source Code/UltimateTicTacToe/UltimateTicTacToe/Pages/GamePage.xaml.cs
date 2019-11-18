using DAL;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using UltimateTicTacToe.ViewModels;
using Unity;

namespace UltimateTicTacToe.Pages
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePageVM GamePageViewModel { get; set; } = App.Container.Resolve<GamePageVM>();

        public GamePage()
        {
            GamePageViewModel.Notify += ExecuteDialogHost;
            this.DataContext = GamePageViewModel;
            InitializeComponent();
        }

        private void Restart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GamePageViewModel= App.Container.Resolve<GamePageVM>();
            GamePageViewModel.Notify += ExecuteDialogHost;
            this.DataContext = GamePageViewModel;
        }

        private async void ExecuteDialogHost()
        {
            await MaterialDesignThemes.Wpf.DialogHost.Show(GamePageViewModel);
        }
    }
}
