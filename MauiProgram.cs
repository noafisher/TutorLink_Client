using Microsoft.Extensions.Logging;
using TutorLinkClient.Views;
using TutorLinkClient.ViewModels;


namespace TutorLinkClient
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
                    fonts.AddFont("Kalam-Regular.ttf", "Kalam-Regular");
                    fonts.AddFont("miriwin-webfont.ttf", "miriwin-webfont");


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
