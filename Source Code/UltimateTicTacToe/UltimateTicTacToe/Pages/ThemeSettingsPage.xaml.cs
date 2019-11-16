using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateTicTacToe.ViewModels;

namespace UltimateTicTacToe.Pages
{
    /// <summary>
    /// Логика взаимодействия для ThemeSettingsPage.xaml
    /// </summary>
    public partial class ThemeSettingsPage : Page
    {

        public ThemeSettingsPage()
        {
            var tsVM = new ThemeSettingsVM();
            InitializeComponent();
            DataContext = tsVM;
        }
    }
}
