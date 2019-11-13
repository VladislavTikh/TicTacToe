using System.Windows;
using System.Windows.Controls;
using UltimateTicTacToe.ViewModels;
using Unity;

namespace UltimateTicTacToe
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public RegisterVM RegistrationViewModel { get; set; } = App.Container.Resolve<RegisterVM>();
        public Registration()
        {
            InitializeComponent();
            this.DataContext = RegistrationViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
        private void PasswordBox_RepeatPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).RepeatPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
