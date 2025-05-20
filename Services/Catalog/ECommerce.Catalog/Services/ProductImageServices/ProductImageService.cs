using AutoMapper;
using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _productImageCollection;
		private readonly IMapper _mapper;
		public ProductImageService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_productImageCollection = mongoDatabase.GetCollection<ProductImage>(settings.ProductImageCollectionName);
			_mapper = mapper;
		}
		public async Task<List<ResultProductImageDto>> GetAllAsync()
		{
			var values = await _productImageCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}
		public async Task<ResultProductImageDto> GetByIdAsync(string id)
		{
			var value = await _productImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductImageDto>(value);
		}
		public async Task CreateAsync(CreateProductImageDto createProductImageDto)
		{
			var value = _mapper.Map<ProductImage>(createProductImageDto);
			await _productImageCollection.InsertOneAsync(value);
		}
		public async Task UpdateAsync(UpdateProductImageDto updateProductImageDto)
		{
			var value = _mapper.Map<ProductImage>(updateProductImageDto);
			await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageDto.Id, value);
		}
		public async Task DeleteAsync(string id)
		{
			await _productImageCollection.DeleteOneAsync(x => x.Id == id);
		}

	}
}
