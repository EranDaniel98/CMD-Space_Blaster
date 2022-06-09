using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Blaster_Improved
{
    delegate void MyRocketEvent(Shuttle s, Point p, Rocket r, ref List<Rocket> rockets, ref List<Alien> aliens);
    class RocketEvent
    {
        public event MyRocketEvent OnRocketMove;

        public void RocketMove(Shuttle s, Point p,Rocket r, ref List<Rocket> rockets, ref List<Alien> aliens)
        {
            if (OnRocketMove != null)
                OnRocketMove(s, p,r,ref rockets,ref aliens);
        }
    }
}
