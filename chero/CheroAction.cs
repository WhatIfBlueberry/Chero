using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chero
{
    internal class CheroAction
    {
        protected Chero chero;
        private IChessPiece piece;
        private Field from;
        private Field target;
        private bool isWhite;
        public CheroAction(Chero chero, IChessPiece piece, Field from, Field target, bool isWhite)
        {
            // chero could be made a Singleton
            // piece and isWhite could be removed, they are currently just present for better debugging
            // and a readable toString() method
            this.chero = chero;
            this.piece = piece;
            this.from = from;
            this.target = target;
            this.isWhite = isWhite;

        }

        public void execute()
        {
            this.chero.moveFromTo(from, target, true);
        }

        public override string ToString()
        {
            String color = isWhite ? "White" : "Black";
            return $"{color} {piece} moves from: {from}, to: {target}";
        }
    }
}
