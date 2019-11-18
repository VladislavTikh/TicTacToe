using DAL;
using DAL.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UltimateTicTacToe.Pages;

namespace UltimateTicTacToe.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM(User user)
        {
            CurrentUser = user;
            Pages = new List<PageVM>
            {
                new PageVM{PageName="Rules", PageIcon="Pencil", Page=new RulesPage()},
                new PageVM{PageName="Profile", PageIcon="Account", Page=new Profile()},
                new PageVM{PageName="Theme Settings", PageIcon="Settings", Page=new ThemeSettingsPage()},
                new PageVM{PageName="Game Stage", PageIcon="Application", Page=new GamePage()},
            };
        }

        public User CurrentUser { get; set; }

        public List<PageVM> Pages { get; set; }

        private PageVM _currentPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public PageVM CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand _changePageCommand;

        public RelayCommand ChangePageCommand
        {
            get
            {
                return _changePageCommand ??
                    (_changePageCommand = new RelayCommand(obj =>
                    {
                        var item = (ListView)obj;
                        var selectedItem = (PageVM)item.SelectedItem;
                        CurrentPage = selectedItem;
                    }));
            }

        }
    }
}
