﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using school_helper.DbContext;
using school_helper.DTOs;
using school_helper.Entities;
using System.Security.Claims;

namespace school_helper.Servicies
{
    public interface IAssignmentRepository
    {
        Task CreateAssignment(AssignmentDTO assignmentDTO);
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper mapper;

        public AssignmentRepository(SchoolDbContext context,IMapper mapper)
        {
           _context = context;
            this.mapper = mapper;
        }

        public async Task CreateAssignment(AssignmentDTO assignmentDTO)
        {

            var assignmentmaped = mapper.Map<Assignment>(assignmentDTO);

            _context.Add(assignmentmaped);

            await _context.SaveChangesAsync();
        }
    }
}
