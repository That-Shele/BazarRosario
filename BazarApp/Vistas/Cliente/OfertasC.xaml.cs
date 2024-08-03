using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Cliente;

public partial class OfertasC : ContentPage
{
    private readonly BazarClientService _clientService;
    public OfertasC(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
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

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.ofertasListView.ItemsSource = await _clientService.GetOfertas();
    }
}