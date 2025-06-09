using AutoMapper;
using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.FeatureServices
{
	public class FeatureService : IFeatureService
	{
		private readonly IMongoCollection<Feature> _featureCollection;
		private readonly IMapper _mapper;

		public FeatureService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_featureCollection = mongoDatabase.GetCollection<Feature>(settings.FeatureCollectionName);
			_mapper = mapper;
		}

		public async Task<List<ResultFeatureDto>> GetAllAsync()
		{
			var values = await _featureCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureDto>>(values);
		}

		public async Task<ResultFeatureDto> GetByIdAsync(string id)
		{
			var value = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureDto>(value);
		}

		public async Task CreateAsync(CreateFeatureDto createFeatureDto)
		{
			var value = _mapper.Map<Feature>(createFeatureDto);
			await _featureCollection.InsertOneAsync(value);
		}

		public async Task UpdateAsync(UpdateFeatureDto updateFeatureDto)
		{
			var value = _mapper.Map<Feature>(updateFeatureDto);
			await _featureCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureDto.Id, value);
		}

		public async Task DeleteAsync(string id)
		{
			await _featureCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
