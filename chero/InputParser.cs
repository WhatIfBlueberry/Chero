using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using chero.Pieces;

namespace chero
{
    internal static class InputParser
    {
        public static List<MoveAction> parse()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nicol\OneDrive\Desktop\Chero\chero\chess_moves.pgn");
            bool shouldProcess = false;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    shouldProcess = true;
                }
                else if (shouldProcess)
                {
                    string output = Regex.Replace(line, @"\d+\.\s*", string.Empty);
                    List<string> substrings = new List<string>(output.Split(' '));
                    List<MoveAction> ret = new List<MoveAction>();

                    foreach (string substring in substrings)
                    {
                        IChessPiece piece = getPiece(substring[0]);

                        // ret.Add(new MoveAction(Piece, targetField, takes, isWhite))

                    }
                    return ret;
                }
            }
            return new List<MoveAction>();
        }

        private static IChessPiece getPiece(char c)
        {
            IChessPiece piece;
            switch (c)
            {
                case 'K':
                    piece = new King(Field.UNKNOWN);
                    break;
                case 'Q':
                    piece = new Queen(Field.UNKNOWN);
                    break;
                case 'N':
                    piece = new Knight(Field.UNKNOWN);
                    break;
                case 'B':
                    piece = new Bishop(Field.UNKNOWN);
                    break;
                case 'R':
                    piece = new Rook(Field.UNKNOWN);
                    break;

                default:
                    // TODO return BlackPawn if black turn
                    piece = new WhitePawn(Field.UNKNOWN);
                    break;
            }
            return piece;
        }
    }
}
