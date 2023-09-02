using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using school_helper.DbContext;
using school_helper.DTOs;
using school_helper.Entities;
using System.Security.Claims;

namespace school_helper.Servicies
{
    public interface IAssignmentRepository
    {
        Task<bool> CheckAssignment(int id);
        Task<bool> CreateAssignment(AssignmentDTO assignmentDTO);
        Task<bool> DeleteAssignment(int id);
        Task<List<AssignmentDTO>> GetAssignments();
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper mapper;
        private readonly IClassesRepository classesRepository;
        private readonly IUserService userService;

        public AssignmentRepository(SchoolDbContext context, IMapper mapper, IClassesRepository classesRepository
            ,IUserService userService)
        {
            _context = context;
            this.mapper = mapper;
            this.classesRepository = classesRepository;
            this.userService = userService;
        }

        public async Task<bool> CreateAssignment(AssignmentDTO assignmentDTO)
        {
            var existClass = await classesRepository.ExistClass(assignmentDTO.ClassId);

            if (existClass)
            {
                var assignmentmaped = mapper.Map<Assignment>(assignmentDTO);

                _context.Add(assignmentmaped);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAssignment(int id)
        {
            var exists = await _context.Assignments.AnyAsync(a => a.Id == id);

            if (exists)
            {
                _context.Remove(new Assignment() { Id = id });

                await _context.SaveChangesAsync();
                return true;
            }

            return false;


        }

        public async Task<bool> CheckAssignment(int id)
        {
            var assbd = await _context.Assignments.FirstOrDefaultAsync(a => a.Id == id);

            if (assbd != null)
            {
                assbd.IsDone = true;

                _context.Update(assbd);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<AssignmentDTO>> GetAssignments()
        {
            var userId = await userService.GetUserIdAsync();

            var assignments = await _context.Assignments.Where(a => a.UserId == userId).ToListAsync();

            return mapper.Map<List<AssignmentDTO>>(assignments);
        }


    }
}
