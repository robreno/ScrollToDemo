using ScrollToDemo.ViewModels;

namespace ScrollToDemo.Views;

public partial class Paper000 : ContentPage
{
	public Paper000(PaperViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		vm.contentPage = this;
	}

	public async void ScrollToLabel(string name)
	{
		Label targetLabel = this.FindByName(name) as Label;
		await contentScrollView.ScrollToAsync(targetLabel, ScrollToPosition.Start, false);
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		Label targetLabel = this.FindByName("RID_0_1_0") as Label;
		this.contentScrollView.ScrollToAsync(targetLabel, ScrollToPosition.Start, false);
    }
}