using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ECommerce.Catalog.Extensions
{
	public static class AuthenticationExtensions
	{
		public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			{
				opt.Authority = configuration["IdentityServerUrl"];
				opt.Audience = "ResourceCatalog";
				opt.RequireHttpsMetadata = false;
			});
			return services;
		}
	}
}
