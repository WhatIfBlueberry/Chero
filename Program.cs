using System.Linq.Expressions;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // The files used in this example are created in the topic
        // How to: Write to a Text File. You can change the path and
        // file name to substitute text files of your own.

        // Example #1
        // Read the file as one string.
        string text = System.IO.File.ReadAllText(@"C:\Users\nicol\OneDrive\Desktop\Chero\chero\chess_moves.pgn");

        // Display the file contents to the console. Variable text is a string.
        // System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

        // Example #2
        // Read each line of the file into a string array. Each element
        // of the array is one line of the file.
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nicol\OneDrive\Desktop\Chero\chero\chess_moves.pgn");

        bool shouldProcess = false;

        // Display the file contents by using a foreach loop.
        // System.Console.WriteLine("Contents of WriteLines2.txt = ");
        foreach (string line in lines)
        {
            // Use a tab to indent each line of the file.
            
            if (string.IsNullOrWhiteSpace(line))
            {
                shouldProcess = true;
            }
            else if (shouldProcess)
            {
                string output = Regex.Replace(line, @"\d+\.\s*", string.Empty);
                List<string> substrings = new List<string>(output.Split(' '));
                // List<MoveAction> ret = new List<MoveAction>();

                foreach (string substring in substrings)
                {
                    Console.WriteLine(substring);
                    foreach (char c in substring)
                    {
                        IChessPiece piece;
                        Console.WriteLine(c);
                        switch (c)
                        {
                            case 'K':
                                piece = new King();
                                break;
                            case 'Q':
                                piece = new Queen();
                                break;
                            case 'N':
                                string Piece = "Knight";
                                break;
                            case 'B':
                                string Piece = "Bishop";
                                break;
                            case 'R':
                                string Piece = "Rook";
                                break;

                            default:
                                string Piece = "Pawn";
                                break;
                        }

                        Console.WriteLine(Piece);
                    }

                    // ret.Add(new MoveAction(Piece, targetField, takes, isWhite))

                }
            }

         
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();

    }
}