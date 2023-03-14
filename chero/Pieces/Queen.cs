using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Queen : AbstractChessPiece
    {
        public Queen(Field field) : base(field)
        {
        }

        public override bool isUnique()
        {
            return true;
        }

    }
}
