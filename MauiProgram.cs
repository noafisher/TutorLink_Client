﻿using Microsoft.Extensions.Logging;
using TutorLinkClient.Views;
using TutorLinkClient.ViewModels;
using TutorLinkClient.Services;
using System.Globalization;


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
                    fonts.AddFont("MarkaziText-VariableFont_wght.ttf", "MarkaziText-VariableFont_wght");
                    fonts.AddFont("SofadiOne-Regular.ttf", "SofadiOne-Regular");




                });

            
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ChatStudent>();
            builder.Services.AddTransient<ChatStudentViewModel>();
            builder.Services.AddTransient<ChatTeacher>();
            builder.Services.AddTransient<ChatTeacherViewModel>();
            builder.Services.AddTransient<Views.Calendar>();
            builder.Services.AddTransient<CalendarViewModel>();
            builder.Services.AddTransient<RateTeacher>();
            builder.Services.AddTransient<RateTeacherViewModel>();
            builder.Services.AddTransient<ReportUser>();
            builder.Services.AddTransient<ReportUserViewModel>(); 
            builder.Services.AddTransient<TeachersList>();
            builder.Services.AddTransient<TeachersListViewModel>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<AddLesson>();
            builder.Services.AddTransient<AddLessonViewModel>();
            builder.Services.AddTransient<ChatDetails>();
            builder.Services.AddTransient<ChatDetailsViewModel>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfilePageViewModel>(); 
            builder.Services.AddTransient<Admin>();
            builder.Services.AddTransient<AdminViewModel>();
            

            builder.Services.AddSingleton<TutorLinkWebAPIProxy>();
            builder.Services.AddSingleton<ChatProxy>();


#if DEBUG
            builder.Logging.AddDebug();
#endif
            AppContext.SetSwitch("System.Reflection.NullabilityInfoContext.IsSupported", true);

            return builder.Build();
        }
    }
}
