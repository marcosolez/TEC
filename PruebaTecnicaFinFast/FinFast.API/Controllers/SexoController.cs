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
    public class SexoController : ControllerBase
    {
        private readonly FinFastContext context;
        private readonly IMapper mapper;

        public SexoController(FinFastContext finFastContext , IMapper mapper)
        {
            this.context = finFastContext;
            this.mapper = mapper;
        }

        [HttpGet] // api/ciudad
        public async Task<ActionResult<List<SexoDTO>>> Get()
        {
            return await context.Sexos.ProjectTo<SexoDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
