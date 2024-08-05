using BazarLib;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace BazarApp.Vistas;

public partial class Login : ContentPage
{
    BazarClientService _clientService;
	public Login(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
    }

    private async void Log_Clicked(object sender, EventArgs e)
    {
        if (eMail.Text != null && ePass.Text != null)
        {
            try
            {
                var a = eMail.Text;
                var b = ePass.Text;
                var lista = await _clientService.ValidateUsuario(a, b);
                
                    string detalleUsu = JsonConvert.SerializeObject(lista);
                    Preferences.Set(nameof(App.usuarios), detalleUsu);
                    App.usuarios = lista;
                    if (lista.IsAdmin == true)
                    {
                        MessagingCenter.Send<App, string>(App.Current as App, "Vendedor", "");
                        await Shell.Current.GoToAsync("//InicioV");
                        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                    }
                    else if (lista.IsAdmin == false)
                    {
                        MessagingCenter.Send<App, string>(App.Current as App, "Cliente", "");
                        await Shell.Current.GoToAsync("//InicioC");
                        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                    }
               
            }
            catch
            {
                await DisplayAlert("Error", "El usuario ingresado no existe", "Ok");
            }            
        }
        else
        {
            await DisplayAlert("Error", "Ingrese todos los datos", "Ok");
        }
    }

    private void SignUp_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignIn(_clientService));
    }
}