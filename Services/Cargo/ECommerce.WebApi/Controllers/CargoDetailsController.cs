using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(CargoDetailsDto detail)
        {
            var cargodetail = new CargoDetail();
            cargodetail.SenderCustomer = detail.SenderCustomer;
            cargodetail.RecieverCustomer = detail.RecieverCustomer;
            cargodetail.CargoCompanyId = detail.CargoCompanyId;
            cargodetail.Barcode = detail.Barcode;
            _cargoDetailService.TAdd(cargodetail);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CargoDetail detail)
        {
            _cargoDetailService.TUpdate(detail);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok();
        }
       
    }
    public class CargoDetailsDto()
    {
		public string SenderCustomer { get; set; }
		public string RecieverCustomer { get; set; }
		public int Barcode { get; set; }
		public int CargoCompanyId { get; set; }
	}
}
