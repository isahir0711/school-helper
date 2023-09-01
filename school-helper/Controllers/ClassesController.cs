using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
            await classesRepository.CreateClass(classDTO);

            return NoContent();
        }

        [HttpGet("GetMyClasses")]
        public async Task<ActionResult<List<ClassDTO>>> GetClasses()
        {
            var classes = await classesRepository.GetClasses();

            return classes;
        }
    }
}
