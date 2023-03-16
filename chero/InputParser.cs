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
            string filePath = "./chess_moves.pgn";
            string[] lines = File.ReadAllLines(filePath);
            bool shouldProcess = false;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    shouldProcess = true;
                }
                else if (shouldProcess)
                {
                    // preperate string for further processing
                    string output = Regex.Replace(line, @"\d+\.\s*", string.Empty);
                    List<string> substrings = new List<string>(output.Split(' '));
                    List<MoveAction> ret = new List<MoveAction>();
                    int counter = 0;
                    bool isWhite = true;

                    foreach (string substring in substrings)
                    {
                        // get target field
                        string target = substring.Substring(substring.Length - 2);
                        target = target.ToUpper();
                        Field targetField = Field.UNKNOWN;
                        bool isDefined = Enum.IsDefined(typeof(Field), target);
                        if (isDefined)
                        {
                            targetField = (Field) Enum.Parse(typeof(Field), target);
                        }
                        else
                        {
                            targetField = Field.UNKNOWN;
                        }
                            
                        // get action
                        bool takes = substring.Contains('x');

                        // get white or black piece
                        if (counter % 2 == 0)
                        {
                            isWhite = true;
                        }
                        else
                        {
                            isWhite = false;
                        }

                        counter = counter + 1;
                        IChessPiece piece = getPiece(substring[0], isWhite);
                        ret.Add(new MoveAction(piece, targetField, takes, isWhite));

                    }
                    return ret;
                }
            }
            return new List<MoveAction>();
        }

        private static IChessPiece getPiece(char c, bool isWhite)
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
                    if (isWhite){
                        piece = new WhitePawn(Field.UNKNOWN);
                    }
                    else
                    {
                        piece = new BlackPawn(Field.UNKNOWN);
                    }
                    break;
            }
            return piece;
        }
    }
}
