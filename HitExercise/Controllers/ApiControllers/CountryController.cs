﻿using HitExercise.Data;
using HitExercise.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HitExercise.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public object Get()
        {
           return _countryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
    }
}
