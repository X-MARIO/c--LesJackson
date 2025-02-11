using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;

namespace PlatformService.Controllers;

public class PlatformController : ControllerBase
{
    public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
    {
        
    }
}