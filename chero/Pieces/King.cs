using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero.Pieces
{
    internal class King : AbstractChessPiece
    {
        public King(Field field) : base(field)
        {
        }

        public override string ToString()
        {
            return "King";
        }
    }
}
