using ScrollToDemo.Views;

namespace ScrollToDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Paper000), typeof(Paper000));
	}
}
