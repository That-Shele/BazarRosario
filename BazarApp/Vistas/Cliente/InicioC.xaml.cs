using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Cliente;

public partial class InicioC : ContentPage
{
    private readonly BazarClientService _clientService;
    public InicioC(BazarClientService clientService)
	{
		InitializeComponent();
		_clientService = clientService;
	}

    private async void productListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var producto = (Productos)e.Item;
        var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Ver");

        switch (acciones)
        {
            case "Ver":
                await Navigation.PushAsync(new ProductoDetalleC(_clientService, producto));
                break;
        }
    }

    private async void btnShowProducts_Clicked(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    private async Task CargarProductos()
    {
        var lista = await _clientService.GetProductos();
        productListView.ItemsSource = lista;
    }

}