using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly IMongoCollection<ProductDetail> _productDetailCollection;
		private readonly IMapper _mapper;
		public ProductDetailService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_productDetailCollection = mongoDatabase.GetCollection<ProductDetail>(settings.ProductDetailCollectionName);
			_mapper = mapper;
		}
		public async Task CreateAsync(CreateProductDetailDto createProductDetailDto)
		{
			var value = _mapper.Map<ProductDetail>(createProductDetailDto);
			await _productDetailCollection.InsertOneAsync(value);
		}
		public async Task DeleteAsync(string id)
		{
			await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
		}
		public async Task<List<ResultProductDetailDto>> GetAllAsync()
		{
			var values = await _productDetailCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}
		public async Task<ResultProductDetailDto> GetByIdAsync(string id)
		{
			var value = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductDetailDto>(value);

		}
		public async Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
			await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailDto.Id, value);
		}
	}
}
