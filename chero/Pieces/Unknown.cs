using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero.Pieces
{
    class UnknownPiece : AbstractChessPiece
    {
        // not meant to be used. This class exists for debugging reasons
        public UnknownPiece(Field field) : base(field)
        {
        }

        public override bool canReach(Field field, bool takes)
        {
            return true;
        }

        public override string ToString()
        {
            return "Unknown Piece";
        }

        public override bool isUnknown()
        {
            return true;
        }
    }
}
