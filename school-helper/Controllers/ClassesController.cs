using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_helper.DTOs;
using school_helper.Servicies;

namespace school_helper.Controllers
{
    [ApiController]
    [Route("api/Classes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepository classesRepository;

        public ClassesController(IClassesRepository classesRepository)
        {
            this.classesRepository = classesRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateClass ([FromBody] ClassDTO classDTO)
        {
            if (classDTO == null)
            {
                return BadRequest("Invalid Object Sended");
            }

            await classesRepository.CreateClass(classDTO);

            return NoContent();
        }


        [HttpGet("GetClasses")]
        public async Task<ActionResult<List<ClassDTO>>> GetClasses()
        {
            var classes = await classesRepository.GetClasses();

            return Ok(classes);
        }

        [HttpGet("GetTodayClasses")]
        public async Task<ActionResult<List<ClassDTO>>> GetTodayClasses([FromBody] string weekDay)
        {
            var classes = await classesRepository.GetTodayClasses(weekDay);

            return Ok(classes);
        }


        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EditClassDTO editClassDTO)
        {
            var result = await classesRepository.PutClass(id, editClassDTO);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await classesRepository.DeleteClass(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
