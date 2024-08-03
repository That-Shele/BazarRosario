using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas;

public partial class SignIn : ContentPage
{
    private readonly BazarClientService _clientService;
    public SignIn(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
    }

    private async void crear_Clicked(object sender, EventArgs e)
    {
        if (eMail.Text != null && eName.Text != null && ePass.Text != null)
        {
            await _clientService.AddUsuario(new Usuarios
            {
                NombreUsu = eMail.Text,
                Email = eMail.Text,
                Password = ePass.Text,
                IsAdmin = false
            });
            await Navigation.PopAsync();
        }
        else
        {
           await DisplayAlert("Error", "Ingrese todos los datos", "Ok");
        }
    }
}