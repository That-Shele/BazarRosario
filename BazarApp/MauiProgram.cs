using Microsoft.Extensions.Logging;
using BazarLib.IoC;
using BazarApp.Vistas.Vendedor;
using BazarApp.Vistas.Cliente;
using BazarApp.Vistas;

namespace BazarApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    //NUEVAS FUENTES
                    fonts.AddFont("Hatfielin.otf", "Hatfielin");
                    fonts.AddFont("Novita Signora.otf", "Novita");
                });
            builder.Services.AddBazarApiClient(x => x.ApiBaseAddress = "https://localhost:7254/");
            builder.Services.AddTransient<InicioV>();
            builder.Services.AddTransient<InicioC>();
            builder.Services.AddTransient<OfertasC>();
            builder.Services.AddTransient<OfertasV>();
            builder.Services.AddTransient<StockV>();
            builder.Services.AddTransient<ProductoDetalleC>();
            builder.Services.AddTransient<PanelUsuariosV>();
            builder.Services.AddScoped<ListaC>();
            builder.Services.AddTransient<Login>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
