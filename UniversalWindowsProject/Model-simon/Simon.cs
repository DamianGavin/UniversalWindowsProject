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

	    private readonly Quadrant buzzer = new Quadrant(null, "Buzz.mp3");
		// create getter and sett and also assign a default value
	    public bool SimonsTurn { get; set; } = false;
	    private int HighScore { get; set; }


	    public int TurnNo => history.Count;


        private Quadrant GetAt(int i)
        {
            return quadrants[i];
        }

        public Simon(List<Quadrant> quadrants)
        {
	        _rnd = new Random();
            this.history = new List<Quadrant>();
	
            this.quadrants = quadrants;

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

		    SimonsTurn = true;
		    // adds it to history.
		    history.Add(NextQuadrant());
		    // plays entire history
		    foreach (var quadrant in history)
		    {
			    quadrant.MakeNoise();
			    quadrant.Brighten();
			    // wait some amount time
				await Task.Delay(1200);
			    quadrant.ResetColour();
				
			}

			// toggle to allow player turn
		    SimonsTurn = false;

	    }

	    public bool OnTrack(int userChoice, int userClickNo)
	    {
		    if (userClickNo >= history.Count)
		    {
			    return false;
		    }

		    var historyQuad = history[userClickNo];
		    return GetAt(userChoice) == historyQuad;
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
//	        index = 3;
	        var quad = quadrants[index];
	        return quad;
        }

	    public async void Tap(int index)
	    {
		    var quadrant = GetAt(index);
			quadrant.MakeNoise();
		    quadrant.Brighten();
		    // wait some amount time
		    await Task.Delay(1200);
		    quadrant.ResetColour();
		}

	    public void Buzz()
	    {
	    
		    buzzer.MakeNoise();
	    }
    }
}
