using System;
using System.Reflection;
using ToyRobot.Model;

namespace ToyRobot.Doman
{
    public static class RobotCommand
    {
        public static void Reset(this Robot robot)
        {
            robot.Coordinate = (0, 0);
            robot.Orientation = Orientation.NORTH;
        }

        public static void Report(this Robot robot)
        {
            var (x, y) = robot.Coordinate;
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name.ToUpper()} \nOutput: {x},{y},{robot.Orientation}\n");
        }

        public static void Place(this Robot robot, (int, int) coordinate, Orientation? orientation = null)
        {
            if (orientation.HasValue)
                robot.Orientation = orientation.Value;

            var actionName = MethodBase.GetCurrentMethod().Name.ToUpper();
            if (robot.Set(coordinate, robot.Orientation, actionName))
            {
                Console.WriteLine($"{actionName} {coordinate.Item1},{coordinate.Item2},{orientation}");
            }
        }

        public static void Move(this Robot robot)
        {
            //move one block
            var (x, y) = robot.Coordinate;
            switch (robot.Orientation)
            {
                case Orientation.NORTH:
                    y += 1;
                    break;
                case Orientation.SOUTH:
                    y -= 1;
                    break;
                case Orientation.EAST:
                    x += 1;
                    break;
                case Orientation.WEST:
                    x -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var actionName = MethodBase.GetCurrentMethod().Name.ToUpper();
            if (robot.Set((x, y), robot.Orientation, actionName))
                Console.WriteLine($"{actionName}");
        }

        public static void Turn(this Robot robot, Direction direction)
        {
            var (x, y) = robot.Coordinate;

            if (direction == Direction.LEFT)
            {
                switch (robot.Orientation)
                {
                    case Orientation.NORTH:
                        robot.Orientation = Orientation.WEST;
                        break;
                    case Orientation.SOUTH:
                        robot.Orientation = Orientation.EAST;
                        break;
                    case Orientation.EAST:
                        robot.Orientation = Orientation.NORTH;
                        break;
                    case Orientation.WEST:
                        robot.Orientation = Orientation.SOUTH;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (direction == Direction.RIGHT)
            {
                switch (robot.Orientation)
                {
                    case Orientation.NORTH:
                        robot.Orientation = Orientation.EAST;
                        break;
                    case Orientation.SOUTH:
                        robot.Orientation = Orientation.WEST;
                        break;
                    case Orientation.EAST:
                        robot.Orientation = Orientation.SOUTH;
                        break;
                    case Orientation.WEST:
                        robot.Orientation = Orientation.NORTH;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }


            Console.WriteLine($"{direction}");
            robot.Coordinate = (x, y);
        }
    }
}