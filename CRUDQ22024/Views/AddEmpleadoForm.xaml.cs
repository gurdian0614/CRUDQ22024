using CRUDQ22024.Models;
using CRUDQ22024.ViewModels;

namespace CRUDQ22024.Views;

public partial class AddEmpleadoForm : ContentPage
{
	private AddEmpleadoFormViewModel viewModel;
	public AddEmpleadoForm()
	{
		InitializeComponent();
		viewModel = new AddEmpleadoFormViewModel();
		BindingContext = viewModel;
	}

	public AddEmpleadoForm(Empleado empleado)
	{
		InitializeComponent();
		viewModel = new AddEmpleadoFormViewModel(empleado);
		BindingContext = viewModel;
	}
}