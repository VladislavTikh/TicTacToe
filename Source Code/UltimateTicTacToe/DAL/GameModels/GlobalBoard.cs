using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GameModels
{
    public class GlobalBoard
    {
        public int Rows { get; set; } = 3;
        public int Columns { get; set; } = 3;

        private ObservableCollection<LocalBoard> _boards;
        public ObservableCollection<LocalBoard> Boards
        {
            get
            {
                if (_boards == null)
                    _boards = new ObservableCollection<LocalBoard>(Enumerable.Range(0, Rows * Columns).Select(i => new LocalBoard()));
                return _boards;
            }
        }
    }
}
