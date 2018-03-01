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
		    oldBrush = shape.Fill;
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
			_shape.Fill = new SolidColorBrush(Colors.Wheat);
        }

	    public void ResetColour()
	    {
		    _shape.Fill = oldBrush;
	    }

    }
}
