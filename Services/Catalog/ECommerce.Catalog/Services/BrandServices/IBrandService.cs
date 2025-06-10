using ECommerce.Catalog.Dtos.BrandDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task<ResultBrandDto> GetByIdAsync(string id);
        Task CreateAsync(CreateBrandDto createBrandDto);
        Task UpdateAsync(UpdateBrandDto updateBrandDto);
        Task DeleteAsync(string id);
    }
}