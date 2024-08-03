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

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.stockListView.ItemsSource = await _clientService.GetProductos();
    }

}