using System;
using System.Collections.Generic;

namespace Simon.Model
{
    class Simon
    {
        private List<Quadrant> history;
        private List<Quadrant> quadrants;


        public int TurnNo => history.Count;


        public Quadrant GetAt(int i)
        {
            return quadrants[i];
        }

        public Simon(List<Quadrant> quadrants)
        {
            this.history = new List<Quadrant>();
            this.quadrants = quadrants;
        }


        public Boolean DoesMatch(List<int> choices)
        {
            return false;
        }


        public void Play()
        {
            history.Add(NextQuadrant());

            // do stuff wtith history
            foreach (var q in history)
            {
                q.MakeNoise();
                q.Brighten();
            }
        }

        public void Reset()
        {
            history.Clear();
        }

        private Quadrant NextQuadrant()
        {
            // choose random element from quadrants
            throw new System.NotImplementedException();
        }
    }
}
