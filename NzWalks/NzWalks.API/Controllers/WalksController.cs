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

        //Create Walks
        //POST /api/walks
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

        //Get All Walks
        //GET /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepositery.GetAllAsync();

            //Map to Domain to DTO
            return Ok(mapper.Map<List<WalksDTO>>(walksDomainModel));
        }

        //Get Walk By Id
        //GET /api/walks/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepositery.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            };
            return Ok(mapper.Map<WalksDTO>(walkDomainModel));

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkReques)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkReques);

            walkDomainModel = await walkRepositery.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDTO>(walkDomainModel));
        }


    }
}
