using RobotController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Chero
    {
        private RobotControl control;
        IDictionary<char, int> fieldnumber = new Dictionary<char, int>();
        private int fieldLengthMM = 30;

        public Chero(String ip, int port) {
            this.control = new RobotControl("127.0.0.1", 59152);
            initDictionary();
        }

        private void initDictionary()
        {
            fieldnumber.Add('A', 1);
            fieldnumber.Add('B', 2);
            fieldnumber.Add('C', 3);
            fieldnumber.Add('D', 4);
            fieldnumber.Add('E', 5);
            fieldnumber.Add('F', 6);
            fieldnumber.Add('G', 7);
            fieldnumber.Add('H', 8);
        }

        public void start()
        {
            this.control.StartConnection();
        }

        public void stop()
        {
            this.control.CloseConnection();
        }

        public void testrun()
        {
            Console.WriteLine("Enter field to move to (Chess Format e.g. A3): ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                throw new InvalidDataException();
            }
            (int x, int y) p = parseInput(input);
            MoveRobotLin(p);
        }

        private void MoveRobotLin((int x, int y) p)
        {
            control.MoveAxesToPosition(new RobotAxisPosition(0, 0, 0, 0, -10, 0));
            control.MoveTCPToPosition(new RobotCartPosition(p.x * fieldLengthMM + 100, p.y * fieldLengthMM - 1300, 0, 0, 90, 0), RobotCartMoveType.PTP, true);
        }

        private (int x, int y) parseInput(String input)
        {
            char[] chars = input.ToCharArray();
            char firstChar = chars[0];
            char secondChar = chars[1];
            return (fieldnumber[firstChar], secondChar);

        }

    }
}
