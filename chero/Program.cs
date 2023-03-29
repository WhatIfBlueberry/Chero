using RobotController;
namespace chero
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<MoveAction> parsedActions = InputParser.parse();
            Engine engine = new Engine(new Chero(), parsedActions);
            engine.transform().ForEach(action => Console.WriteLine(action));
        }
    }
}