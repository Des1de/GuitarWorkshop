using GuitarWorkshopUI.Interfaces;
using GuitarWorkshopUI.Services;

namespace GuitarWorkshopUI.Extensions
{
    public static class ServiceExtention
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddScoped<IBodyShapeService, BodyShapeService>()
                .AddScoped<IFinishesService, FinishesService>()
                .AddScoped<IFretNumberTypeService, FretNumberTypeService>()
                .AddScoped<IGuitarBuildService, GuitarBuildService>()
                .AddScoped<IGuitarColorService, GuitarColorService>()
                .AddScoped<IHeadstockStyleService, HeadstockStyleService>()
                .AddScoped<INeckScaleService, NeckScaleService>()
                .AddScoped<INeckShapeService, NeckShapeService>()
                .AddScoped<IStringTypeService, StringTypeService>()
                .AddScoped<ITuningMachineService, TuningMachineService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IWoodsTypeService, WoodsTypeService>();
        }
    }
}
