using chero.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace chero
{
    internal class PredefinedCheroAction : CheroAction
    {
        private bool isWhite;
        public PredefinedCheroAction(Chero chero, bool isWhite) : base(chero, new UnknownPiece(Field.UNKNOWN), Field.UNKNOWN, Field.UNKNOWN, isWhite)
        {
            this.isWhite = isWhite;
        }

        public List<CheroAction> getRochadeActions(String rochade)
        {
            switch (rochade)
            {
                case "O-O":
                    return smallRochade();
                case "O-O-O":
                    return largeRochade();
                default:
                    throw new InvalidOperationException("Invalid Rochade String");
            }
        }

        private List<CheroAction> smallRochade()
        {
            List<CheroAction> ret= new List<CheroAction>();
            if (isWhite)
            {
                IChessPiece rook = Helper.pieceOnField(Field.H1);
                IChessPiece king = Helper.pieceOnField(Field.E1);
                ret.Add(new CheroAction(chero, rook, Field.H1, Field.F1, true));
                ret.Add(new CheroAction(chero, king, Field.E1, Field.G1, true));
                rook.setField(Field.F1);
                king.setField(Field.G1);
            } else
            {
                IChessPiece rook = Helper.pieceOnField(Field.H8);
                IChessPiece king = Helper.pieceOnField(Field.E8);
                ret.Add(new CheroAction(chero, rook, Field.H8, Field.F8, false));
                ret.Add(new CheroAction(chero, king, Field.E8, Field.G8, false));
                rook.setField(Field.H8);
                king.setField(Field.G8);
            }
            return ret;

        }

        private List<CheroAction> largeRochade()
        {
            List<CheroAction> ret = new List<CheroAction>();
            if (isWhite)
            {
                ret.Add(new CheroAction(chero, Helper.pieceOnField(Field.A1), Field.A1, Field.D1, true));
                ret.Add(new CheroAction(chero, Helper.pieceOnField(Field.E1), Field.E1, Field.C1, true));
            } else
            {
                ret.Add(new CheroAction(chero, Helper.pieceOnField(Field.A8), Field.A8, Field.D8, false));
                ret.Add(new CheroAction(chero, Helper.pieceOnField(Field.E8), Field.E8, Field.C8, false));
            }
            return ret;
        }

    }
}
