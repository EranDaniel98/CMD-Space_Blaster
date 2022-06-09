using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Blaster_Improved
{
    class Rocket
    {
        private Point position;
        public RocketEvent rEvent;
        private const string str = "█";
        private ConsoleColor color;
        private bool shuttleShouts;
        public Rocket(Point p, bool shuttleShouts, RocketEvent rEvent)
        {
            this.rEvent = rEvent;
            this.shuttleShouts = shuttleShouts;
            position = p;
            color = ConsoleColor.Red;
            Print();
        }
        public void CheckAlienShoot(Shuttle s,ref bool gameOn)
        {
            if (position.Y == s.GetLocation().Y && position.X >= s.GetLocation().X && position.X <= s.GetLocation().X+7)
            {
                Console.SetCursorPosition(s.GetLocation().X, s.GetLocation().Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("        ");
                gameOn = false;
            }
        }
        public Point GetLocation()
        {
            return position;
        }
        public bool Move()
        {
            delete();
            if (shuttleShouts)
                position.Y -= 1;
            else
                position.Y += 1;
            if (position.Y <= 0 || position.Y > 54)
            {
                delete();
                return false;
            }
            Print();
            return true;
        }
        public void delete()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");
        }
        public void Print()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = color;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(str);
        }
    }
}
