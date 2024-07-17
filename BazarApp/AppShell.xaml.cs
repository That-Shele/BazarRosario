namespace BazarApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<App, string>(App.Current, "Cliente", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioV.IsVisible = false;
                    cateV.IsVisible = false;
                    stockV.IsVisible = false;
                    inicioC.IsVisible = true;
                    cateC.IsVisible = true;
                    listaC.IsVisible = true;
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "Vendedor", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioC.IsVisible = false;
                    cateC.IsVisible = false;
                    listaC.IsVisible = false;
                    inicioV.IsVisible = true;
                    cateV.IsVisible = true;
                    stockV.IsVisible = true;
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "Login", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    //Navigation.PushAsync(new NavigationPage(new DetailsInfo(arg)));  

                    inicioV.IsVisible = true;
                    cateV.IsVisible = true;
                    stockV.IsVisible = true;
                    inicioC.IsVisible = true;
                    cateC.IsVisible = true;
                    listaC.IsVisible = true;
                });
            });
        }

        private void FlyoutItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var listener = sender as FlyoutItem;
            if (listener.CurrentItem.Title == "Cerrar Sesión")
            {
                MessagingCenter.Send<App, string>(App.Current as App, "Login", "");
            }
        }
    }
}
