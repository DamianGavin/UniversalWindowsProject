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
using UniversalWindowsProject.Model_simon;

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
	    private List<int> userSelected;
		

        public MainPage()
        {
            this.InitializeComponent();
	        userSelected = new List<int>();
	        _redQuadrant = new Quadrant(Red, "1.mp3");
	        _greenQuadrant = new Quadrant(Green, "3.mp3");
	        _blueQuadrant = new Quadrant(Blue, "5.mp3");
	        _yellowQuadrant = new Quadrant(Yellow, "7.mp3");

	        var quadrants = new List<Quadrant>
	        {
				_redQuadrant,
				_greenQuadrant,
		        _yellowQuadrant,
				_blueQuadrant
		       
			};

	        _simon = new Simon.Model.Simon(quadrants);

			// call this on submit button
	        _simon.DoesMatch(new List<int> {1, 2});

//	        var storage = new Storage();
//			storage.SaveHighScore(29);
//
//	        int score = storage.GetHighScore();

        }

	    private void ClickedQuadrant(Quadrant q)
	    {
			q.MakeNoise();
			q.Brighten();
	    }

	    private void Red_click(object sender, RoutedEventArgs e)
	    {
			userSelected.Add(0);
			// make the tile flash
			// play sound
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

		/*
		 *Verify correct
		 *
		 * get the list of ints from user
		 * pass it into simon.DoesMatch()
		 * in there, verify all the ints in the list match up with the history values.
		 * return true/false
		 *
		 */
    }
}
