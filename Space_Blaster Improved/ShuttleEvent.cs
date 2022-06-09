using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Blaster_Improved
{
    delegate void MyShuttleEvent(Shuttle s, ref bool gameOn);
    class ShuttleEvent
    {
        public event MyShuttleEvent OnRocketMove;
        public void RocketMove(ref bool gameOn,Shuttle s)
        {
            if (OnRocketMove != null)
                OnRocketMove(s,ref gameOn);
        }
    }
}
