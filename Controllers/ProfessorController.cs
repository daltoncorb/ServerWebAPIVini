using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolS.Models;
using SchoolS.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolS.Controllers
{
    [Route("/professor")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> getProfessors([FromServices] DataContext context)
        {

            List<Professor> p = await context.Professors.AsNoTracking().ToListAsync();
            if (p == null)
                return NotFound(new { message = "Não foram localizados resultados!" });

            return Ok(p);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Professor>>> getProfessor([FromServices] DataContext context, int id)
        {

            if (id <= 0)
                return NotFound(new { message = "Professor not found!" });

            Professor p = await context.Professors.AsNoTracking().FirstOrDefaultAsync(pr => pr.id == id);
            if (p == null)
                return BadRequest(new { message = "Id not found in DataBase" });
            else
                return Ok(p);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> PostProfessor([FromServices] DataContext context)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> PutProfessor([FromServices] DataContext context)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Professor>>> DeleteProfessor([FromServices] DataContext context)
        {
            return Ok();
        }

    }
}