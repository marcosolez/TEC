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
    public class PersonaController : ControllerBase
    {
        private readonly FinFastContext context;
        private readonly IMapper mapper;

        public PersonaController(FinFastContext finFastContext , IMapper mapper)
        {
            this.context = finFastContext;
            this.mapper = mapper;
        }

        [HttpGet] // api/Persona
        public async Task<ActionResult<List<PersonasListDTO>>> Get()
        {
            return await context.Personas.ProjectTo<PersonasListDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id}")] // api/Persona/Id
        public async Task<ActionResult<PersonaDetalleDTO>> Get(Guid  id)
        {         

            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            if (persona==null)
            {
                return BadRequest();
            }

            return mapper.Map<PersonaDetalleDTO>(persona);
         
        }

        [HttpPost] // api/Persona/Id
        public async Task<ActionResult> Post([FromBody] PersonaPostDTO model)
        {
            var persona = mapper.Map<PersonaPostDTO,Persona>(model);
            context.Add(persona);
            var resp= await context.SaveChangesAsync();

            if (resp==1)
                return Ok(resp);

            return NoContent();          

        }


        [HttpDelete("{id}")] // api/Persona/Id
        public async Task<ActionResult> Delete(Guid id)
        {

            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            if (persona == null)
            {
                return BadRequest();
            }
            context.Personas.Remove(persona);
            var resp= await context.SaveChangesAsync();

            return Ok(resp);



        }
    }
}
