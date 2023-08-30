using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_helper.DTOs;
using school_helper.Servicies;

namespace school_helper.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentRepository;

        public AssignmentsController(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAssignment([FromBody] AssignmentDTO assignment)
        {
            await assignmentRepository.CreateAssignment(assignment);

            return NoContent();
        }
    }
}
