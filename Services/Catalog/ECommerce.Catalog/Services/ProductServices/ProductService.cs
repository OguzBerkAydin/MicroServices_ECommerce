using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductServices
{
	public class ProductService : IProductService
	{
		private readonly IMongoCollection<Product> _productCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;
		public ProductService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_productCollection = mongoDatabase.GetCollection<Product>(settings.ProductCollectionName);
			_categoryCollection = mongoDatabase.GetCollection<Category>(settings.CategoryCollectionName);
			_mapper = mapper;
		}
		public async Task CreateAsync(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			await _productCollection.InsertOneAsync(value);
		}

		public async Task DeleteAsync(string id)
		{
			await _productCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<ResultProductDto>> GetAllAsync()
		{
			var values = await _productCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDto>>(values);
		}

		public async Task<ResultProductDto> GetByIdAsync(string id)
		{
			var value = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductDto>(value);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
		{
			var values = await _productCollection.Find(x => true).ToListAsync();
			foreach (var item in values)
			{
				item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstOrDefaultAsync();
			}
			return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

		}

		public async Task UpdateAsync(UpdateProductDto updateProductDto)
		{
			var value = _mapper.Map<Product>(updateProductDto);
			await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, value);
		}
	}
}
