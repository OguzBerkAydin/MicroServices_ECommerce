using AutoMapper;
using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IDatabaseSettings settings, IMapper mapper)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
            _brandCollection = mongoDatabase.GetCollection<Brand>(settings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultBrandDto>> GetAllAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<ResultBrandDto> GetByIdAsync(string id)
        {
            var value = await _brandCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBrandDto>(value);
        }

        public async Task CreateAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task UpdateAsync(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.Id == updateBrandDto.Id, value);
        }

        public async Task DeleteAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
