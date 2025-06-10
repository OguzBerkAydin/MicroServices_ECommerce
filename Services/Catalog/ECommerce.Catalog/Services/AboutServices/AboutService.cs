using AutoMapper;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.AboutServices
{
	public class AboutService : IAboutService
	{
		private readonly IMongoCollection<About> _aboutCollection;
		private readonly IMapper _mapper;
		public AboutService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_aboutCollection = mongoDatabase.GetCollection<About>(settings.AboutCollectionName);
			_mapper = mapper;
		}
		public async Task<List<ResultAboutDto>> GetAllAsync()
		{
			var values = await _aboutCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultAboutDto>>(values);
		}
		public async Task<ResultAboutDto> GetByIdAsync(string id)
		{
			var value = await _aboutCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultAboutDto>(value);
		}
		public async Task CreateAsync(CreateAboutDto createAboutDto)
		{
			var value = _mapper.Map<About>(createAboutDto);
			await _aboutCollection.InsertOneAsync(value);
		}
		public async Task UpdateAsync(UpdateAboutDto updateAboutDto)
		{
			var value = _mapper.Map<About>(updateAboutDto);
			await _aboutCollection.FindOneAndReplaceAsync(x => x.Id == updateAboutDto.Id, value);
		}
		public async Task DeleteAsync(string id)
		{
			await _aboutCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
