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
                //to open ssh tunnel, run this line on terminal> ssh -i "C:\path\to\group3sad.pem" -L 3307:localhost:3306 ubuntu@ec2-54-87-40-9.compute-1.amazonaws.com
                string connectionString = "Server=127.0.0.1;Port=3307;Database=RMS;User=group3;Password=$4DpA$sg4p3;";
                return new DatabaseService(connectionString);
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
