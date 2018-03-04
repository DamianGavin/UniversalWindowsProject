using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Simon.Model
{
    class Simon
    {
        private readonly List<Quadrant> _history;
        private readonly List<Quadrant> _quadrants;
	    private readonly Random _rnd;

	    private readonly Quadrant buzzer = new Quadrant(null, "Buzz.mp3");
		// create getter and sett and also assign a default value
	    public bool SimonsTurn { get; set; } = false;
	    private int HighScore { get; set; }


	    public int TurnNo =>_history.Count;


        private Quadrant GetAt(int i)
        {
            return _quadrants[i];
        }

        public Simon(List<Quadrant> quadrants)
        {
	        _rnd = new Random();
            this._history = new List<Quadrant>();
	
            this._quadrants = quadrants;

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
		    _history.Add(NextQuadrant());
		    // plays entire history
		    foreach (var quadrant in _history)
		    {
			    quadrant.MakeNoise();
			    quadrant.Brighten();
			    // wait some amount time
				await Task.Delay(800);
			    quadrant.ResetColour();
				
			}

			// toggle to allow player turn
		    SimonsTurn = false;

	    }

	    public bool OnTrack(int userChoice, int userClickNo)
	    {
		    if (userClickNo >= _history.Count)
		    {
			    return false;
		    }

		    var historyQuad = _history[userClickNo];
		    return GetAt(userChoice) == historyQuad;
	    }

        public void Reset()
        {
            _history.Clear();
        }

        private Quadrant NextQuadrant()
        {
			// choose random element from quadrants
			// simon picks random element from quadrants
	        var index = _rnd.Next(_quadrants.Count); // generate number between 0-3
	        var quad = _quadrants[index];
	        return quad;
        }

	    public async void Tap(int index)
	    {
		    var quadrant = GetAt(index);
			quadrant.MakeNoise();
		    quadrant.Brighten();
		    // wait some amount time
		    await Task.Delay(800);
		    quadrant.ResetColour();
		}

	    public void Buzz()
	    {
	    
		    buzzer.MakeNoise();
	    }
    }
}
