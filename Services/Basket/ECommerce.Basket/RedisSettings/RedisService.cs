using StackExchange.Redis;

namespace ECommerce.Basket.RedisSettings
{
	public class RedisService
	{
		private readonly RedisSettings _redisSettings;

		public RedisService(RedisSettings redisSettings)
		{
			_redisSettings = redisSettings;
		}

		private ConnectionMultiplexer _connectionMultiplexer;

		public void Connect() => 
			_connectionMultiplexer = ConnectionMultiplexer.Connect($"{_redisSettings.Host}:{_redisSettings.Port}");

		public IDatabase GetDatabase(int db = 1) =>
			_connectionMultiplexer.GetDatabase(0);
	}
}
