using RobotController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotSimulation
{
	class Robot
	{
		private Socket socket;
		private string destIPAddress;
		private ushort destPort;


		private RobotFrame BASE;
		private RobotFrame TOOL;
		private RobotFrame[] BASE_DATA;
		private RobotFrame[] TOOL_DATA;
		private RobotPosition position;


		public Robot(string ipAddress, ushort port)
		{
			destIPAddress = ipAddress;
			destPort = port;
		}

		public void Start()
		{
			IPAddress ipAddress = IPAddress.Parse(destIPAddress);
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, destPort);

			socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
			socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
			try
			{
				socket.Connect(ipEndPoint);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}

			InitRobotData();


			Thread receiver = new Thread(new ThreadStart(Receive));
			receiver.IsBackground = false;
			receiver.Start();
			// as long as the receiver thread is running, the programm won't end
		}
		void Receive()
		{
			try
			{
				while (true)
				{
					byte[] bufferReceive = new byte[5000];
					socket.Receive(bufferReceive);
					string commandString = Encoding.ASCII.GetString(bufferReceive).Trim('\0');
					Console.WriteLine("Received:");
					Console.WriteLine(commandString);
					RobotCommand command = XmlSerialization.XmlToObject<RobotCommand>(commandString);

					Console.WriteLine("-----");
					RobotResponse response = ExecuteCommand(command);
					string responseString = XmlSerialization.ObjectToXml(response);

					byte[] bufferSend = Encoding.ASCII.GetBytes(responseString);
					Thread.Sleep(1000);
					socket.Send(bufferSend);
					Console.WriteLine("Sending:");
					Console.WriteLine(responseString);

					Console.WriteLine();
				}
			}
			catch
			{
				Console.WriteLine("Error receiving data. Exiting program...");
			}
		}

		private RobotResponse ExecuteCommand(RobotCommand command)
		{
			// for testing error messages:
			//return RobotResponse.CreateErrorResponse(command.TransactionID, "This is an error from the robot.");

			switch (command.Type)
			{
				case RobotCommandType.Home:
					MoveToHome();
					break;
				case RobotCommandType.Init:
					ResetRobot();
					return new RobotResponse(RobotResponseType.Init, position, command.TransactionID, BASE, TOOL, new IterateElementNamesXmlList<RobotFrame>(BASE_DATA), new IterateElementNamesXmlList<RobotFrame>(TOOL_DATA));
				case RobotCommandType.Gripper:
					SetGripper(command.GripperOpen.Value);
					break;
				case RobotCommandType.CartMove:
					MoveCart(command.CartPosition, command.MoveType.GetValueOrDefault(), command.RelativeMotion.Value);
					break;
				case RobotCommandType.AxisMove:
					MoveAxes(command.AxisPosition, command.RelativeMotion.Value);
					break;
				case RobotCommandType.SystemVariable:
					if (SetSystemVariable(command.SystemVariable) == null)
						return new RobotResponse(RobotResponseType.SystemVariable, position, command.TransactionID, BASE, TOOL, new IterateElementNamesXmlList<RobotFrame>(BASE_DATA), new IterateElementNamesXmlList<RobotFrame>(TOOL_DATA));
					else
						return new RobotResponse(RobotResponseType.Error, position, command.TransactionID, BASE, TOOL, new IterateElementNamesXmlList<RobotFrame>(BASE_DATA), new IterateElementNamesXmlList<RobotFrame>(TOOL_DATA), SetSystemVariable(command.SystemVariable));
				case RobotCommandType.TableRotation:
					break;
				default: throw new NotImplementedException();
			}
			return new RobotResponse(RobotResponseType.Normal, position, command.TransactionID, BASE, TOOL, new IterateElementNamesXmlList<RobotFrame>(BASE_DATA), new IterateElementNamesXmlList<RobotFrame>(TOOL_DATA));
		}







		#region execute commands
		private void SetGripper(bool value)
		{
			position.GripperOpen = value;
		}
		private void ResetRobot()
		{
			BASE = new RobotFrame(0, 0, 0, 0, 0, 0);
			TOOL = new RobotFrame(0, 0, 0, 0, 0, 0);
			RobotAxisPosition axisHome = new RobotAxisPosition(0, -90, 90, 0, 0, 0);
			position = new RobotPosition(axisHome, axisHome.ForwardTransformation(BASE, TOOL), false);
		}
		private void MoveToHome()
		{
			MoveAxes(new RobotAxisPosition(0, -90, 90, 0, 0, 0), false);
		}
		private void MoveCart(RobotCartPosition pos, RobotCartMoveType type, bool relative)
		{
			if (relative)
				position.CartPosition = pos + position.CartPosition;
			else
				position.CartPosition = pos;
			position.AxisPosition = position.CartPosition.BackwardTransformation(BASE, TOOL);
		}
		private void MoveAxes(RobotAxisPosition pos, bool relative)
		{
			if (relative)
				position.AxisPosition = position.AxisPosition + pos;
			else
				position.AxisPosition = pos;
			position.CartPosition = position.AxisPosition.ForwardTransformation(BASE, TOOL);
		}
		private string SetSystemVariable(RobotSystemVariable systemVariable)
		{
			switch (systemVariable.Name)
			{
				case "out":
					break;
				case "anout":
					break;
				case "base":
					if (systemVariable.ValueRobotFrame != null)
						BASE = systemVariable.ValueRobotFrame;
					else if (systemVariable.ValueInteger.HasValue)
					{
						if (systemVariable.ValueInteger < 1 || systemVariable.ValueInteger > 32)
							return "Index for systemvariable $BASE out of range.";
						BASE = BASE_DATA[systemVariable.ValueInteger.Value - 1];
					}
					else
						return "Missing data for systemvariable";
					position.CartPosition = position.AxisPosition.ForwardTransformation(BASE, TOOL);
					break;
				case "tool":
					if (systemVariable.ValueRobotFrame != null)
						TOOL = systemVariable.ValueRobotFrame;
					else if (systemVariable.ValueInteger.HasValue)
					{
						if (systemVariable.ValueInteger < 1 || systemVariable.ValueInteger > 32)
							return "Index for systemvariable $BASE out of range.";
						TOOL = TOOL_DATA[systemVariable.ValueInteger.Value - 1];
					}
					else
						return "Missing data for systemvariable";
					position.CartPosition = position.AxisPosition.ForwardTransformation(BASE, TOOL);
					break;
				default:
					return "Modifying this system variable not implemented.";
			}
			return null;
		}

		private void SetBase(RobotFrame BASE, int? BASEIndex)
		{
			if (BASE != null)
				this.BASE = BASE;
			else if (BASEIndex.HasValue)
				this.BASE = BASE_DATA[BASEIndex.Value - 1];
			position.CartPosition = position.AxisPosition.ForwardTransformation(this.BASE, TOOL);
		}
		private void SetTool(RobotFrame TOOL, int? TOOLIndex)
		{
			if (TOOL != null)
				this.TOOL = TOOL;
			else if (TOOLIndex.HasValue)
				this.TOOL = TOOL_DATA[TOOLIndex.Value - 1];
			position.CartPosition = position.AxisPosition.ForwardTransformation(BASE, this.TOOL);
		}
		#endregion






		private void InitRobotData()
		{
			int BDLen = RobotConfigData.numberEntriesBASE_DATA;
			int TDLen = RobotConfigData.numberEntriesTOOL_DATA;

			BASE_DATA = new RobotFrame[BDLen];
			TOOL_DATA = new RobotFrame[TDLen];
			for (int i = 1; i <= BDLen; i++)
			{
				BASE_DATA[i - 1] = new RobotFrame(i, i, i, i, i, i);
			}
			for (int i = BDLen + 1; i <= BDLen + TDLen; i++)
			{
				TOOL_DATA[i - 33] = new RobotFrame(i, i, i, i, i, i);
			}

			ResetRobot();
		}
	}
}
