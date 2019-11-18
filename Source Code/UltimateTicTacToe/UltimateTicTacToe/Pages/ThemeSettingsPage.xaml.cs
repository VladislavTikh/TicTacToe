using System.Windows.Controls;
using UltimateTicTacToe.ViewModels;
using Unity;
namespace UltimateTicTacToe.Pages
{
    /// <summary>
    /// Логика взаимодействия для ThemeSettingsPage.xaml
    /// </summary>
    public partial class ThemeSettingsPage : Page
    {

        public ThemeSettingsPage()
        {
            var tsVM = App.Container.Resolve<ThemeSettingsVM>();
            InitializeComponent();
            DataContext = tsVM;
        }
    }
}
