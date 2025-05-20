using AutoMapper;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;
		public CategoryService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_categoryCollection = mongoDatabase.GetCollection<Category>(settings.CategoryCollectionName);
			_mapper = mapper;
		}
		public Task<List<ResultCategoryDto>> GetAllAsync()
		{
			throw new NotImplementedException();
		}
		public Task<ResultCategoryDto> GetByIdAsync(string id)
		{
			throw new NotImplementedException();
		}
		public Task CreateAsync(CreateCategoryDto entity)
		{
			throw new NotImplementedException();
		}
		public Task UpdateAsync(UpdateCategoryDto entity)
		{
			throw new NotImplementedException();
		}
		public Task DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}
	}
}
