using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Blaster_Improved
{
    class Alien
    {
        //private string theAlien = "";
        //private string spaces = "";
        //private int AlienLength = 3;
        private Point position;
        public Alien(Point p)
        {
            position = p;
            //for (int i = 0; i < AlienLength; i++)
            //{
            //    theAlien += "0";
            //    spaces += " ";
            //}
            Console.SetCursorPosition(position.X, position.Y);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("  ");
        }
        public void Shoot(ShuttleEvent se,ref List<Rocket> ar)
        {
            Rocket bomb = new Rocket(new Point(position.X, position.Y + 1), false, null);
            se.OnRocketMove += bomb.CheckAlienShoot;
            ar.Add(bomb);
        }
        public void CheckShoot(Shuttle s, Point p,Rocket r, ref List<Rocket> rockets,ref List<Alien> aliens)
        {
            if (position == p || (position.X + 1 == p.X && position.Y == p.Y))
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
                Console.SetCursorPosition(position.X + 1, position.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
                s.AddScore();
                r.delete();
                rockets.Remove(r);
                aliens.Remove(this);
                for (int i = 0; i < rockets.Count; i++)
                {
                    rockets[i].rEvent.OnRocketMove -= this.CheckShoot;
                }
            }

        }
    }
}
