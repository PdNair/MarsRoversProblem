using MarsRoversProblem;
using System;

namespace MarsRoverProblem
{
    public interface ICalculate
    {
        void Navigate(string command);
    }

    public class Calculate : ICalculate
    {
        public int xLimit { get; set; }
        public int yLimit { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Calculate()
        {
            X = Y = 1;
            Direction = Directions.North;
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.West;
                    break;
                case Directions.South:
                    Direction = Directions.East;
                    break;
                case Directions.East:
                    Direction = Directions.North;
                    break;
                case Directions.West:
                    Direction = Directions.South;
                    break;
                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
                default:
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Directions.North:
                    Y++;
                    CheckLimit();
                    break;
                case Directions.South:
                    Y--;
                    CheckLimit();
                    break;
                case Directions.East:
                    X++;
                    CheckLimit();
                    break;
                case Directions.West:
                    X--;
                    CheckLimit();
                    break;
                default:
                    break;
            }
        }

        private void CheckLimit()
        {
            if (X >= xLimit)
                X = xLimit;
            if (Y >= yLimit)
                Y = yLimit;
            if (X <= 1)
                X = 1;
            if (Y <= 1)
                Y = 1;
        }

        public void Navigate(string commandSet)
        {
            foreach (char command in commandSet)
            {
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {command}");
                        break;
                }
            }
        }
    }
}