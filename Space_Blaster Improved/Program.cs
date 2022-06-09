using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Blaster_Improved
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            ShuttleEvent se = new ShuttleEvent();
            Shuttle shuttle = new Shuttle();
            Alien a1 = new Alien(new Point(10 - 2, 10));
            Alien a2 = new Alien(new Point(20 - 2, 10));
            Alien a3 = new Alien(new Point(30 - 2, 10));
            Alien a4 = new Alien(new Point(40 - 2, 10));
            Alien a5 = new Alien(new Point(50 - 2, 10));
            Alien a6 = new Alien(new Point(60 - 2, 10));
            Alien a7 = new Alien(new Point(70 - 2, 10));
            Alien a8 = new Alien(new Point(80 - 2, 10));
            List<Alien> aliens = new List<Alien>();
            Random rnd = new Random();
            aliens.Add(a1);
            aliens.Add(a2);
            aliens.Add(a3);
            aliens.Add(a4);
            aliens.Add(a5);
            aliens.Add(a6);
            aliens.Add(a7);
            aliens.Add(a8);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("The score is = {0}                                                 ", shuttle.GetScore());
            List<Rocket> shuttleRockets = new List<Rocket>();
            List<Rocket> alienRockets = new List<Rocket>();
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            int j = 0;
            while (true)
            {
                j++;
                if (Console.KeyAvailable == true)
                {
                    keyinfo = Console.ReadKey(true);
                    shuttle.MoveShuttle(keyinfo);
                    if (keyinfo.Key == ConsoleKey.Spacebar)
                    {
                        RocketEvent re = new RocketEvent();
                        for (int i = 0; i < aliens.Count; i++)
                        {
                            re.OnRocketMove += aliens[i].CheckShoot;
                        }
                        Rocket r = new Rocket(new Point(shuttle.GetLocation().X + 3, shuttle.GetLocation().Y - 1), true, re);
                        shuttleRockets.Add(r);
                    }
                }

                for (int i = 0; i < shuttleRockets.Count; i++)
                {
                    if (!shuttleRockets[i].Move())
                    {
                        shuttleRockets.Remove(shuttleRockets[i]);
                    }
                    else
                    {
                        shuttleRockets[i].rEvent.RocketMove(shuttle, shuttleRockets[i].GetLocation(), shuttleRockets[i], ref shuttleRockets, ref aliens);
                    }
                }
                if (j % 100 == 0)
                {
                    if (aliens.Count == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(40, 30);
                        Console.WriteLine("Game Over");
                        Console.SetCursorPosition(35, 31);
                        Console.WriteLine("Your score is: " + shuttle.GetScore());
                        break;
                    }
                    aliens[rnd.Next(aliens.Count)].Shoot(se, ref alienRockets);

                }
                for (int i = 0; i < alienRockets.Count; i++)
                {
                    if (!alienRockets[i].Move())
                    {
                        se.OnRocketMove -= alienRockets[i].CheckAlienShoot;
                        alienRockets.Remove(alienRockets[i]);
                    }
                }
                bool gameOn = true;
                se.RocketMove(ref gameOn, shuttle);
                if (!gameOn)
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 30);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(35, 31);
                    Console.WriteLine("Your score is: " + shuttle.GetScore());
                    break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("The score is = {0}           ", shuttle.GetScore());
                System.Threading.Thread.Sleep(30);
            }
            Console.ReadKey();
        }
        public static void Init()
        {
            Console.SetWindowSize(90, 60);
            Console.SetBufferSize(90, 60);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Space Blaster";
        }
    }
}
