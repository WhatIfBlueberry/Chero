using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class MoveAction
    {
        private IChessPiece piece;
        private Field from;
        private Field target;
        private bool takes;
        public MoveAction(IChessPiece piece, Field from, Field target, bool takes)
        {
            this.piece = piece;
            this.from = from;
            this.target = target;
            this.takes = takes;
        }

        public IChessPiece getPiece() { return piece; }
        public Field getStartingPoint() { return from; }
        public Field getTarget() { return target; }
        public bool getTakes() { return takes; }



    }
}
