using chero.Pieces;
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
        private String rochade;
        public MoveAction(String rochade, bool isWhite)
        {
            this.target = Field.UNKNOWN;
            this.piece = new UnknownPiece(target);
            this.takes = false;
            this.isWhite = isWhite;
            this.rochade = rochade;
        }

        public MoveAction(IChessPiece piece, Field target, bool takes, bool isWhite)
        {
            this.piece = piece;
            this.target = target;
            this.takes = takes;
            this.isWhite = isWhite;
            this.rochade = "";
        }

        public IChessPiece getPiece() { return piece; }
        public Field getTarget() { return target; }
        public bool getTakes() { return takes; }
        public bool getIsWhite() { return isWhite;  }
        public bool isRochade() { return !String.IsNullOrEmpty(rochade); }
        public String getRochade() { return rochade; }



    }
}
