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

        public static string[] getInput()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return new string[0];
            }
            string[] lines = File.ReadAllLines(openFileDialog.FileName);
            return lines;
        }
        public static List<MoveAction> parse(string[] lines)
        {
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
                    substrings.Remove(substrings.Last());
                    List<MoveAction> ret = new List<MoveAction>();
                    int counter = 0;
                    bool isWhite;

                    foreach (string substring in substrings)
                    {
                        string substr = substring;

                        // get white or black piece
                        isWhite = counter % 2 == 0;

                        // Handles predefined moves like Castle
                        if (substring.Equals("O-O") || substring.Equals("O-O-O"))
                        {
                            ret.Add(new MoveAction(substring, isWhite));   
                            counter++;
                            continue;
                        }

                        // deletes "+" and "#" from the substring because of unnecessary information
                        if (substring.Contains("+") || substring.Contains("#"))
                        {
                            substr = substr.Replace("+", "");
                            substr = substr.Replace("#", "");
                        }

                        // get target field
                        string target = substr.Substring(substr.Length - 2);
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
