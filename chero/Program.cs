using RobotController;

namespace chero
{
    class Program
    {
        static void Main(string[] args)
        {
            Chero chero = new Chero();
            chero.start();
            chero.moveFromTo(Field.E2, Field.E4);
            chero.moveFromTo(Field.E7, Field.E5);
            chero.moveFromTo(Field.D4, Field.H5);
            chero.moveFromTo(Field.B8, Field.C6);
            chero.moveFromTo(Field.F1, Field.C4);
            chero.moveFromTo(Field.H5, Field.F7);
            chero.moveFromTo(Field.G8, Field.F6);
            chero.moveFromTo(Field.F7, Field.Trash);
            chero.moveFromTo(Field.H5, Field.F7);
            //chero.stop();
            //This could be a good place to put your code

        }
    }
}