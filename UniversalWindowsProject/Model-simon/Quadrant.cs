using System;
using Windows.ApplicationModel;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Simon.Model
{
	/*
	 * A Quadrant represents one of the 4 circles
	 *  that the user can click. It consists of an Ellipse and a Sound.
	 */
	internal class Quadrant
	{
	
		private readonly Ellipse _shape;
		private readonly MediaPlayer player;
		private bool playing;
		private readonly string _soundName;
		// In order to implement the brush change, we save the old brush and re-assign it later.
		private readonly Brush oldBrush;

		public Quadrant(Ellipse shape, string soundName)
		{
			_shape = shape;
			// when a quadrant is made with shape as null, it's just needed for the sound, not the Ellipse
			// using the sytanx shape?.Fill it will ignore shape if it's null to avoid a NullReferenceException
			oldBrush = shape?.Fill; 
			_soundName = soundName;
			player = new MediaPlayer();
		}
	

		public async void MakeNoise()
		{
			var folder = await Package.Current.InstalledLocation.GetFolderAsync(@"Sounds");
			var file = await folder.GetFileAsync(_soundName);

			player.AutoPlay = false;
			player.Source = MediaSource.CreateFromStorageFile(file);
			player.Play(); // play the actual audio file to completion

		}

		public void Brighten()
		{
			Color c1;
			/*
			 * A tag is added to each Ellipse in the XAML in order
			 * to choose the appropriate colour here.
			 */
			switch (_shape.Tag.ToString())
			{
				case "B":
					c1 = Colors.Blue;
					break;
				case "Y":
					c1 = Colors.Yellow;
					break;
				case "R":
					c1 = Colors.Red;
					break;
				case "G":
					c1 = Colors.Green;
					break;
			}

			// put a border on ellipse
			// adjust the existing colour
			var c2 = Color.FromArgb(c1.A,
				(byte) (c1.R * 1.6), (byte) (c1.G * 1.6), (byte) (c1.B * 1.6));
			_shape.Fill = new SolidColorBrush(c2); // assign the new brush to be visible to user
		}

		public void ResetColour()
		{
			_shape.Fill = oldBrush; // set the brush back to the original
		}
	}
}