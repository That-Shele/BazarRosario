﻿using Microsoft.Extensions.Logging;
using BazarLib.IoC;
using BazarApp.Vistas.Vendedor;
using BazarApp.Vistas.Cliente;

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
                });
            builder.Services.AddBazarApiClient(x => x.ApiBaseAddress = "https://localhost:7254/");
            builder.Services.AddTransient<InicioV>();
            builder.Services.AddTransient<InicioC>();
            builder.Services.AddTransient<StockV>();
            builder.Services.AddTransient<ProductoDetalleC>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
