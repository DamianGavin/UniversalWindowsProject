using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Simon.Model
{
	internal class Simon
	{
		private readonly List<Quadrant> _history;
		private readonly List<Quadrant> _quadrants;
		private readonly Random _rnd;

		// buzzer is a special quadrant that is not intended to be seen (shape is null)
		// this is used only to make a buzz noise when the user gets it wrong.
		private readonly Quadrant _buzzer = new Quadrant(null, "Buzz.mp3");

		// create getter and sett and also assign a default value
		public bool SimonsTurn { get; set; }


		public int TurnNo => _history.Count;


		// provide access to quadrants without exposing the list.
		private Quadrant GetAt(int i)
		{
			return _quadrants[i];
		}

		/*
		 * Simon gets created with a list of quadrants
		 * and an empty history.
		 */
		public Simon(List<Quadrant> quadrants)
		{
			_rnd = new Random();
			_history = new List<Quadrant>();

			_quadrants = quadrants;
		}

		public async void Start()
		{
			// perform logic in a different thread so blocking doesn't hang the UI

			// this post shows how to change a variable that is used in one thread, in a different thread
			// https://stackoverflow.com/questions/19341591/the-application-called-an-interface-that-was-marshalled-for-a-different-thread
			// pass in the method directly to be run in a different thread.
			await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
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

		/*
		 * the OnTrack method is called every time the user clicks a quadrant.
		 * It returns true if the user has chosen the correct quadrant for the current click.
		 * A return value of false means the user got it wrong.
		 */
		public bool OnTrack(int userChoice, int userClickNo)
		{
			// if the user has clicked more times than there are previous beeps,
			// they can't be right - prevents the user clicking too much and breaking it.
			if (userClickNo >= _history.Count) return false;

			// look at the corresponding quadrant from the history
			var historyQuad = _history[userClickNo];
			// compare them, we can use == instead of .Equals because they are the same object in memory.
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
			// get the corresponding quadrant
			var quadrant = GetAt(index);
			quadrant.MakeNoise();
			quadrant.Brighten();
			// wait some amount time
			await Task.Delay(800);
			quadrant.ResetColour();
		}

		public void Buzz()
		{
			_buzzer.MakeNoise();
		}
	}
}