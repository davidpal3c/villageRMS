using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using VillageRMS.Services;
using VillageRMS.Settings;

namespace VillageRMS
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
                });

            // register svc for DI
            builder.Services.AddTransient<DatabaseService>(provider =>
            {

                //string connectionString = "Server=;Port=;Database=;User=;Password=;";
                //string connectionString = $"Server={SystemSettings.DBUrl};Port={SystemSettings.DBPort};Database={SystemSettings.db};User={SystemSettings.dbusername};Password={SystemSettings.dbpassword};";

                //return new DatabaseService(connectionString);
                return new DatabaseService();
            });

            builder.Services.AddMauiBlazorWebView();
            //glc
            builder.Services.AddBlazorBootstrap();
            //register login glc
            builder.Services.AddSingleton<LoginStateService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
