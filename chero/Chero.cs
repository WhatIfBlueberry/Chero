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
        private int fieldLengthMM = 35;
        private int dropLengthMM = 47;

        public Chero() {
            this.control = new RobotControl();
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

        public void moveFromTo(Field from, Field to, bool dnd=true)
        {
            (int x, int y) fromCords = Helper.parseInput(from);
            (int x, int y) toCords = Helper.parseInput(to);
            Boolean isAtStartingPos = fromCords.Equals(currentPos);
            if (!isAtStartingPos) // if not already at starting field
            {
                MoveRobotLin(fromCords);
            }
            if(dnd) // if drag 'n drop flag active
            {
                grab(); // picks up the piece
                MoveRobotLin(toCords);
                putDown(); // puts the piece back down
                return;
            }
            //otherwise only move
            MoveRobotLin(toCords);
        }

        private void grab()
        {
            control.MoveTCPToPosition(new RobotCartPosition(dropLengthMM, 0, 0, 0, 0, 0), RobotCartMoveType.LIN, true);
            control.CloseGripper();
            control.MoveTCPToPosition(new RobotCartPosition(-dropLengthMM, 0, 0, 0, 0, 0), RobotCartMoveType.LIN, true);
        }

        private void putDown()
        {
            control.MoveTCPToPosition(new RobotCartPosition(dropLengthMM, 0, 0, 0, 0, 0), RobotCartMoveType.LIN, true);
            control.OpenGripper();
            control.MoveTCPToPosition(new RobotCartPosition(-dropLengthMM, 0, 0, 0, 0, 0), RobotCartMoveType.LIN, true);
        }

        private void MoveRobotLin((int x, int y) p)
        {
            RobotPosition pos = control.MoveTCPToPosition(new RobotCartPosition(0, -(p.x - 1) * fieldLengthMM, (p.y - 1) * fieldLengthMM, 0, 0, 0), RobotCartMoveType.LIN, false);
            this.currentPos = p;
        }

        private void initBase()
        {
            int status = 6;
            control.MoveAxesToPosition(new RobotAxisPosition(0, -90, 90, 0, -10, 0));
            control.SetBase(3);
            control.SetTool(3);
            control.MoveTCPToPosition(new RobotCartPosition(470, 0, 580, -122, 90, -122, status), RobotCartMoveType.PTP, false);
            control.SetBase(4);
            control.MoveTCPToPosition(new RobotCartPosition(0, 0, 0, 0, 0, 0, status), RobotCartMoveType.PTP, false);
            this.currentPos = (1, 1);
        }

    }
}
