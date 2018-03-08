using System;
using Windows.Storage;

namespace UniversalWindowsProject
{
	internal class Storage
	{
		public async void Clear()
		{
			// wipe local storage
			await ApplicationData.Current.ClearAsync();
		}

		public void SaveHighScore(int score)
		{
			ApplicationData.Current.LocalSettings.Values["highScore"] = score;
		}

		public int GetHighScore()
		{
			var value = ApplicationData.Current.LocalSettings.Values["highScore"];

			if (value == null) // there is no high score saved at all
				return -1;

			return (int) value;
		}
	}
}