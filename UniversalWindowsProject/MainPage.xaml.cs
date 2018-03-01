using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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


	    private readonly int RED_INDEX = 0;
	    private readonly int GREEN_INDEX = 1;
	    private readonly int YELLOW_INDEX = 2;
	    private readonly int BLUE_INDEX = 3;

        public MainPage()
        {
            this.InitializeComponent();
	        userSelected = new List<int>();
	        _redQuadrant = new Quadrant(Red, "Red.mp3");
	        _greenQuadrant = new Quadrant(Green, "Green.mp3");
	        _blueQuadrant = new Quadrant(Blue, "Blue.mp3");
	        _yellowQuadrant = new Quadrant(Yellow, "Yellow.mp3");

	        var quadrants = new List<Quadrant>
	        {
				_redQuadrant,
				_greenQuadrant,
		        _yellowQuadrant,
				_blueQuadrant
		       
			};

	        _simon = new Simon.Model.Simon(quadrants);


        }


	    private async void QuadrantClicked(int index)
	    {
		    userSelected.Add(index);
		    _simon.Tap(index);

		    if (userSelected.Count == _simon.TurnNo)
		    {
			    if (_simon.SimonsTurn)
			    {
				    return;
			    }
			    // check to see if the user's clicks matched the history of simon
			    bool userGotItRight = _simon.DoesMatch(userSelected);
			    if (userGotItRight)
			    {
				    TextBlock.Text = "Correct";
			    }
			    else
			    {
				    TextBlock.Text = "Wrong!";
				    _simon.Reset();
			    }

			    await Task.Delay(5000);
				userSelected.Clear();
				_simon.Start();
			}
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
		    _simon.Start();
	    }

	

    }
}
