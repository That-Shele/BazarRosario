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

    private async void btnShowProducts_Clicked(object sender, EventArgs e)
    {
       await CargarProductos();
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
                await CargarProductos();
                break;
        }
    }

    private async Task CargarProductos()
    {
        var lista = await _clientService.GetProductos();
        productListView.ItemsSource = lista;
    }
}