using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Blaster_Improved
{
    class Shuttle
    {
        private int score;
        private Point shuttleLeftPoint;
        private Point shuttleOldLeftPoint;
        private const int shuttleLength = 8;
        private string theShuttle;
        private string spaces;
        public Shuttle()
        {
            score = 0;
            theShuttle = "|_/\\/\\_|";
            spaces = "";
            for (int i = 0; i < shuttleLength; i++)
            {
                spaces += " ";
            }
            shuttleLeftPoint = new Point(41, 50);
            shuttleOldLeftPoint = new Point(41, 50);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(shuttleLeftPoint.X, shuttleLeftPoint.Y);
            Console.Write(theShuttle);
        }
        public void AddScore()
        {
            score++;
        }
        public int GetScore()
        {
            return score;
        }
        public Point GetLocation()
        {
            return shuttleLeftPoint;
        }
        public void MoveShuttle(ConsoleKeyInfo cki)
        {
            OnKey(cki);
            Print();
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(shuttleOldLeftPoint.X, shuttleOldLeftPoint.Y);
            Console.Write(spaces);
            Console.SetCursorPosition(shuttleLeftPoint.X, shuttleLeftPoint.Y);
            Console.Write(theShuttle);
            shuttleOldLeftPoint.X = shuttleLeftPoint.X;
            shuttleOldLeftPoint.Y = shuttleLeftPoint.Y;
        }
        private void OnKey(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    shuttleLeftPoint.Y -= 2;
                    if (shuttleLeftPoint.Y < 30)
                        shuttleLeftPoint.Y = 29;
                    break;
                case ConsoleKey.DownArrow:
                    shuttleLeftPoint.Y += 2;
                    if (shuttleLeftPoint.Y > 50)
                        shuttleLeftPoint.Y = 50;
                    break;
                case ConsoleKey.RightArrow:
                    shuttleLeftPoint.X += 2;
                    if (shuttleLeftPoint.X > 82)
                        shuttleLeftPoint.X = 82;
                    break;
                case ConsoleKey.LeftArrow:
                    shuttleLeftPoint.X -= 2;
                    if (shuttleLeftPoint.X < 0)
                        shuttleLeftPoint.X = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
