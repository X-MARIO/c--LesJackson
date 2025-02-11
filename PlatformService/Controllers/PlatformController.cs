using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/platform")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
    {
        _repository = platformRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> GetPlatforms");

        var platformItem = _repository.GetAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetPlatformById([FromRoute] int id)
    {
        Console.WriteLine("--> GetPlatformById");

        var platformItem = _repository.GetPlatformById(id);

        if (platformItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform([FromBody] PlatformCreateDto platformCreateDto)
    {
        Console.WriteLine("--> CreatePlatform");
        
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();
        
        var platfromReadDto = _mapper.Map<PlatformReadDto>(platformModel);
        
        return CreatedAtAction(nameof(GetPlatformById), new { id = platformModel.Id }, platfromReadDto);
    }
}