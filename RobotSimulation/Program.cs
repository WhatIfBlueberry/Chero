using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulation
{
	class Program
	{
		public const string DESTINATION_IP_ADDRESS = "127.0.0.1";
		public const ushort DESTINATION_PORT = 59152;

		static void Main(string[] args)
		{
			Robot r = new Robot(DESTINATION_IP_ADDRESS, DESTINATION_PORT);
			r.Start();

		}
	}
}
