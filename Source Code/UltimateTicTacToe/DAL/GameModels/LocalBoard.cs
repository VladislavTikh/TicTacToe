using DAL.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DAL.GameModels
{
    public class LocalBoard:BaseBoard
    {
        
        private ObservableCollection<BoardCell> _cells;

        public LocalBoard():base()
        {}

        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, Rows * Columns).Select(i => new BoardCell()));
                return _cells;
            }
        }

        public override bool IsBoardPlayed
        {
            get { return _IsBoardPlayed; }
            set
            {
                _IsBoardPlayed = value;
                Cells.ToList().ForEach(x => x.CanSelect = false);
            }
        }
    }
}
