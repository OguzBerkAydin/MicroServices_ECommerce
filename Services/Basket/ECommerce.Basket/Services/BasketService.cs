using ECommerce.Basket.Dtos;
using ECommerce.Basket.RedisSettings;
using System.Text.Json;

namespace ECommerce.Basket.Services
{
	public class BasketService : IBasketService
	{
		private readonly RedisService _redisService;
		public BasketService(RedisService redisService)
		{
			_redisService = redisService;
		}
		public async Task<BasketTotalDto> GetBasket(string userId)
		{
			var existBasket = await _redisService.GetDatabase().StringGetAsync(userId);
			if (existBasket.IsNullOrEmpty) return null;

			return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
		}
		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			
			var serializedBasket = JsonSerializer.Serialize(basketTotalDto);
			await _redisService.GetDatabase().StringSetAsync(basketTotalDto.UserId, serializedBasket);
		}
		public async Task DeleteBasket(string userId)
		{
			
			var existBasket = await _redisService.GetDatabase().StringGetAsync(userId);
			if (existBasket.IsNullOrEmpty) return;
			await _redisService.GetDatabase().KeyDeleteAsync(userId);
		}
	}
}
