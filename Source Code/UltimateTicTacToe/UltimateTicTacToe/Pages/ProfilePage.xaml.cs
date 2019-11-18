using System.Windows;
using System.Windows.Controls;
using UltimateTicTacToe.ViewModels;
using Unity;

namespace UltimateTicTacToe.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public ProfilePageVM ProfilePageViewModel = App.Container.Resolve<ProfilePageVM>();

        public Profile()
        {
            InitializeComponent();
            DataContext = ProfilePageViewModel;
        }
    }
}
