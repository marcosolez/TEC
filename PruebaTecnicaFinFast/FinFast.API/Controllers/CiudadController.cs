using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinFast.DATOS.DTOs;
using FinFast.DATOS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinFast.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : ControllerBase
    {
        private readonly FinFastContext context;
        private readonly IMapper mapper;

        public CiudadController(FinFastContext finFastContext , IMapper mapper)
        {
            this.context = finFastContext;
            this.mapper = mapper;
        }

        [HttpGet] // api/ciudad
        public async Task<ActionResult<List<CiudadDTO>>> Get()
        {
            return await context.Ciudads.ProjectTo<CiudadDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
