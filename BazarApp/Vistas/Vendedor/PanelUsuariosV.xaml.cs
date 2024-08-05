using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Vendedor;

public partial class PanelUsuariosV : ContentPage
{
    private readonly BazarClientService _clientService;
    public PanelUsuariosV(BazarClientService bazarClientService)
    {
        InitializeComponent();
        _clientService = bazarClientService;
    }

    private async void usuariosListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var usuario = (Usuarios)e.Item;
        var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Hacer/Quitar Admin");

        switch (acciones)
        {
            case "Hacer/Quitar Admin":
                if (usuario.IsAdmin == true)
                {
                    usuario.NombreUsu = usuario.NombreUsu;
                    usuario.Password = usuario.Password;
                    usuario.Email = usuario.Email;
                    usuario.IsAdmin = false;
                    await _clientService.EditUsuario(usuario.UsuId,usuario);
                    usuariosListView.ItemsSource = null;
                    usuariosListView.ItemsSource = await _clientService.GetUsuarios();
                }
                else
                {
                    usuario.NombreUsu = usuario.NombreUsu;
                    usuario.Password = usuario.Password;
                    usuario.Email = usuario.Email;
                    usuario.IsAdmin = true;
                    await _clientService.EditUsuario(usuario.UsuId, usuario);
                    usuariosListView.ItemsSource = null;
                    usuariosListView.ItemsSource = await _clientService.GetUsuarios();
                }
                break;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.usuariosListView.ItemsSource = null;
        this.usuariosListView.ItemsSource = await _clientService.GetUsuarios();
    }
}