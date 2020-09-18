using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForSale.WebbApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForSale.WebbApp.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]

    public class CountriesController : ControllerBase

    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.Countries
                .Include(c => c.Departments)
                .ThenInclude(d => d.Cities));
        }
    }

}

