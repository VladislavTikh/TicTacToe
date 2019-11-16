using DAL.Commands;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using UltimateTicTacToe.Properties;
using System;

namespace UltimateTicTacToe.ViewModels
{
    public class ThemeSettingsVM : PageVM, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand _changeThemeCommand;

        public RelayCommand ChangeThemeCommand
        {
            get
            {
                return _changeThemeCommand ??
                    (_changeThemeCommand = new RelayCommand(obj =>
                    {
                        var item = (ToggleButton)obj;
                        bool isChecked = (bool)item.IsChecked;
                        if (isChecked)
                        {
                            App.Current.Resources["FooterColorResource"] = new SolidColorBrush(Colors.BurlyWood);
                            App.Current.Resources["SideMenuColorResource"] = new SolidColorBrush(Colors.Brown);

                        }
                        else
                        {
                            App.Current.Resources["FooterColorResource"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5C99D6"));
                            App.Current.Resources["SideMenuColorResource"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF31577E"));
                        }
                    }));
            }

        }
    }
}
