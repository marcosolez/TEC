using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinFast.DATOS.DTOs;
using FinFast.DATOS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinFast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly FinFastContext context;
        private readonly IMapper mapper;

        public RegionController(FinFastContext finFastContext, IMapper mapper)
        {
            this.context = finFastContext;
            this.mapper = mapper;
        }

        [HttpGet] // api/region
        public async Task<ActionResult<List<RegionDTO>>> Get()
        {
            return await context.Regions.ProjectTo<RegionDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
