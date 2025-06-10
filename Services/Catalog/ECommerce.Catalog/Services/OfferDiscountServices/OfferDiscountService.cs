using AutoMapper;
using ECommerce.Catalog.Dtos.OfferDiscountDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
		private readonly IMapper _mapper;

		public OfferDiscountService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_offerDiscountCollection = mongoDatabase.GetCollection<OfferDiscount>(settings.OfferDiscountCollectionName);
			_mapper = mapper;
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllAsync()
		{
			var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task<ResultOfferDiscountDto> GetByIdAsync(string id)
		{
			var value = await _offerDiscountCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultOfferDiscountDto>(value);
		}

		public async Task CreateAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
			await _offerDiscountCollection.InsertOneAsync(value);
		}

		public async Task UpdateAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
			await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.Id == updateOfferDiscountDto.Id, value);
		}

		public async Task DeleteAsync(string id)
		{
			await _offerDiscountCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
