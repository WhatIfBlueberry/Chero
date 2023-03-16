using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class BlackPawn : AbstractChessPiece
    {
        public BlackPawn(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            (int x, int y) current = Helper.parseInput(this.field);
            (int x, int y) target = Helper.parseInput(field);
            if (takes)
            {
                return (current.x == (target.x + 1) || current.x == (target.x - 1)) && target.y < current.y;
            }
            bool isAtStartingPos = current.y == 7;
            if (isAtStartingPos)
            {
                return current.x == target.x && (current.y == (target.y + 1) || current.y == (target.y + 2));
            }
            return current.x == target.x && current.y == (target.y + 1);
        }

        public override string ToString()
        {
            return "Pawn";
        }
    }
}
