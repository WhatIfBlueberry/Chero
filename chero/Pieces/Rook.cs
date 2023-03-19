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
            List<char> help_vec = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            (int x, int y) current = Helper.parseInput(this.field); // e.g. A3 ^= 13
            (int x, int y) target = Helper.parseInput(field);

            if (current.x != target.x && current.y != target.y)
            {
                return false;
            }
            else if (current.x == target.x) // target and current position are on the same column
            {
                // for from current y to target y if feld besetzt return false
                int diff = Math.Abs(target.y - current.y);
                int c_y = current.y < target.y ? current.y : target.y;
                
                for (int i = 1; i < diff; i++)
                {
                    string field_as_string = help_vec[current.x] + (c_y + i).ToString();
                    Field btw_field = (Field)Enum.Parse(typeof(Field), field_as_string);
                    if (Helper.occupied(btw_field))
                    {
                        return false;
                    }
                    // field = current.x , current.y + i
                    // if isoccupied(field):
                    // return false
                    
                }
                return true;
            }
            else if (current.y == target.y) // target and current position are on the same row
            {
                // for from current x to target x if feld besetzt return false

                int diff = Math.Abs(target.x - current.x);
                int c_x = current.x < target.x ? current.x : target.x;

                for (int i = 1; i < diff; i++)
                {
                    string field_as_string = help_vec[c_x + i] + (current.y).ToString();
                    Field btw_field = (Field)Enum.Parse(typeof(Field), field_as_string);
                    if (Helper.occupied(btw_field))
                    {
                        return false;
                    }
                    // field = current.x , current.y + i
                    // if isoccupied(field):
                    // return false

                }
                return true;
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
