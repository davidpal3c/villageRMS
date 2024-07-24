using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using VillageRMS.Services;

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
                //open ssh to cloud server via terminal and port forward 3306 to local 3307 (will need an ssh tunnel terminal) or connect use own connection
                string connectionString = "Server=127.0.0.1;Port=3307;Database=RMS;User=group3;Password=$4DpA$sg4p3;";
                return new DatabaseService(connectionString);
            });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
