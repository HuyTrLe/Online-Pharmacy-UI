using pj3_ui.Models;
using pj3_ui.Service.Category;
using pj3_ui.Service.Career;
using pj3_ui.Service.Home;
using pj3_ui.Service.Product;
using pj3_ui.Service.ProductImage;
using pj3_ui.Service.Specification;

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
			services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductImageService, ProductImageService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ISpecificationService, SpecificationService>();
            services.AddSingleton<IProductSpecificationService, ProductSpecificationService>();
        }
    }
            services.AddSingleton<ICareerService, CareerService>();
        }
	}
}
