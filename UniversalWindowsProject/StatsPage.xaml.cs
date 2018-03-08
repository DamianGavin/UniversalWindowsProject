using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalWindowsProject
{
	/// <summary>
	///     An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class StatsPage : Page
	{
		public StatsPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			HighScore.Text = new Storage().GetHighScore().ToString();
		}

		private void NavigateToMainPage(object sender, RoutedEventArgs e)
		{
			// navigate to the main app page.
			Frame.Navigate(typeof(MainPage));
		}

		private void ResetButton_OnClick(object sender, RoutedEventArgs e)
		{
			return;
		}
	}
}