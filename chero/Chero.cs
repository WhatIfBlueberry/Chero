using RobotController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Chero
    {
        private (int x, int y) currentPos;
        private RobotControl control;
        IDictionary<char, int> fieldnumber = new Dictionary<char, int>();
        private int fieldLengthMM = 30;

        public Chero(String ip, int port) {
            this.control = new RobotControl("127.0.0.1", 59152);
            initDictionary();
        }

        public void start()
        {
            this.control.StartConnection();
            initBase();
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

        public void moveFromTo(Field from, Field to, Boolean dnd)
        {
            (int x, int y) fromCords = parseInput(from.ToString());
            (int x, int y) toCords = parseInput(to.ToString());
            Boolean isAtStartingPos = fromCords.Equals(currentPos);

            if (!isAtStartingPos)
            {
                MoveRobotLin(fromCords);
            }
            if (dnd)
            {
                grab();
            }
            MoveRobotLin(toCords);
            if (dnd)
            {
                putDown();
            }
        }

        private void grab()
        {
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, fieldLengthMM, 0, 0, 0), RobotCartMoveType.LIN, true);
            control.CloseGripper();
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, -fieldLengthMM, 0, 0, 0), RobotCartMoveType.LIN, true);
        }

        private void putDown()
        {
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, fieldLengthMM, 0, 0, 0), RobotCartMoveType.LIN, true);
            control.OpenGripper();
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, -fieldLengthMM, 0, 0, 0), RobotCartMoveType.LIN, true);
        }

        private void MoveRobotLin((int x, int y) p)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Robot current position: " + control.Position);
            RobotPosition pos = control.MoveTCPToPosition(new RobotCartPosition((p.x - 1) * fieldLengthMM, (p.y - 1) * fieldLengthMM, 0, 0, 90, 0), RobotCartMoveType.PTP, true);
            Console.WriteLine("Robot moved Sucessfully to Position: " + pos);
            this.currentPos = p;
        }

        private (int x, int y) parseInput(String input)
        {
            char[] chars = input.ToCharArray();
            char firstChar = chars[0];
            char secondChar = chars[1];
            int y = secondChar - '0';
            return (fieldnumber[firstChar], y);

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

        private void initBase()
        {
            int status = 2;
            control.MoveAxesToPosition(new RobotAxisPosition(0, -90, 90, 0, -10, 0));
            control.SetBase(new RobotFrame(330, -260, 350, 0, 0, 0));
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, 0, 0, 0, 0, status), RobotCartMoveType.PTP, true);
            this.currentPos = (1, 1);
        }

    }
}
