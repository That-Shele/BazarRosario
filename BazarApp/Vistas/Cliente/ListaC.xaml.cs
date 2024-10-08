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

    private async void listaListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (listaListView.ItemsSource == lista.Lista)
        {
            var productoFac = (Lista)e.Item;
            var acciones = await DisplayActionSheet("Acciones", "Cancelar", null, "Eliminar");

            switch (acciones)
            {
                case "Eliminar":
                    total = total - productoFac.Pago;
                    lista.Lista.Remove(productoFac);
                    listaListView.ItemsSource = null;
                    listaListView.ItemsSource = lista.Lista;
                    break;
            }
        }
        else
        {
            await DisplayAlert("Error", "No hay m�s datos que mostrar", "Ok");
        }
            
    }

    private void btnLista_Clicked(object sender, EventArgs e)
    {
        this.listaListView.IsVisible = true;
        this.facturasListView.IsVisible = false;
        this.facturasListView.ItemsSource = null;
        LoadListaCompra();
    }

    private void btnFacturas_Clicked(object sender, EventArgs e)
    {
        this.facturasListView.IsVisible = true;
        this.listaListView.IsVisible = false;
        this.listaListView.ItemsSource = null;
        LoadFacturas();
    }


    public void LoadListaCompra()
    {
        this.listaListView.ItemsSource = null;
        this.listaListView.ItemsSource = lista.Lista;
        
    }

    public async void LoadFacturas()
    {
        var facturas = await _clientService.GetFacturasUsu(App.usuarios.NombreUsu);
        this.facturasListView.ItemsSource = facturas;
        
    }

    public async void LoadFacturasDetalle(int id)
    {
        var facdet = await _clientService.GetDetalleFacturasId(id);
        this.listaListView.ItemsSource = facdet;
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (lista.Lista.Count() > 0)
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
            listaListView.ItemsSource = null;
            total = 0;
            await DisplayAlert("Exito!", "Su compra ha sido realizada", "Ok");
        }
        else
        {
           await DisplayAlert("Error", "No se ha a�adido ning�n producto al carrito", "Ok");
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
        this.listaListView.ItemsSource = null;
        this.facturasListView.ItemsSource = null;
    }

    private async void facturasListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        try
        {
            var factura = (Facturas)e.Item;
            LoadFacturasDetalle(factura.CodFac);
            this.listaListView.IsVisible = true;
            this.facturasListView.IsVisible = false;
            this.facturasListView.ItemsSource = null;

        }
        catch
        {
            await DisplayAlert("Error", "No hay m�s datos que mostrar", "Ok");
        }
    }
}