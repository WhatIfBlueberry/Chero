using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class WhitePawn : AbstractChessPiece
    {
        public WhitePawn(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            return true;
        }

    }
}
