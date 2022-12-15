using RobotController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//RobotControl control = new RobotControl("127.0.0.1", 59152);
			RobotControl control = new RobotControl();
			control.StartConnection();

			RobotPosition pos = control.Position;


			// move TCP 50mm down (absolut, with new position object, PTP)
			RobotCartPosition cartPos = pos.CartPosition;
			cartPos.Z -= 50;
			cartPos.X += 50;
			control.MoveTCPToPosition(cartPos);

			// move TCP 10mm down (relative, LIN)
			control.MoveTCPToPosition(new RobotCartPosition(0, 0, -50, 0, 0, 0), relativeMotion: true);

			// move the axes (relative)
			control.MoveAxesToPosition(new RobotAxisPosition(0, 0, 0, 0, 90, 0), true);

			// open the gripper
			control.OpenGripper();

			// rotate the table
			control.RotateTable(90);
			control.RotateTable(-45, relativeMotion: true);

			// close the gripper
			control.CloseGripper();

			// move to home position
			control.MoveToHome();


			control.CloseConnection();

		}
	}
}
