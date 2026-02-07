using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Data;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;

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
            //Get Data from Database Domain
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain to DTO
            var regionsDTO = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDTO.Add(new RegionDTO
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            //Return DTO's
            return Ok(regionsDTO);
        }

        //GET REGION BY ID
        //https://localhost:44328/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            //GET region from Domain Model from Database
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain == null)
            {
                return NotFound();

            }

            //Map Domain to DTO
            var regionDto = new Region
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
