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
        private Field target;
        private bool takes;
        private bool isWhite;
        public MoveAction(IChessPiece piece, Field target, bool takes, bool isWhite)
        {
            this.piece = piece;
            this.target = target;
            this.takes = takes;
            this.isWhite = isWhite;
        }

        public IChessPiece getPiece() { return piece; }
        public Field getTarget() { return target; }
        public bool getTakes() { return takes; }



    }
}
