namespace ECommerce.Catalog.Extensions
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
		{
			services.AddOpenApi();
			services.AddSwaggerGen();
			return services;
		}
	}
}
