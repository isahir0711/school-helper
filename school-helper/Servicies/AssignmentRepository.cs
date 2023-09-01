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
        Task<bool> CreateAssignment(AssignmentDTO assignmentDTO);
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper mapper;
        private readonly IClassesRepository classesRepository;

        public AssignmentRepository(SchoolDbContext context,IMapper mapper,IClassesRepository classesRepository)
        {
           _context = context;
            this.mapper = mapper;
            this.classesRepository = classesRepository;
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

    }
}
