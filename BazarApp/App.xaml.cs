using BazarApp.Abstractions;
using BazarLib.Models.ApiModels;

namespace BazarApp
{
    public partial class App : Application
    {
        public static Usuarios usuarios;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ILista, ListaImp>();

            MainPage = new AppShell();
        }
    }
}
