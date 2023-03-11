using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class ChessBoard
    {

        HashSet<IChessPiece> figures = new HashSet<IChessPiece>();

        public ChessBoard() {
            initFigures();
        }

        private void initFigures()
        {

        }
    }
}
