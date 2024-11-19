using Microsoft.Extensions.Logging;
using TutorLinkClient.Views;
using TutorLinkClient.ViewModels;
using TutorLinkClient.Services;


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
                    fonts.AddFont("Overlock-Regular.ttf", "Overlock-Regular");



                });

            //login
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<RegisterViewModel>();

            builder.Services.AddSingleton<TutorLinkWebAPIProxy>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
