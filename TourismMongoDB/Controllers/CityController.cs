﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismMongoDB.Models;
using TourismMongoDB.Services;

namespace TourismMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);
            if (city == null) return NotFound();
            
            return city;
        }
        [HttpPost]
        public ActionResult<City> Create(City city) 
        {
            return _cityService.Create(city); 
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, City city)
        {
            var c = _cityService.Get(id);
            if (c == null) return NotFound();
            _cityService.Update(id, city);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            _cityService.Delete(id);
            return Ok();
        }
    }
}
