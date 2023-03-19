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
                        // TODO future implementation for castle etc.
                        if(substring.StartsWith("O") || substring.Contains("+") || substring.Contains("#") || substring.Contains("-")) {
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

                        // get white or black piece
                        isWhite = counter % 2 == 0;

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
