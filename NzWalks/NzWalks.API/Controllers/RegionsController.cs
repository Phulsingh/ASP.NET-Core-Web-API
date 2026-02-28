using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.API.Automapper;
using NzWalks.API.CustumActionFilters;
using NzWalks.API.Data;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;
using NzWalks.API.Repositories;

namespace NzWalks.API.Controllers
{

    //https://localhost:44328/api/regions
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        //private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,  IMapper mapper)
        {
            //this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GET ALL REGIONS
        //https://localhost:44328/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database Domain
            //var regionsDomain = await dbContext.Regions.ToListAsync();

            //Use Repository to create Region in Database
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain to DTO
            //var regionsDTO = new List<RegionDTO>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDTO.Add(new RegionDTO
            //    {
            //        Id = regionDomain.Id,
            //        Name = regionDomain.Name,
            //        Code = regionDomain.Code,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}


            var regionsDTO = mapper.Map<List<RegionDTO>>(regionsDomain);

            //Return DTO's
            return Ok(regionsDTO);
        }

        //GET REGION BY ID
        //https://localhost:44328/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async  Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            //GET region from Domain Model from Database
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //Use Repository to create Region in Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
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

            //return Ok(regionDto);
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        [HttpPost]
        [ValidationModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
  
                //Map DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDTO.Code,
                //    Name = addRegionRequestDTO.Name,
                //    RegionImageUrl = addRegionRequestDTO.RegionImageUrl
                //};

                //Use AutoMapper to Map DTO to Domain Model
                var regionsDomain = mapper.Map<Region>(addRegionRequestDTO);

                //Use Domain Model to create Region in Database1
                //await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();

                //Use Repository to create Region in Database
                var regionDomainModel = await regionRepository.CreateAsync(regionsDomain);

                //Map Domain Model Back to DTO
                //var regionDTO = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                //Use AutoMapper to Map Domain Model Back to DTO
                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }

        //PUT Update Region
        //https://localhost:44328/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidationModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
         
                //Check if the Region Exist 
                //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

                //DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Name = updateRegionRequestDTO.Name,
                //    Code = updateRegionRequestDTO.Code,
                //    RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
                //};

                //Automapper DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

                //Use Repository to create Region in Database
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //regionDomainModel.Name = updateRegionRequestDTO.Name;
                //regionDomainModel.Code = updateRegionRequestDTO.Code;
                //regionDomainModel.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

                //Update Region using Domain Model
                //await  dbContext.SaveChangesAsync();

                //Conver Domain to DTO 
                //var regionDTO = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Name = regionDomainModel.Name,
                //    Code = regionDomainModel.Code,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                //Automap 
                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

                return Ok(regionDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //Check if the Region Exist 
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //Use Repository to create Region in Database
            var regionDomainModel = await regionRepository.DeleteAsync(id);


            if (regionDomainModel == null)
            {
                return NotFound();

            }

            //Delete Region using Domain Model
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }
    }
}
