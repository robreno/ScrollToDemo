using ScrollToDemo.ViewModels;

namespace ScrollToDemo;
public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}

