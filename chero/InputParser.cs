using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using chero.Pieces;
using System.Windows.Forms;

namespace chero
{
    internal static class InputParser
    {
        public static List<MoveAction> parse()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return new List<MoveAction>();
            }
            string[] lines = File.ReadAllLines(openFileDialog.FileName);
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
                    bool isWhite;

                    foreach (string substring in substrings)
                    {
                        // get white or black piece
                        isWhite = counter % 2 == 0;

                        if (substring.StartsWith("O"))
                        {
                            if (isWhite)
                            {
                                ret.Add(new MoveAction(new Rook(Field.H1), Field.F1, false, true));
                                ret.Add(new MoveAction(new King(Field.E1), Field.G1, false, true));
                                
                            }
                            else
                            {
                                ret.Add(new MoveAction(new Rook(Field.H8), Field.F8, false, false));
                                ret.Add(new MoveAction(new King(Field.E8), Field.G8, false, false));
                                
                            }
                            counter++;
                            continue;
                        }

                        // TODO future implementation for castle etc.
                        if (substring.Contains("+") || substring.Contains("#") || substring.Contains("-")) {
                            ret.Add(new MoveAction(new UnknownPiece(Field.UNKNOWN), Field.UNKNOWN, false, false));
                            counter++;
                            continue;
                        }
                        // get target field
                        string target = substring.Substring(substring.Length - 2);
                        target = target.ToUpper();
                        Field targetField = Field.UNKNOWN;
                        bool isDefined = Enum.IsDefined(typeof(Field), target);
                        targetField = isDefined ? (Field)Enum.Parse(typeof(Field), target) : Field.UNKNOWN;
                            
                        // get action
                        bool takes = substring.Contains('x');

                        counter++;

                        IChessPiece piece = UltimateChessPieceFactory.create(substring[0], isWhite);
                        ret.Add(new MoveAction(piece, targetField, takes, isWhite));
                    }
                    return ret;
                }
            }
            return new List<MoveAction>();
        }
    }
}
