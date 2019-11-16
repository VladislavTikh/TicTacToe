using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GameModels
{
    public class GlobalBoard:BaseBoard
    {

        private ObservableCollection<LocalBoard> _boards;

        public GlobalBoard():base()
        {}

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
