using RobotController;
namespace chero
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<MoveAction> parsedActions = InputParser.parse();
            Chero chero = new Chero();
            Engine engine = new Engine(chero, parsedActions);
            engine.transform().ForEach(action => Console.WriteLine(action));
        }
    }
}