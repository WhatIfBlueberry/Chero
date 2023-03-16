using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    class Bishop : AbstractChessPiece
    {
        public Bishop(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            (int x, int y) current = Helper.parseInput(this.field);
            (int x, int y) target = Helper.parseInput(field);
            // the sum of row and column are dividable by 2 <-> field is black
            bool blackBishop = (current.x + current.y) % 2 == 0;
            bool targetIsBlack = (target.x + target.y) % 2 == 0;
            if (blackBishop)
            {
                return targetIsBlack;
            }
            return !targetIsBlack;
        }

        public override string ToString()
        {
            return "Bishop";
        }
    }
}
