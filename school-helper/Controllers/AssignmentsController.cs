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

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAssignment([FromBody] AssignmentDTO assignment)
        {
            var email = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault().Value;
            var user = await userManager.FindByEmailAsync(email);
            assignment.UserId = user.Id;

            await assignmentRepository.CreateAssignment(assignment);

            return NoContent();
        }
    }
}
