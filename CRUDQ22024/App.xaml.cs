using CRUDQ22024.Views;

namespace CRUDQ22024
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EmpleadoMain());
        }
    }
}
