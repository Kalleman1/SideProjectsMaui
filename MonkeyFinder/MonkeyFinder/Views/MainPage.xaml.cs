using MonkeyFinder.ViewModels;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{

	public MainPage(MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
		BindingContext = monkeysViewModel;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		
	}
}

