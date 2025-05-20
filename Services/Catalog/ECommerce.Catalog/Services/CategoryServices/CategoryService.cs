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
		public async Task<List<ResultCategoryDto>> GetAllAsync()
		{
			var values = await _categoryCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDto>>(values);
		}
		public async Task<ResultCategoryDto> GetByIdAsync(string id)
		{
			var value = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultCategoryDto>(value);
		}
		public async Task CreateAsync(CreateCategoryDto createCategoryDto)
		{
			var value = _mapper.Map<Category>(createCategoryDto);
			await _categoryCollection.InsertOneAsync(value);

		}
		public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
		{
			var value = _mapper.Map<Category>(updateCategoryDto);
			await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == updateCategoryDto.Id, value);

		}
		public async Task DeleteAsync(string id)
		{
			await _categoryCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
