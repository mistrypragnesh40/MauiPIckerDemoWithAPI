using DropDownDemoWithAPI.ViewModels;

namespace DropDownDemoWithAPI.Views;

public partial class DropDownDetailPage : ContentPage
{
	public DropDownDetailPage(DropDownDetailPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}