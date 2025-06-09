using AutoMapper;
using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
		private readonly IMapper _mapper;

		public SpecialOfferService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_specialOfferCollection = mongoDatabase.GetCollection<SpecialOffer>(settings.SpecialOfferCollectionName);
			_mapper = mapper;
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
		{
			var values = await _specialOfferCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultSpecialOfferDto>>(values);
		}

		public async Task<ResultSpecialOfferDto> GetByIdAsync(string id)
		{
			var value = await _specialOfferCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultSpecialOfferDto>(value);
		}

		public async Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
			await _specialOfferCollection.InsertOneAsync(value);
		}

		public async Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
			await _specialOfferCollection.FindOneAndReplaceAsync(x => x.Id == updateSpecialOfferDto.Id, value);
		}

		public async Task DeleteAsync(string id)
		{
			await _specialOfferCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
