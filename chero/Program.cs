using RobotController;
namespace chero
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for user input
            // parse to List of MoveActions
            Chero chero = new Chero();
            Engine engine = new Engine(chero, new List<MoveAction>());
            engine.transform().ForEach(action => action.execute());
        }
    }
}