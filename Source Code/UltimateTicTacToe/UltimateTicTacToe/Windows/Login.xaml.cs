using System.Windows;
using System.Windows.Controls;
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

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            var registerForm = new Registration();
            registerForm.Show();
            this.Close();
        }
    }
}
