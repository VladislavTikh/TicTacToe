using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GameModels
{
    public abstract class BaseBoard
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

        public virtual bool IsBoardPlayed { get; set; }

        public string WinnerSign { get; set; }
    }
}
