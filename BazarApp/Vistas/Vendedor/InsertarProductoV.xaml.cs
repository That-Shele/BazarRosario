using BazarLib;
using BazarLib.Models.ApiModels;

namespace BazarApp.Vistas.Vendedor;

public partial class InsertarProductoV : ContentPage
{
    private readonly BazarClientService _clientService;
    private Productos _productos;
    private byte[]? bits;
	public InsertarProductoV(BazarClientService bazarClientService, Productos productos)
	{
		InitializeComponent();
        _clientService = bazarClientService;
        _productos = productos;
        CargarProductoDetalle();

    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_productos is null && bits is not null)
        {
            await _clientService.AddProducto(new Productos
            {
                NombreProdu = nombreProdu.Text,
                Categoria = cateProdu.SelectedItem.ToString(),
                TipoProdu = tipoProdu.Text,
                Precio = Convert.ToDecimal(precioProdu.Text),
                Stock = Convert.ToInt32(stockProdu.Text),
                ImgProdu = bits,
                IsOferta = esOferta.IsToggled
            });
        }
        else
        {
            await _clientService.EditProducto(new Productos
            {
                ProduId = _productos.ProduId,
                NombreProdu = nombreProdu.Text,
                Categoria = cateProdu.SelectedItem.ToString(),
                TipoProdu = tipoProdu.Text,
                Precio = Convert.ToDecimal(precioProdu.Text),
                Stock = Convert.ToInt32(stockProdu.Text),
                ImgProdu = bits,
                IsOferta = esOferta.IsToggled
            });
        }
        await Navigation.PopAsync();
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void buscaImg_Clicked(object sender, EventArgs e)
    {
        var resultado = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Seleccione una imágen",
            FileTypes = FilePickerFileType.Images
        });

        if (resultado is null)
        {
            return;
        }

        var stream = await resultado.OpenReadAsync();
        bits = GuardaImg(stream);
        Stream img = ConvertByteArrayToStream(bits);
        imgDisplay.Source = ImageSource.FromStream(() => img);
    }

    private void CargarProductoDetalle()
    {
        if (_productos is not null)
        {
            nombreProdu.Text = _productos.NombreProdu;
            cateProdu.SelectedItem = _productos.Categoria;
            tipoProdu.Text = _productos.TipoProdu;
            precioProdu.Text = _productos.Precio.ToString();
            stockProdu.Text = _productos.Stock.ToString();
            esOferta.IsToggled = _productos.IsOferta;
            bits = _productos.ImgProdu;
            Stream img = ConvertByteArrayToStream(bits);
            imgDisplay.Source = ImageSource.FromStream(() => img);
        }
    }


    public byte[] GuardaImg(Stream stream)
    {
        byte[] bytes;

        using (var binaryReader = new BinaryReader(stream))
        {
            bytes = binaryReader.ReadBytes((int)stream.Length);
        }

        return bytes;
    }

    public Stream ConvertByteArrayToStream(byte[] byteArray)
    {
        return new MemoryStream(byteArray);
    }

}