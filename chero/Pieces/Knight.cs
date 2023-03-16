using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Knight : AbstractChessPiece
    {
        public Knight(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            (int x, int y) current = Helper.parseInput(this.field);
            (int x, int y) target = Helper.parseInput(field);

            return (Math.Abs(current.x - target.x) == 1 && Math.Abs(current.y - target.y) == 2) ||
                (Math.Abs(current.x - target.x) == 2 && Math.Abs(current.y - target.y) == 1);
        }


        public override string ToString()
        {
            return "Knight";
        }
    }
}
