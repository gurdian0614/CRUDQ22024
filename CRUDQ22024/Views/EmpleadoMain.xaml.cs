using CRUDQ22024.ViewModels;

namespace CRUDQ22024.Views;

public partial class EmpleadoMain : ContentPage
{
	private EmpleadoMainViewModel viewModel;
	public EmpleadoMain()
	{
		InitializeComponent();
		viewModel = new EmpleadoMainViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}