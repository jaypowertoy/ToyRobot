using System;

namespace ToyRobot.Model
{
    public class Robot
    {
        public int SquareSize { get; set; }
        public (int, int) Coordinate { get; set; }
        public Orientation Orientation { get; set; }

        public bool Set((int, int) coordinate, Orientation orientation, string actionName)
        {
            if (!IsValidPosition(coordinate))
            {
                Console.WriteLine($"Command {actionName} Discard!");
                return false;//discard commands outside of the table
            }
            this.Coordinate = coordinate;
            this.Orientation = orientation;

            return true;
        }

        public bool IsValidPosition((int, int) coordinate)
        {
            var (x, y) = coordinate;
            return x < SquareSize && y < SquareSize;
        }
    }
}