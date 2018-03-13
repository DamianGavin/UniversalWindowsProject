using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Simon.Model;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalWindowsProject
{
	public sealed partial class MainPage : Page
	{
		private readonly Simon.Model.Simon _simon;
		private int _currentClickNo;
		private int _currentScore;
		private readonly Storage _storage;
		private int _totalClicks;


		private readonly int RED_INDEX = 0;
		private readonly int GREEN_INDEX = 1;
		private readonly int YELLOW_INDEX = 2;
		private readonly int BLUE_INDEX = 3;

		public MainPage()
		{
			InitializeComponent();
			_storage = new Storage();
			_simon = new Simon.Model.Simon(new List<Quadrant>
			{
				new Quadrant(Red, "r.mp3"),
				new Quadrant(Green, "g.mp3"),
				new Quadrant(Yellow, "y.mp3"),
				new Quadrant(Blue, "b.mp3")
			});
		}


		private async void QuadrantClicked(int index)
		{
			/*
			 * We only want to handle a click event if it is the user's turn.
			 */
			if (_simon.SimonsTurn) return;


			var onTrack = _simon.OnTrack(index, _currentClickNo);
			if (!onTrack)
			{
				_simon.Reset();
				_currentClickNo = 0;
				_simon.Buzz();
				CurrentScore.Text = "Your score was: " + _currentScore;
				_totalClicks = 0;
				BigX.Visibility = Visibility.Visible;
				await Task.Delay(1800);
				StartButton.Visibility = Visibility.Visible;
				HighScoreButton.Visibility = Visibility.Visible;
				BigX.Visibility = Visibility.Collapsed;

				return;
			}


			_simon.Tap(index);


			_currentClickNo++;
			_totalClicks++;

			_currentScore = _totalClicks * 10;
			CurrentScore.Text = "Current score: " + _currentScore;
			if (_currentScore > _storage.GetHighScore()) _storage.SaveHighScore(_currentScore);

			var endOfRound = _currentClickNo == _simon.TurnNo;

			if (endOfRound)
			{
				_currentClickNo = 0;
				_simon.SimonsTurn = true;
				await Task.Delay(1400);
				_simon.Start();
			}

			// check if the moves so far are correct.
		}

		private void Red_click(object sender, RoutedEventArgs e)
		{
			QuadrantClicked(RED_INDEX);
		}

		private void Green_click(object sender, TappedRoutedEventArgs e)
		{
			QuadrantClicked(GREEN_INDEX);
		}

		private void Yellow_click(object sender, TappedRoutedEventArgs e)
		{
			QuadrantClicked(YELLOW_INDEX);
		}

		private void Blue_click(object sender, TappedRoutedEventArgs e)
		{
			QuadrantClicked(BLUE_INDEX);
		}

		private void StartButton_OnClick(object sender, RoutedEventArgs e)
		{
			CurrentScore.Text = "Current Score: 0";
			_simon.Start();
			StartButton.Visibility = Visibility.Collapsed;
			HighScoreButton.Visibility = Visibility.Collapsed;
		}

		private void StatsButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (_simon.SimonsTurn) return;
			Frame.Navigate(typeof(StatsPage));
		}

		private void BtnSettings_OnClick(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(StatsPage));
		}
	}
}