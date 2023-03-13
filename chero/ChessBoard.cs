using chero.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    public sealed class ChessBoard
    {
        private static ChessBoard? instance = null;
        private static readonly object padlock = new object();
        Dictionary<Field, IChessPiece> figures = new Dictionary<Field, IChessPiece>();

        public ChessBoard() {
            initPieces();
        }

        public static ChessBoard Instance
        {
            get
            {
                lock(padlock)
                {
                    if (instance == null)
                    {
                        instance = new ChessBoard();
                    }
                    return instance;
                }
            }
        }

        private void initPieces()
        {
            // white pieces
            figures.Add(Field.A2, new WhitePawn(Field.A2));
            figures.Add(Field.B2, new WhitePawn(Field.B2));
            figures.Add(Field.C2, new WhitePawn(Field.C2));
            figures.Add(Field.D2, new WhitePawn(Field.D2));
            figures.Add(Field.E2, new WhitePawn(Field.E2));
            figures.Add(Field.F2, new WhitePawn(Field.F2));
            figures.Add(Field.G2, new WhitePawn(Field.G2));
            figures.Add(Field.H2, new WhitePawn(Field.H2));
            figures.Add(Field.A1, new Rook(Field.A1));
            figures.Add(Field.B1, new Knight(Field.B1));
            figures.Add(Field.C1, new Bishop(Field.C1));
            figures.Add(Field.D1, new Queen(Field.D1));
            figures.Add(Field.E1, new King(Field.E1));
            figures.Add(Field.F1, new Bishop(Field.F1));
            figures.Add(Field.G1, new Knight(Field.G1));
            figures.Add(Field.H1, new Rook(Field.H1));

            // black pieces 
            figures.Add(Field.A7, new BlackPawn(Field.A7));
            figures.Add(Field.B7, new BlackPawn(Field.B7));
            figures.Add(Field.C7, new BlackPawn(Field.C7));
            figures.Add(Field.D7, new BlackPawn(Field.D7));
            figures.Add(Field.E7, new BlackPawn(Field.E7));
            figures.Add(Field.F7, new BlackPawn(Field.F7));
            figures.Add(Field.G7, new BlackPawn(Field.G7));
            figures.Add(Field.H7, new BlackPawn(Field.H7));
            figures.Add(Field.A8, new Rook(Field.A8));
            figures.Add(Field.B8, new Knight(Field.B8));
            figures.Add(Field.C8, new Bishop(Field.C8));
            figures.Add(Field.D8, new Queen(Field.D8));
            figures.Add(Field.E8, new King(Field.E8));
            figures.Add(Field.F8, new Bishop(Field.F8));
            figures.Add(Field.G8, new Knight(Field.G8));
            figures.Add(Field.H1, new Rook(Field.H1));
        }

        public bool occupied(Field field)
        {
            foreach (IChessPiece chessPiece in this.figures.Values)
            {
                if (chessPiece.getField() == field)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
