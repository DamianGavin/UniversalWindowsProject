using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Simon.Model
{
    class Simon
    {
        private List<Quadrant> history;
        private List<Quadrant> quadrants;
	    private readonly Random _rnd;
	    private bool computerTurn = true;


        public int TurnNo => history.Count;


        private Quadrant GetAt(int i)
        {
            return quadrants[i];
        }

        public Simon(List<Quadrant> quadrants)
        {
	        _rnd = new Random();
//            this.history = new List<Quadrant>();
	
            this.quadrants = quadrants;
	        history = new List<Quadrant>
	        {
		        GetAt(1),
		        GetAt(3)
	        };
		}

	    public async void Start()
	    {
			// perform logic in a different thread so blocking doesn't hang the UI

			// this post shows how to change a variable that is used in one thread, in a different thread
			// https://stackoverflow.com/questions/19341591/the-application-called-an-interface-that-was-marshalled-for-a-different-thread
			// pass in the method directly to be run in a different thread.
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
				ComputerTurn
			);

		}

	    public async void ComputerTurn()
	    {
		    
		    // adds it to history.
		    history.Add(NextQuadrant());
		    // plays entire history
		    foreach (var quadrant in history)
		    {
			    quadrant.MakeNoise();
			    quadrant.Brighten();
			    await Task.Delay(1200);
			    quadrant.ResetColour();
				// wait some amount time
			}

			// toggle to allow player turn
		    computerTurn = false;

	    }

		
	    public bool DoesMatch(List<int> choices)
	    {

			// look at everything in the history
			// and see if the choices line up.

			// user inut: [3,4]
			// history : [RED,BLUE]

			
		    int choiceIndex = 0;
		    foreach (var quad in history)
		    {

			    if (GetAt(choices[choiceIndex]) != quad)
			    {
				    return false;
			    }

			    choiceIndex++;
		    }
			

//		    var quadrants = choices.Select(GetAt).ToList();
//		    return quadrants.Equals(history);
		    return true;
        }

        public void Reset()
        {
            history.Clear();
        }

        private Quadrant NextQuadrant()
        {
			// choose random element from quadrants
			// simon picks random element from quadrants
	        var index = _rnd.Next(quadrants.Count); // generate number between 0-3
	        var quad = quadrants[index];
	        return quad;
        }
    }
}
