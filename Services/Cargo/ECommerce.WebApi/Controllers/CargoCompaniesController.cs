using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompaniesController : ControllerBase
	{
		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var result = _cargoCompanyService.TGetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _cargoCompanyService.TGetById(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public IActionResult Add(CargoCompany cargoCompany)
		{
			_cargoCompanyService.TAdd(cargoCompany);
			return Ok();
		}

		[HttpPut]
		public IActionResult Update(CargoCompany cargoCompany)
		{
			_cargoCompanyService.TUpdate(cargoCompany);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok();
		}
	}
}
