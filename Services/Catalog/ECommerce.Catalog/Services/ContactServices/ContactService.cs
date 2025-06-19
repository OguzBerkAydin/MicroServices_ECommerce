using AutoMapper;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ContactServices
{
	public class ContactService : IContactService
	{
		private readonly IMongoCollection<Contact> _contactCollection;
		private readonly IMapper _mapper;
		public ContactService(IDatabaseSettings settings, IMapper mapper)
		{
			var mongoClient = new MongoClient(settings.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
			_contactCollection = mongoDatabase.GetCollection<Contact>(settings.ContactCollectionName);
			_mapper = mapper;
		}
		public async Task CreateAsync(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			await _contactCollection.InsertOneAsync(value);

		}

		public async Task DeleteAsync(string id)
		{
			await _contactCollection.DeleteOneAsync(contact => contact.Id == id);
		}

		public async Task<List<ResultContactDto>> GetAllAsync()
		{
			var contacts = await _contactCollection.Find(contact => true).ToListAsync();
			return _mapper.Map<List<ResultContactDto>>(contacts);
		}

		public async Task<ResultContactDto> GetByIdAsync(string id)
		{
			var contact = await _contactCollection.Find(contact => contact.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultContactDto>(contact);
		}

		public async Task UpdateAsync(UpdateContactDto updateContactDto)
		{
			var contact = _mapper.Map<Contact>(updateContactDto);
			await _contactCollection.ReplaceOneAsync(c => c.Id == updateContactDto.Id, contact);
		}
	}
}
