using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using school_helper.DTOs;
using school_helper.Servicies;
using System.Security.Claims;

namespace school_helper.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AssignmentsController(IAssignmentRepository assignmentRepository,UserManager<IdentityUser> userManager)
        {
            this.assignmentRepository = assignmentRepository;
            this.userManager = userManager;
        }

        [HttpGet("GetAssignments")]
        public async Task<List<AssignmentDTO>> Get()
        {
            var assignments = await assignmentRepository.GetAssignments();

            return assignments;
        }

        [HttpGet("GetTodayAssignments")]
        public async Task<List<AssignmentDTO>> GetToday()
        {
            var assignments = await assignmentRepository.GetTodayAssignments();

            return assignments;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAssignment([FromBody] AssignmentDTO assignment)
        {
            var email = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault().Value;
            var user = await userManager.FindByEmailAsync(email);
            assignment.UserId = user.Id;

            var result = await assignmentRepository.CreateAssignment(assignment);

            if (result)
            {
                return NoContent();
            }

            return NotFound("No class found");

        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await assignmentRepository.DeleteAssignment(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound("No assignment with the provided id");
        }


        [HttpPut("Check/{id}")]
        public async Task<ActionResult> Check(int id)
        {
            await assignmentRepository.CheckAssignment(id);

            return NoContent();
        }

    }
}
