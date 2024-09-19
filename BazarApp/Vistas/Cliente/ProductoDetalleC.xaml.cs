using BazarApp.Abstractions;
using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Cliente;

public partial class ProductoDetalleC : ContentPage
{

    private readonly BazarClientService _clientService;
    private Productos _productos;
    private byte[]? bits;
    public ProductoDetalleC(BazarClientService bazarClientService, Productos productos)
	{
        InitializeComponent();
        _clientService = bazarClientService;
        _productos = productos;
        CargarProductoDetalle();
    }
    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_productos != null && eCantidad.Text != null && Convert.ToInt32(eCantidad.Text) <= _productos.Stock )
        {
            try
            {
                ILista lista = DependencyService.Get<ILista>();
                lista.Lista.Add(new Lista
                {
                    ProduId = _productos.ProduId,
                    NombreProdu = nombre.Text,
                    NombreUsu = App.usuarios.NombreUsu,
                    Pago = Convert.ToDecimal(precio.Text) * Convert.ToInt32(eCantidad.Text),
                    Cantidad = Convert.ToInt32(eCantidad.Text)
                });
                ListaC lc = new ListaC(_clientService);
                lc.total += Convert.ToDecimal(precio.Text) * Convert.ToInt32(eCantidad.Text);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
              await DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
        else
        {
            await DisplayAlert("Error", "Datos incorrectos/Stock insuficiente", "Ok");
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void CargarProductoDetalle()
    {
        if (_productos is not null)
        {
            nombre.Text = _productos.NombreProdu;
            categoria.Text = _productos.Categoria;
            tipo.Text = _productos.TipoProdu;
            precio.Text =  _productos.Precio.ToString();
            bits = _productos.ImgProdu;
            Stream img = ConvertByteArrayToStream(bits);
            imgDisplay.Source = ImageSource.FromStream(() => img);
        }
    }

    public Stream ConvertByteArrayToStream(byte[] byteArray)
    {
        return new MemoryStream(byteArray);
    }
}