using BazarLib;
using BazarLib.Models.ApiModels;
using System;

namespace BazarApp.Vistas.Vendedor;

public partial class InicioV : ContentPage
{
    private readonly BazarClientService _clientService;
    public InicioV(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
        
	}

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InsertarProductoV(_clientService, null));
    }


    private async void productListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var producto = (Productos)e.Item;
        var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Editar", "Eliminar");

        switch (acciones)
        {
            case "Editar":
                await Navigation.PushAsync(new InsertarProductoV(_clientService, producto));
                break;
            case "Eliminar":
                await _clientService.DeleteProducto(producto.ProduId);
                productListView.ItemsSource = await _clientService.GetProductos();
                break;
        }
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.productListView.ItemsSource = await _clientService.GetProductos();
    }
}