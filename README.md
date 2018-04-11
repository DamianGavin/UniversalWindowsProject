
# sXamlon

Classic memory game with features of sound and colour. Randomly generated patterns and persistence for scores. Its purpose is to
present a memory challenge by rewarding the user with more points depending on how long a pattern they can repeat, allowing them 
to improve their scores in a completely random generated environment. If they get an error repeating the pattern the game ends.


It has been created accomplishing the following requiremens:
```
Create a Universal Windows Project (UWP) that will each demonstrate the use of Isolated 
Storage and at least one other sensor or service available on the devices. These include: 

* Accelerometer or Gyroscope 
* GPS (Location Based Services)
* Sound
* Network Services (connecting to server for data updates etc)
* Camera
* Multi Touch Gesture Management

The UWP application should be well designed with a clear purpose and an answer to the 
question  “why will the user open this app for a second time?”
```
Repository for 3rd Year Module Mobile Applications Development 2 (2018)

### Code
As with all Universal Windows Packages, Visual Studio provided me with Two pages, App.xaml and 
MainPage.xaml. These pages each have a file associated with them called the code behind.
App.xaml.cs and MainPage.xaml.cs.
On top of these pages I have created Two folders: Model-simon, and Sounds. I also made a page 
called StatsPage.xaml with its associated StatsPage.xaml.cs.

Model-simon contains Three C# files called Quadrant.cs, Simon.cs and Storage.cs. 

The Quadrant.cs I created a Quadrant class to encapsulate the behaviour of one section of the game
that consists of a Shape and a Sound. I used async methods to perform actions that would otherwise
block the UI thread such as playing sounds. I gave the methods descriptive and consise names to make 
the code more readable.

Simon.cs encapsulates the game itself. It keeps track of everything required to play the game. I have
extensively commented the code. 

Storage.cs
This is a where I implement local storage by initially wiping it and then assigning "highScore"
to LocalSettings.Values. It provides a convenient way to access local storage without needeing to access
it directly each time. It also makes the code easier to understand.
```
public void SaveHighScore(int score)
		{
			ApplicationData.Current.LocalSettings.Values["highScore"] = score;
		}
```
My Sounds folder contains Five mp3 files containing the different sounds I use in my App.

MainPage.xaml and StatsPage.xaml are used to design the layout and colours of my App. 

My StatsPage.xaml.cs page is used to control navigation between pages in the App, and also
contains the logic for the 3 buttons available on the highscore page.
```
private void ResetButton_OnClick(object sender, RoutedEventArgs e)
		{
			ButtonPanel.Visibility = Visibility.Visible;
		}

		private void YesButton_OnClick(object sender, RoutedEventArgs e)
		{
			new Storage().SaveHighScore(0);
			HighScore.Text = "0";
			ButtonPanel.Visibility = Visibility.Collapsed;
		}

		private void NoButton_OnClick(object sender, RoutedEventArgs e)
		{
			ButtonPanel.Visibility = Visibility.Collapsed;
		} 
```


### Prerequisites

It is a Universal Windows App, compatible with any desktop device running Windows 10. 

### Installing

It can be installed from the Windows Store [here](https://www.microsoft.com/store/apps/9N30D04KFWSD)

## Deployment

Universal Windows App that can be deployed in any Windows 10 desktop device.


## Built With

* [Visual Studio 2017](https://www.visualstudio.com/downloads/) - IDE

## Authors

* **Damian Gavin** - *This repo* - [DamianGavin](https://github.com/DamianGavin/UniversalWindowsProject/) 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Original idea: Simon. Biggest selling game at christmas in 1982. Launched in 1978.


