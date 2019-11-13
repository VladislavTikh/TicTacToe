using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GameModels
{
    public class LocalBoard
    {
        public int Rows { get; set; } = 3;
        public int Columns { get; set; } = 3;

        private ObservableCollection<BoardCell> _cells;
        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, Rows * Columns).Select(i => new BoardCell()));
                return _cells;
            }
        }
    }
}
