using CommunityToolkit.Mvvm.ComponentModel;

namespace BazarApp.ViewModels;

public partial class InsertarProductoViewModel : ObservableObject
{
    [ObservableProperty]
    private string _categoria;
    [ObservableProperty]
    private string _tipoprodu;
    [ObservableProperty]
    private string _nombreprodu;
    [ObservableProperty]
    private decimal _precio;
    [ObservableProperty]
    private int _stock;
    [ObservableProperty]
    private byte _imgprodu;
    [ObservableProperty]
    private bool _isoferta;
}
