
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDQ22024.Models;
using CRUDQ22024.Services;

namespace CRUDQ22024.ViewModels
{
    public partial class AddEmpleadoFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int idProperty;

        [ObservableProperty]
        private string nombreProperty;

        [ObservableProperty]
        private string emailProperty;

        [ObservableProperty]
        private string direccionProperty;

        private readonly EmpleadoService empleadoService;

        /// <summary>
        /// Constructor que se utiliza al momento de crear un nuevo regitro de empleado
        /// </summary>
        public AddEmpleadoFormViewModel()
        {
            empleadoService = new EmpleadoService();
        }

        /// <summary>
        /// Constructor que se utiliza al momento de editar un regitro de empleado
        /// </summary>
        public AddEmpleadoFormViewModel(Empleado empleado)
        {
            IdProperty = empleado.Id;
            NombreProperty = empleado.Nombre;
            EmailProperty = empleado.Email;
            DireccionProperty = empleado.Direccion;
            empleadoService = new EmpleadoService();
        }

        /// <summary>
        /// Muestra un mensaje de alerta personalizado
        /// </summary>
        /// <param name="Titulo">Titulo de la alerta, por ejemplo, ERROR, ADVERTENCIA, etc</param>
        /// <param name="Mensaje">Mensaje a mostrar en la alerta</param>
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Empleado empleado = new Empleado
                {
                    Id = IdProperty,
                    Nombre = NombreProperty,
                    Email = EmailProperty,
                    Direccion = DireccionProperty
                };

                if (Validar(empleado))
                {
                    if (IdProperty == 0)
                    {
                        empleadoService.Insert(empleado);
                    }
                    else
                    {
                        empleadoService.Update(empleado);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            } catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Empleado empleado)
        {
            if (empleado.Nombre == null || empleado.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre completo");
                return false;
            } else if(empleado.Email == null || empleado.Email == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el correo electrónico");
                return false;
            } else
            {
                return true;
            }
        }
    }
}
