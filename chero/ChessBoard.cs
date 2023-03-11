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

        HashSet<IChessPiece> figures = new HashSet<IChessPiece>();

        public ChessBoard() {
            initPieces();
        }

        private void initPieces()
        {
            // white pieces
            figures.Add(new WhitePawn(Field.A2));
            figures.Add(new WhitePawn(Field.B2));
            figures.Add(new WhitePawn(Field.C2));
            figures.Add(new WhitePawn(Field.D2));
            figures.Add(new WhitePawn(Field.E2));
            figures.Add(new WhitePawn(Field.F2));
            figures.Add(new WhitePawn(Field.G2));
            figures.Add(new WhitePawn(Field.H2));
            figures.Add(new Rook(Field.A1));
            figures.Add(new Knight(Field.B1));
            figures.Add(new Bishop(Field.C1));
            figures.Add(new Queen(Field.D1));
            figures.Add(new King(Field.E1));
            figures.Add(new Bishop(Field.F1));
            figures.Add(new Knight(Field.G1));
            figures.Add(new Rook(Field.H1));

            // black pieces 
            figures.Add(new BlackPawn(Field.A7));
            figures.Add(new BlackPawn(Field.B7));
            figures.Add(new BlackPawn(Field.C7));
            figures.Add(new BlackPawn(Field.D7));
            figures.Add(new BlackPawn(Field.E7));
            figures.Add(new BlackPawn(Field.F7));
            figures.Add(new BlackPawn(Field.G7));
            figures.Add(new BlackPawn(Field.H7));
            figures.Add(new Rook(Field.A8));
            figures.Add(new Knight(Field.B8));
            figures.Add(new Bishop(Field.C8));
            figures.Add(new Queen(Field.D8));
            figures.Add(new King(Field.E8));
            figures.Add(new Bishop(Field.F8));
            figures.Add(new Knight(Field.G8));
            figures.Add(new Rook(Field.H1));
        }
    }
}
