using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunday.Models;
using System.Reflection.Metadata.Ecma335;

namespace Sunday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DippsController : ControllerBase
    { private readonly AppDbContext _DbContext;

        public DippsController(AppDbContext Osogbo)
        {
            _DbContext = Osogbo;

        }

        [HttpGet]
        public IActionResult GetAllDipps()
        {
            var result = _DbContext.Olawale.ToList();
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDippo([FromRoute] int id)
        {

            var result = _DbContext.Olawale.Find(id);
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateDipps(Dipps dipps)
        {

            Dipps dipps1 = new Dipps();
            {
                dipps1.Id = dipps.Id;
                dipps1.Name = dipps.Name;
                dipps1.Description = dipps.Description;
                dipps1.Age = dipps.Age;
            };

            _DbContext.Add(dipps1);
            _DbContext.SaveChanges();
            return Ok(dipps1);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditDipps(int id, Dipps dipps)
        {
            var existingDipps = _DbContext.Olawale.Find(id);

            if (existingDipps != null)
            {
                existingDipps.Name = dipps.Name;
                existingDipps.Id = dipps.Id;
                _DbContext.SaveChanges();
                return Ok(existingDipps);


            }
            return NotFound();

        }
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteDipps([FromRoute] int id)
        {
            var Gush = _DbContext.Olawale.Find(id);
            if (Gush != null) 
            { 
                _DbContext.Olawale.Remove(Gush);  
                _DbContext.SaveChanges();   
                return Ok("Sucesssfully deleted Gush ");    
            
            }
              return NotFound();

        }
    }
}
