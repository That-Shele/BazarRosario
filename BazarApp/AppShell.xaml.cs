using BazarApp.Abstractions;

namespace BazarApp
{
    public partial class AppShell : Shell
    {
        ILista lista = DependencyService.Get<ILista>();
        public AppShell()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<App, string>(App.Current, "Cliente", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioV.IsVisible = false;
                    oferV.IsVisible = false;
                    stockV.IsVisible = false;
                    inicioC.IsVisible = true;
                    oferC.IsVisible = true;
                    listaC.IsVisible = true;
                    usuV.IsVisible = false;
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "Vendedor", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioC.IsVisible = false;
                    oferC.IsVisible = false;
                    listaC.IsVisible = false;
                    inicioV.IsVisible = true;
                    oferV.IsVisible = true;
                    stockV.IsVisible = true;
                    usuV.IsVisible = true;
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "Login", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioV.IsVisible = true;
                    oferC.IsVisible = true;
                    stockV.IsVisible = true;
                    inicioC.IsVisible = true;
                    oferV.IsVisible = true;
                    listaC.IsVisible = true;
                    usuV.IsVisible = true;
                    
                });
            });
        }

        private void FlyoutItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var listener = sender as FlyoutItem;
            if (listener.CurrentItem.Title == "Cerrar Sesión")
            {
                lista.Lista.Clear();
                MessagingCenter.Send<App, string>(App.Current as App, "Login", "");
            }
        }
    }
}
