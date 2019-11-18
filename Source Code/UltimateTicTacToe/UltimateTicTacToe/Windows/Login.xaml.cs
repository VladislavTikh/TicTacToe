using DAL;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UltimateTicTacToe.ViewModels;
using Unity;

namespace UltimateTicTacToe
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        [Dependency]
        public LoginVM LoginViewModel
        {
            set { DataContext = value; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private async void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            var registerForm = new Registration();
            await Task.Delay(500);
            registerForm.Show();
            this.Close();
        }

        private async void Unauthorized_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            App.Container.RegisterInstance(user);
            var mainWindow = new MainWindow();
            await Task.Delay(500);
            mainWindow.Show();
            this.Close();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
