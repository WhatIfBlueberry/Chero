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
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    if (i+j > 3)
                    {
                        continue;
                    }
                    if (current.x + i == target.x || current.x - i == target.x && (target.y + j == target.y || target.y - j == target.y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
