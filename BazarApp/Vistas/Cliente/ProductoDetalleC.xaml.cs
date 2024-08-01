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
        await Navigation.PopAsync();
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
            precio.Text = _productos.Precio.ToString();
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