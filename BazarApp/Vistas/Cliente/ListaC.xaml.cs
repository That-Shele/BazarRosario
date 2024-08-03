using BazarApp.Abstractions;
using BazarLib;
using BazarLib.Models.ApiModels;
using System.Security.AccessControl;

namespace BazarApp.Vistas.Cliente;

public partial class ListaC : ContentPage
{
	private readonly BazarClientService _clientService;
    ILista lista = DependencyService.Get<ILista>();
    public decimal total { get; set; } = 0;
	public ListaC(BazarClientService bazarClientService)
	{
		InitializeComponent();
        _clientService = bazarClientService;
    }

    private async void facturaListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		if (facturaListView.ItemsSource == lista.Lista)
		{
            var productoFac = (Lista)e.Item;
            var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Eliminar");

            switch (acciones)
            {
                case "Eliminar":
                    total = total - productoFac.Pago;
                    lista.Lista.Remove(productoFac);
                    facturaListView.ItemsSource = null;
                    facturaListView.ItemsSource = lista.Lista;
                    break;
            }
        }
        else
        {
            try
            {
                var factura = (Facturas)e.Item;
                LoadFacturasDetalle(factura.CodFac);
            }
            catch
            {
                await DisplayAlert("Error", "No hay más datos que mostrar", "Ok");
            }
        }
    }

    private void btnLista_Clicked(object sender, EventArgs e)
    {
        LoadListaCompra();
    }

    private void btnFacturas_Clicked(object sender, EventArgs e)
    {
        LoadFacturas();
    }


    public void LoadListaCompra()
    {
        this.facturaListView.ItemsSource = lista.Lista;
    }

    public async void LoadFacturas()
    {
        var facturas = await _clientService.GetFacturasUsu(App.usuarios.NombreUsu);
        this.facturaListView.ItemsSource = facturas;
    }

    public async void LoadFacturasDetalle(int id)
    {
        var facdet = await _clientService.GetDetalleFacturasId(id);
        this.facturaListView.ItemsSource = facdet;
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (lista.Lista != null)
        {
            var fecha = DateTime.Now;
            CalcularPago();
            await _clientService.AddFactura(new Facturas
            {
                NombreUsu = App.usuarios.NombreUsu,
                Pago = total,
                Fecha = fecha
            });

            var fac = await _clientService.GetFacturasCod(fecha);

            foreach (var prod in lista.Lista)
            {
                await _clientService.AddDetalleFactura(new FacturasDetalle
                {
                    CodFac = fac.CodFac,
                    NombreUsu = prod.NombreUsu,
                    NombreProdu = prod.NombreProdu,
                    Cantidad = prod.Cantidad,
                    Pago = prod.Pago
                });

                var producto = await _clientService.GetProductoById(prod.ProduId);
                producto.Stock = producto.Stock - prod.Cantidad;
                await _clientService.EditProducto(producto);
            }

            lista.Lista.Clear();
            facturaListView.ItemsSource = null;
            await DisplayAlert("Exito!", "Su compra ha sido realizada", "Ok");
        }
        else
        {
           await DisplayAlert("Error", "No se ha añadido ningún producto al carrito", "Ok");
        }
    }

    public void CalcularPago()
    {
        foreach (var prod in lista.Lista)
        {
            total += prod.Pago;
        }
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        this.facturaListView.ItemsSource = null;
    }
}