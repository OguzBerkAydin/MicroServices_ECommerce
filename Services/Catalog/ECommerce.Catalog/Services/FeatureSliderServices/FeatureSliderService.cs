using AutoMapper;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Services.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
		private readonly IMapper _mapper;

		public FeatureSliderService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_featureSliderCollection = mongoDatabase.GetCollection<FeatureSlider>(settings.FeatureSliderCollectionName);
			_mapper = mapper;
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
		{
			var values = await _featureSliderCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultFeatureSliderDto>>(values);
		}

		public async Task<ResultFeatureSliderDto> GetByIdAsync(string id)
		{
			var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureSliderDto>(value);
		}

		public async Task CreateAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
			await _featureSliderCollection.InsertOneAsync(value);
		}

		public async Task UpdateAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
			await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderDto.Id, value);
		}

		public async Task DeleteAsync(string id)
		{
			await _featureSliderCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task ChangeFeatureSliderStatusAsync(string id, bool status)
		{
			var featureSlider = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			if (featureSlider != null)
			{
				featureSlider.Status = status;
				await _featureSliderCollection.ReplaceOneAsync(x => x.Id == id, featureSlider);
			}
		}
	}
}