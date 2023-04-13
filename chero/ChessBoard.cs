using chero.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class ChessBoard
    {
        private HashSet<IChessPiece> figures = new HashSet<IChessPiece>();

        public ChessBoard() {
            initPieces();
        }


        private void initPieces()
        {
            this.figures = new HashSet<IChessPiece>();
            // white pieces
            figures.Add(new WhitePawn(Field.A2));
            figures.Add(new WhitePawn(Field.B2));
            figures.Add(new WhitePawn(Field.C2));
            figures.Add(new WhitePawn(Field.D2));
            figures.Add(new WhitePawn(Field.E2));
            figures.Add(new WhitePawn(Field.F2));
            figures.Add(new WhitePawn(Field.G2));
            figures.Add(new WhitePawn(Field.H2));
            figures.Add(new WhiteRook(Field.A1));
            figures.Add(new WhiteKnight(Field.B1));
            figures.Add(new WhiteBishop(Field.C1));
            figures.Add(new WhiteQueen(Field.D1));
            figures.Add(new King(Field.E1));
            figures.Add(new WhiteBishop(Field.F1));
            figures.Add(new WhiteKnight(Field.G1));
            figures.Add(new WhiteRook(Field.H1));

            // black pieces 
            figures.Add(new BlackPawn(Field.A7));
            figures.Add(new BlackPawn(Field.B7));
            figures.Add(new BlackPawn(Field.C7));
            figures.Add(new BlackPawn(Field.D7));
            figures.Add(new BlackPawn(Field.E7));
            figures.Add(new BlackPawn(Field.F7));
            figures.Add(new BlackPawn(Field.G7));
            figures.Add(new BlackPawn(Field.H7));
            figures.Add(new BlackRook(Field.A8));
            figures.Add(new BlackKnight(Field.B8));
            figures.Add(new BlackBishop(Field.C8));
            figures.Add(new BlackQueen(Field.D8));
            figures.Add(new King(Field.E8));
            figures.Add(new BlackBishop(Field.F8));
            figures.Add(new BlackKnight(Field.G8));
            figures.Add(new BlackRook(Field.H8));
        }

        public HashSet<IChessPiece> getFigures()
        {
            return new HashSet<IChessPiece>(figures);
        }

        public bool occupied(Field field)
        {
            foreach (var figure in figures)
            {
                if (figure.getField().Equals(field))
                {
                    return true;
                }
            }
            return false;
        }

        public IChessPiece pieceOnField(Field field)
        {
            foreach (var figure in figures)
            {
                if (figure.getField().Equals(field))
                {
                    return figure;
                }
            }
            throw new InvalidOperationException($"Piece expected on field {field} not present");
        }
    }
}
