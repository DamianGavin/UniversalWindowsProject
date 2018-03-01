using System;
using System.Collections.Generic;

namespace Simon.Model
{
    class Simon
    {
        private List<Quadrant> history;
        private List<Quadrant> quadrants;
	    private readonly Random _rnd;


        public int TurnNo => history.Count;


        public Quadrant GetAt(int i)
        {
            return quadrants[i];
        }

        public Simon(List<Quadrant> quadrants)
        {
	        _rnd = new Random();
            this.history = new List<Quadrant>();
            this.quadrants = quadrants;
        }

	    public void Start()
	    {
			// simon picks random element from quadrants
		    var index = _rnd.Next(quadrants.Count); // generate number between 0-3
		    var quad = quadrants[index];
		    // adds it to history.
			history.Add(quad);
		    // plays entire history
		    foreach (var quadrant in history)
		    {
				quadrant.MakeNoise();
				quadrant.Brighten();

				// wait some amount time
		    }

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
