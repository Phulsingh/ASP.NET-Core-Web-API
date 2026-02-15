using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;
using NzWalks.API.Repositories;


namespace NzWalks.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]

    public class WalksController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IWalksRepositery walkRepositery;

        public WalksController(IMapper mapper, IWalksRepositery walkRepositery)
        {
            this.mapper = mapper;
            this.walkRepositery = walkRepositery;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDTO addWalksDTO)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalksDTO);

            await walkRepositery.CreateAsync(walkDomainModel);

            //Map Domain to DTO
            var walkDTO = mapper.Map<WalksDTO>(walkDomainModel);

            return Ok(walkDTO);

        }
    }
}
