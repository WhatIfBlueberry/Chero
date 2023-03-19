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
            (int x, int y) current = Helper.parseInput(this.field); // A3 ^= 13
            (int x, int y) target = Helper.parseInput(field);
            if (current.x != target.x && current.y != target.y)
            {
                return false;
            }
            else if (current.x == target.x) // target and current position are on the same column
            {
                // for from current y to target y if feld besetzt return false
                int diff = target.y - current.y;
                for (int i = 0; i < diff; i++)
                {
                    // field = current.x , current.y + i
                    // if isoccupied(field):
                    // return false
                }
            }
            else if (current.y == target.y) // target and current position are on the same row
            {
                // for from current x to target x if feld besetzt return false
            }
            else
            {
                return true;
            }
            
            // TODO think about what happens if both rooks are on the same line.
        }

        public override string ToString()
        {
            return "Rook";
        }
    }
}
