using chero.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal static class UltimateChessPieceFactory
    {
        public static IChessPiece create(char c, bool isWhite)
        {
            return isWhite ? createWhite(c) : createBlack(c);

        }

        private static IChessPiece createWhite(char c)
        {
            switch (c)
            {
                case 'K':
                    return new King(Field.UNKNOWN);
                case 'Q':
                    return new WhiteQueen(Field.UNKNOWN);
                case 'N':
                    return new WhiteKnight(Field.UNKNOWN);
                case 'B':
                    return new WhiteBishop(Field.UNKNOWN);
                case 'R':
                    return new WhiteRook(Field.UNKNOWN);

                default:
                    return new WhitePawn(Field.UNKNOWN);
            }        
        }

        private static IChessPiece createBlack(char c)
        {
            switch (c)
            {
                case 'K':
                    return new King(Field.UNKNOWN);
                case 'Q':
                    return new BlackQueen(Field.UNKNOWN);
                case 'N':
                    return new BlackKnight(Field.UNKNOWN);
                case 'B':
                    return new BlackBishop(Field.UNKNOWN);
                case 'R':
                    return new BlackRook(Field.UNKNOWN);

                default:
                    return new BlackPawn(Field.UNKNOWN);
            }

        }

    }
}
