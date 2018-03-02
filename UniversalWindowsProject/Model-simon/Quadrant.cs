using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Simon.Model
{
	class Quadrant
	{
		private Ellipse _shape;
		private MediaPlayer player;
		private bool playing;
		private string _soundName;
		private Brush oldBrush;

		public Quadrant(Ellipse shape, string soundName)
		{
			_shape = shape;
			// when a quadrant is made with shape as null, it's just needed for the sound, not the Ellipse
			oldBrush = shape?.Fill;
			_soundName = soundName;
			player = new MediaPlayer();
		}
		// Sound

		public async void MakeNoise()
		{
			var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
			var file = await folder.GetFileAsync(_soundName);

			player.AutoPlay = false;
			player.Source = MediaSource.CreateFromStorageFile(file);

//	        if (playing)
//	        {
//		        player.Source = null;
//		        playing = false;
//	        }
//	        else
//	        {
			player.Play();
//		        playing = true;
//	        }
		}

		public void Brighten()
		{
			Color c1;
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

			Color c2 = Color.FromArgb(c1.A,
				(byte) (c1.R *1.6), (byte) (c1.G * 1.6), (byte) (c1.B * 1.6));
			_shape.Fill = new SolidColorBrush(c2);
		}

		public void ResetColour()
		{

			// remove border
			_shape.Fill = oldBrush;
		}
	}
}