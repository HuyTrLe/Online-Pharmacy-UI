using pj3_ui.Models;
using pj3_ui.Service.Career;
using pj3_ui.Service.Home;

namespace pj3_ui
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCustomDependencies(services, configuration);

            return services;
        }

        private static void RegisterCustomDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var _appSettings = new AppSetting();
            configuration.GetSection("AppSettings").Bind(_appSettings);

            services.AddSingleton(typeof(AppSetting), _appSettings);
            services.AddSingleton<IHomeService, HomeService>();
            services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IFeedbackService, FeedbackService>();
            services.AddSingleton<ICareerService, CareerService>();
        }
	}
}
