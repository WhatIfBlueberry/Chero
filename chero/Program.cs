using RobotController;

namespace chero
{
    class Program
    {
        static void Main(string[] args)
        {
            Chero chero = new Chero();
            chero.start();
            //chero.testrun();
            //Console.WriteLine(Field.A1.ToString());
            chero.moveFromTo(Field.A3, Field.B3, true);
            //chero.stop();

        }
    }
}