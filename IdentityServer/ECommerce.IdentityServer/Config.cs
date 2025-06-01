using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace ECommerce.IdentityServer;

public static class Config
{
	public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
	{
		new ApiResource("ResourceCatalog")
		{
			Scopes = { "CatalogFullPermission" }
		},
		new ApiResource("ResourceDiscount")
		{
			Scopes = { "DiscountFullPermission" }
		},
		new ApiResource("ResourceOrder")
		{
			Scopes = { "OrderFullPermission" }
		},
		new ApiResource("ResourceCargo")
		{
			Scopes = { "CargoFullPermission" }
		},
		new ApiResource("ResourceBasket")
		{
			Scopes = { "BasketFullPermission" }
		},
		new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
		
	};

	public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
	{
		new IdentityResources.OpenId(),
		new IdentityResources.Profile(),
		new IdentityResources.Email(),
	};

	public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
	{
		new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
		new ApiScope("DiscountFullPermission","Full authority for Discount operations"),
		new ApiScope("OrderFullPermission","Full authority for Order operations"),
		new ApiScope("CargoFullPermission","Full authority for Cargo operations"),
		new ApiScope("BasketFullPermission","Full authority for Basket operations"),
		new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
	};

	public static IEnumerable<Client> Clients => new Client[]
	{
		//Manager
		new Client
		{
			ClientId = "ECommerceManagerId",
			ClientName = "ECommerce Manager User",
			AllowedGrantTypes = GrantTypes.ClientCredentials,
			ClientSecrets = {new Secret("ecommercesecret".Sha256())},
			AllowedScopes = {"CatalogFullPermission"}
		},
		new Client
		{
			ClientId = "ECommerceVisitorId",
			ClientName = "ECommerce Visitor User",
			AllowedGrantTypes = GrantTypes.ClientCredentials,
			ClientSecrets = {new Secret("ecommercesecret".Sha256())},
			AllowedScopes = { "DiscountFullPermission" }
		},
		//Admin
		new Client
		{
			ClientId = "ECommerceAdminId",
			ClientName = "ECommerce Admin User",
			AllowedGrantTypes = GrantTypes.ClientCredentials,
			ClientSecrets = {new Secret("ecommercesecret".Sha256())},
			AllowedScopes = {
				"CatalogFullPermission",
				"DiscountFullPermission",
				"OrderFullPermission",
				"CargoFullPermission",
				"BasketFullPermission",
				IdentityServerConstants.LocalApi.ScopeName,
				IdentityServerConstants.StandardScopes.Email,
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
			},
			AccessTokenLifetime = 600

		}
	};
}
