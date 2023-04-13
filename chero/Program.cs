using RobotController;
namespace chero
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[] lines = InputParser.getInput();
            List<MoveAction> parsedActions = InputParser.parse(lines);
            Engine engine = new Engine(new Chero(), parsedActions);
            engine.transform().ForEach(action => Console.WriteLine(action));
        }
    }
}