using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindowsProject.Model_simon
{
    class Storage
    {

	    public void SaveHighScore(int score)
	    {
		    Windows.Storage.ApplicationData.Current.LocalSettings.Values["highScore"] = score;

	    }

	    public int GetHighScore()
	    {
		    var value = Windows.Storage.ApplicationData.Current.LocalSettings.Values["highScore"];

			if (value == null) // there is no high score saved at all
			{
				return -1;
			}

		   return (int) value;
		}
    }
}
