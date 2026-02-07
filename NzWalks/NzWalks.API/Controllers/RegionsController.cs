using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Data;

namespace NzWalks.API.Controllers
{

    //https://localhost:44328/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext )
        {
            this.dbContext = dbContext;
        }
        //GET ALL REGIONS
        //https://localhost:44328/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }

        //GET REGION BY ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(region == null)
            {
                return NotFound();

            }
            return Ok(region);
        }
    }
}
