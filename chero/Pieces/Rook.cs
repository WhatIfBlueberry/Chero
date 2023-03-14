using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero.Pieces
{
    internal class Rook : AbstractChessPiece
    {
        public Rook(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            (int x, int y) current = Helper.parseInput(this.field);
            (int x, int y) target = Helper.parseInput(field);
            if (current.x != target.x && current.y != target.y)
            {
                return false;
            }
            return true;
            // TODO think about what happens if both rooks are on the same line.
        }
    }
}
