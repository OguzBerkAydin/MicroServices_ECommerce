using ECommerce.Catalog.Services.BrandServices;
using ECommerce.Catalog.Services.CategoryServices;
using ECommerce.Catalog.Services.FeatureServices;
using ECommerce.Catalog.Services.FeatureSliderServices;
using ECommerce.Catalog.Services.OfferDiscountServices;
using ECommerce.Catalog.Services.ProductDetailServices;
using ECommerce.Catalog.Services.ProductImageServices;
using ECommerce.Catalog.Services.ProductServices;
using ECommerce.Catalog.Services.SpecialOfferServices;
using ECommerce.Catalog.Services.AboutServices;
using ECommerce.Catalog.Settings;
using Microsoft.AspNetCore.Components.Forms;
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
			services.AddScoped<IFeatureService, FeatureService>();
			services.AddScoped<IOfferDiscountService, OfferDiscountService>();
			services.AddScoped<IBrandService, BrandService>();
			services.AddScoped<IAboutService, AboutService>();

			return services;
		}
	}
}
