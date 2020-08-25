

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolS.Data;
using SchoolS.Models;

namespace SchoolS.Controller
{
    [Route("/student")]
    public class StudentController: ControllerBase{

      [HttpGet]
      [Route("")]
      public async Task<ActionResult<List<Student>>> getStudents([FromServices]DataContext context){
          List<Student> s = await context.Students.AsNoTracking().ToListAsync();

          if (s == null)
          return NotFound(new {message="Nenhum aluno encontrando"});
          else
          return Ok(s);
      } 

      [HttpGet]
      [Route("{id:int}")]
      public async Task<ActionResult<Student>> getStudent([FromServices]DataContext context, int id){

        Student s = await context.Students.FirstOrDefaultAsync( st => st.id == id);
        if (s == null)
          return BadRequest(new {message="Não encontrado !"});

        return Ok(s);
      } 

      [HttpPost]
      [Route("")]
      public async Task<ActionResult<Student>> postStudent([FromServices]DataContext context, [FromBody]Student model){

          if (!ModelState.IsValid )
            return BadRequest(new{ message="Problemas na estrutura dos dados "});
          else {
            context.Students.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
          }

      }

      [HttpPut]
      [Route("{id:int}")]
      public async Task<ActionResult<Student>> putStudent([FromServices]DataContext context, [FromBody]Student model, int id){

          if (!ModelState.IsValid )
            return BadRequest(new{ message="Problemas na estrutura dos dados "});
          else {
            context.Students.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
          }

      }

      [HttpDelete]
      [Route("{id:int}")]
      public async Task<ActionResult<Student>> postStudent([FromServices]DataContext context, [FromBody]Student model, int id){

          if (id <= 0)
            return BadRequest(new{ message="É necessário uma matrícula maior que Zero"});

          if (!ModelState.IsValid )
            return BadRequest(new{ message="Problemas na estrutura dos dados "});
          else {
            context.Students.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
          }

      }      


    }

}