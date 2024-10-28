using Microsoft.Extensions.Logging;
using TutorLink_Client.Views;
using TutorLink_Client.ViewModels;

namespace TutorLink_Client
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

            //login
            builder.Services.AddSingleton<Login>();
            builder.Services.AddSingleton<LoginViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
