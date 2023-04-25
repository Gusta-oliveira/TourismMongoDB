using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismMongoDB.Models;
using TourismMongoDB.Services;

namespace TourismMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetId")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return address;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            var c = _cityService.Create(address.City);
            address.City = c;
            return _addressService.Create(address);
        }
        [HttpPut]
        public ActionResult<Address> Update(string id, Address address)
        {
            var a = _addressService.Get(id);
            if(a == null) return NotFound();
            _addressService.Update(id, address);
            return Ok();
        }
    }
}
