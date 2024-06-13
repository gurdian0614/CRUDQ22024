
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDQ22024.Models;
using CRUDQ22024.Services;
using CRUDQ22024.Views;
using System.Collections.ObjectModel;

namespace CRUDQ22024.ViewModels
{
    public partial class EmpleadoMainViewModel : ObservableObject
    {
        // Coleccion de datos para interactuar con la vista
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection = new ObservableCollection<Empleado>();

        // Llamamos a la clase en donde configuramos la base de datos
        private readonly EmpleadoService empleadoService;

        // Constructor
        public EmpleadoMainViewModel()
        {
            empleadoService = new EmpleadoService();
        }

        /// <summary>
        /// Muestra el listado de empleados
        /// </summary>
        public void GetAll()
        {
            var getAll = empleadoService.GetAll();

            // Valido si la lista contiene registros
            if (getAll?.Count() > 0)
            {
                EmpleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    EmpleadoCollection.Add(empleado);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la vista de agregar empleado
        /// </summary>
        /// <returns>Vista de agregar empleado</returns>
        [RelayCommand]
        private async Task goToAddEmpleadoForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEmpleadoForm());
        }

        /// <summary>
        /// Muestra las opciones al seleccionar un registro de empleado
        /// </summary>
        /// <param name="empleado">Objeto seleccionado para actualizar o eliminar</param>
        /// <returns></returns>
        [RelayCommand]
        private async Task SelectEmpleado(Empleado empleado)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddEmpleadoForm(empleado));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR EMPLEADO", "¿Desea eliminar el registro de empleado?", "Si", "No");

                        if (respuesta)
                        {
                            int del = empleadoService.Delete(empleado);

                            if (del > 0)
                            {
                                EmpleadoCollection.Remove(empleado);
                            }
                        }
                        break;
                }
            } catch(Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
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
    }
}
