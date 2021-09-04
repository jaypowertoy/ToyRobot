using System;
using ToyRobot.Doman;
using ToyRobot.Model;

namespace ToyRobot
{
    static class Program
    {
        public static readonly int Size = 6;

        static void Main()
        {
            Console.WriteLine($"This is a {Size} x {Size} square tabletop... \n ");

            Console.WriteLine("New Robot: ");
            var robot6 = new Robot { SquareSize = Size };

            //a)
            Console.WriteLine("a)");
            robot6.Place((0, 0), Orientation.NORTH);
            robot6.Move();
            robot6.Report();
            robot6.Reset();


            //b)
            Console.WriteLine("b)");
            robot6.Place((0, 0), Orientation.NORTH);
            robot6.Turn(Direction.LEFT);
            robot6.Report();
            robot6.Reset();

            //c)
            Console.WriteLine("c)");
            robot6.Place((1, 2), Orientation.EAST);
            robot6.Move();
            robot6.Move();
            robot6.Turn(Direction.LEFT);
            robot6.Move();
            robot6.Report();
            robot6.Reset();

            //d)
            Console.WriteLine("d)");
            robot6.Place((1, 2), Orientation.EAST);
            robot6.Move();
            robot6.Turn(Direction.LEFT);
            robot6.Move();
            robot6.Place((3, 1));
            robot6.Move();
            robot6.Report();
            robot6.Reset();

            //e)
            Console.WriteLine("e)");
            robot6.Place((6, 6)); //this should be discarded
            robot6.Move();
            robot6.Move();
            robot6.Report();

            //f)
            Console.WriteLine("f)");
            robot6.Place((5, 5));
            robot6.Move(); //this should be discarded
            robot6.Turn(Direction.LEFT);
            robot6.Move();
            robot6.Report();


            var robot7 = new Robot { SquareSize = 7 };


            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }
    }
}