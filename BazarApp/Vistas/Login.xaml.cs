namespace BazarApp.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        
    }

    private async void cli_Clicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<App, string>(App.Current as App, "Cliente", "");
        await Shell.Current.GoToAsync("//InicioC");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
    }

    private async void ven_Clicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<App, string>(App.Current as App, "Vendedor", "");
        await Shell.Current.GoToAsync("//InicioV");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
    }
}