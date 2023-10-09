using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunday.DTO;
using Sunday.REPOS;

namespace Sunday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        private readonly ISunday _sundayServices;

            public RepoController( ISunday context)
        {
            _sundayServices = context;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllDipps() 
        
        { 

            var result = await _sundayServices.GetAllDipps();
            return Ok(result);
        }

        /// <summary>
        /// This end point is to show 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetDippsById(int id)
        {
            var result = await _sundayServices.GetDippsByID(id);
            return Ok(result);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDipps([FromBody] DippsDTO dipps, int id) 
        {
            var existingDipps = await _sundayServices.UpdateDipps( id, dipps);
           
            return Ok(existingDipps);   
        
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> AddDipps( DippsDTO dipps) 
        {
            var Lagos = await _sundayServices.AddDipps(dipps);
            return Ok(Lagos);

        
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteDipps( int id)
        {
            var buja = await _sundayServices.DeleteDipps(id);   
            return Ok(buja);

        }
    }
}
