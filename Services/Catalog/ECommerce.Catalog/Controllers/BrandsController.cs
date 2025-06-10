using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultBrandDto>>> GetAll()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultBrandDto>> GetById(string id)
        {
            var result = await _brandService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateAsync(createBrandDto);
            return Ok("Brand added successfully");
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateAsync(updateBrandDto);
            return Ok("Brand updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _brandService.DeleteAsync(id);
            return Ok("Brand deleted successfully");
        }
    }
}