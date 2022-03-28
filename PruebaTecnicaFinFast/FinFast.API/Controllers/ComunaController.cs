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
    public class ComunaController : ControllerBase
    {
        private readonly FinFastContext context;
        private readonly IMapper mapper;

        public ComunaController(FinFastContext finFastContext, IMapper mapper)
        {
            this.context = finFastContext;
            this.mapper = mapper;
        }

        [HttpGet] // api/region
        public async Task<ActionResult<List<ComunaDTO>>> Get()
        {
            return await context.Comunas.ProjectTo<ComunaDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
