using BazarLib;

namespace BazarApp.Vistas.Vendedor;

public partial class StockV : ContentPage
{
    private readonly BazarClientService? _clientService;
    public StockV(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;

    }

    private async void btnShowProducts_Clicked(object sender, EventArgs e)
    {
        await CargarProductos();
    }
    private async Task CargarProductos()
    {
        var lista = await _clientService.GetProductos();
        stockListView.ItemsSource = lista;
    }

}