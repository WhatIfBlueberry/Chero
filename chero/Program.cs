using RobotController;

namespace chero
{
    class Program
    {
        static void Main(string[] args)
        {
            Chero chero = new Chero("127.0.0.1", 59152);
            chero.start();
            chero.testrun();
            chero.stop();

        }
    }
}