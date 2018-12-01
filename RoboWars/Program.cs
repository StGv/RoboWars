using RoboWars.Arena;
using System;

namespace RoboWars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Grid dimentions(x,y): ");
            string input = Console.ReadLine();
            var parts = input.Split(' ');
            int x = Convert.ToInt32(parts[0]);
            int y = Convert.ToInt32(parts[1]);

            var terrain = new TerrainGrid(x, y);

            //Console.Write("Number of robots: ");
            int numRobots = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numRobots; i++)
            {
                string robotPosition = Console.ReadLine();
                var robotPositionParts = robotPosition.Split(' ');
                int robotPositionX = Convert.ToInt32(robotPositionParts[0]);
                int robotPositionY = Convert.ToInt32(robotPositionParts[1]);
                string robotPositionOrientation = robotPositionParts[2];
                var robot = new Robot(terrain, new GridPoint(robotPositionX, robotPositionY), CompassDirection.NORTH);
                switch (robotPositionOrientation)
                {
                    case "S":
                        robot = new Robot(terrain, new GridPoint(robotPositionX, robotPositionY), CompassDirection.SOUTH);
                        break;
                    case "E":
                        robot = new Robot(terrain, new GridPoint(robotPositionX, robotPositionY), CompassDirection.EAST);
                        break;
                    case "W":
                        robot = new Robot(terrain, new GridPoint(robotPositionX, robotPositionY), CompassDirection.WEST);
                        break;
                }

                string commands = Console.ReadLine();
                foreach (char letter in commands)
                {
                    switch (letter)
                    {
                        case 'M':
                            robot.MoveForward();
                            break;
                        case 'L':
                            robot.TurnLeft();
                            break;
                        case 'R':
                            robot.TurnRight();
                            break;
                    }
                }

                Console.WriteLine($"{robot.CurrentGridPosition.X} {robot.CurrentGridPosition.Y} {robot.CurrentCompassOrientation.ToString()}");
            }

            Console.ReadKey();
        }
    }
}
