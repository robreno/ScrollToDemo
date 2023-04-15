using ScrollToDemo.ViewModels;

namespace ScrollToDemo.Views;

public partial class Paper001 : ContentPage
{
	public Paper001(PaperViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		vm.contentPage = this;
	}
}