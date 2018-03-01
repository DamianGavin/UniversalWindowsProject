using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalWindowsProject
{
    public sealed partial class MainPage : Page
    {
	    MediaPlayer player;
	    bool playing;
        public MainPage()
        {
            this.InitializeComponent();
			player = new MediaPlayer();
	        playing = false;
        }

	    private async void Button_click(object sender, RoutedEventArgs e)
	    {
		    Windows.Storage.StorageFolder folder =
			    await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
		    var file = await folder.GetFileAsync("3.mp3");

		    player.AutoPlay = false;
		    player.Source = MediaSource.CreateFromStorageFile(file);

		    if (playing)
		    {
			    player.Source = null;
			    playing = false;
		    }
		    else
		    {
			    player.Play();
			    playing = true;
		    }
	    }
    }
}
