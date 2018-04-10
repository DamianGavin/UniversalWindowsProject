
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

The Quadrant.cs is to represent one of the 4 circles that the user can click. It consists of 
an Ellipse filled with a colour and a Sound.

Simon.cs is where simon gets created with a list of quadrants and an empty history. I have methods 
called 

Storage.cs
This is a where I implement local storage by initially wiping it and then assigning "highScore"
to LocalSettings.Values.
``
public void SaveHighScore(int score)
		{
			ApplicationData.Current.LocalSettings.Values["highScore"] = score;
		}``


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


