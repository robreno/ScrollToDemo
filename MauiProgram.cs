using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ScrollToDemo.ViewModels;
using ScrollToDemo.Views;

namespace ScrollToDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
                // CaslonPro Main Font
                fonts.AddFont("ACaslonPro-Regular.otf", "ACaslonProRegular");
                fonts.AddFont("ACaslonPro-Italic.otf", "ACaslonProItalic");
                fonts.AddFont("ACaslonPro-Bold.otf", "ACaslonProBold");
                fonts.AddFont("ACaslonPro-BoldItalic.otf", "ACaslonProBoldItalic");
                fonts.AddFont("ACaslonPro-Semibold.otf", "ACaslonProSemibold");
                fonts.AddFont("ACaslonPro-SemiboldItalic.otf", "ACaslonProSemiboldItalic");
                // Sabon Alt Font
                fonts.AddFont("SabonLTD-Roman.otf", "SabonLTDRoman");
                fonts.AddFont("SabonLTStd-Bold.otf", "SabonLTStdBold");
                fonts.AddFont("SabonLTStd-Italic.otf", "SabonLTStdItalic");
                fonts.AddFont("SabonLTStd-BoldItalic.otf", "SabonLTStdBoldItalic");
                // Optima and OldStyle Special Use
                fonts.AddFont("OptimaLTStd.otf", "OptimaLTStd");
                fonts.AddFont("OldStyle7Std.otf", "OldStyle7Std");
                fonts.AddFont("OldStyle7Std-Italic.otf", "OldStyle7StdItalic");
                // OpenSans Default Project Font
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

		builder.Services.AddTransient<PaperViewModel>();
		builder.Services.AddTransient<Paper000>();
        builder.Services.AddTransient<Paper001>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
