using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

using DevExpress.Maui.CollectionView;
using Syncfusion.Maui.Toolkit.Hosting;
namespace Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .UseDevExpressCollectionView()
           
            .ConfigureSyncfusionCore().ConfigureSyncfusionToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

//#if DEBUG
//    		builder.Logging.AddDebug();
//#endif

            return builder.Build();
        }
    }
}
