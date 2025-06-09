using ECommerce.Catalog.Services.CategoryServices;
using ECommerce.Catalog.Services.FeatureSliderServices;
using ECommerce.Catalog.Services.ProductDetailServices;
using ECommerce.Catalog.Services.ProductImageServices;
using ECommerce.Catalog.Services.ProductServices;
using ECommerce.Catalog.Services.SpecialOfferServices;
using ECommerce.Catalog.Settings;
using Microsoft.Extensions.Options;

namespace ECommerce.Catalog.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
			services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductDetailService, ProductDetailService>();
			services.AddScoped<IProductImageService, ProductImageService>();
			services.AddScoped<IFeatureSliderService, FeatureSliderService>();
			services.AddScoped<ISpecialOfferService, SpecialOfferService>();

			return services;
		}
	}
}
