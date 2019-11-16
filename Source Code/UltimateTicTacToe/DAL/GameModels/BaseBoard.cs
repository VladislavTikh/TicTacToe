using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DAL.GameModels
{
    public abstract class BaseBoard : INotifyPropertyChanged
    {
        public BaseBoard()
        {
            Rows = 3;
            Columns = 3;
            Scores = new int[8];
            _IsBoardPlayed = false;
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int[] Scores { get; set; }

        protected bool _IsBoardPlayed;

        public virtual bool IsBoardPlayed
        {
            get { return _IsBoardPlayed; }
            set
            {
                _IsBoardPlayed = value;
                OnPropertyChanged();
            }
        }

        public string WinnerSign { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
