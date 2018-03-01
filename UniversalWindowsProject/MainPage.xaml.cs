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
using Simon.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalWindowsProject
{
    public sealed partial class MainPage : Page
    {
	    private readonly Quadrant _redQuadrant;
	    private readonly Quadrant _greenQuadrant;
	    private readonly Quadrant _blueQuadrant;
	    private readonly Quadrant _yellowQuadrant;
	    private readonly Simon.Model.Simon _simon;
		

        public MainPage()
        {
            this.InitializeComponent();
	        _redQuadrant = new Quadrant(Red, "1.mp3");
	        _greenQuadrant = new Quadrant(Green, "3.mp3");
	        _blueQuadrant = new Quadrant(Blue, "5.mp3");
	        _yellowQuadrant = new Quadrant(Yellow, "7.mp3");

	        var quadrants = new List<Quadrant>
	        {
				_redQuadrant,
				_greenQuadrant,
				_blueQuadrant,
		        _yellowQuadrant
			};

	        _simon = new Simon.Model.Simon(quadrants);

        }

	    private void ClickedQuadrant(Quadrant q)
	    {
			q.MakeNoise();
			q.Brighten();
	    }

	    private void Red_click(object sender, RoutedEventArgs e)
	    {
			ClickedQuadrant(_redQuadrant);
		}

	    private void Green_click(object sender, TappedRoutedEventArgs e)
	    {
			ClickedQuadrant(_greenQuadrant);

		}

	    private void Yellow_click(object sender, TappedRoutedEventArgs e)
	    {
		    ClickedQuadrant(_yellowQuadrant);
			
	    }

	    private void Blue_click(object sender, TappedRoutedEventArgs e)
	    {
			ClickedQuadrant(_blueQuadrant);
		}

	    private void StartButton_OnClick(object sender, RoutedEventArgs e)
	    {
		    _simon.Start();
	    }
    }
}
