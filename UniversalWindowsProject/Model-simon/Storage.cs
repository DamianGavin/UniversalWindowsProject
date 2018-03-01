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
		   return (int) Windows.Storage.ApplicationData.Current.LocalSettings.Values["highScore"];
		}
    }
}
