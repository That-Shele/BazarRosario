using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Vendedor;

public partial class OfertasV : ContentPage
{
    private readonly BazarClientService _clientService;
    public OfertasV(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
    }


    private async void productListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var producto = (Productos)e.Item;
        var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Editar");

        switch (acciones)
        {
            case "Editar":
                await Navigation.PushAsync(new InsertarProductoV(_clientService, producto));
                break;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.ofertasListView.ItemsSource = await _clientService.GetOfertas();
    }
}