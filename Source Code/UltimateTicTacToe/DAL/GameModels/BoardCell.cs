using DAL.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace DAL.GameModels
{
    public class BoardCell : INotifyPropertyChanged
    {
        private string _sign;
        private bool _canSelect = true;

        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                if (value != null)
                    CanSelect = false;
                OnPropertyChanged();
            }
        }

        public bool CanSelect
        {
            get { return _canSelect; }
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch { }
        }
    }
}
