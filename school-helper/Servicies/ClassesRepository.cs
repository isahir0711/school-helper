using AutoMapper;
using Microsoft.EntityFrameworkCore;
using school_helper.DbContext;
using school_helper.DTOs;
using school_helper.Entities;

namespace school_helper.Servicies
{
    public interface IClassesRepository
    {
        Task CreateClass(ClassDTO classDTO);
        Task<List<ClassDTO>> GetClasses();
    }
    public class ClassesRepository : IClassesRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public ClassesRepository(SchoolDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task CreateClass(ClassDTO classDTO)
        {
            classDTO.UserId = await userService.GetUserIdAsync();

            var classmaped = mapper.Map<Class>(classDTO);

            _context.Add(classmaped);

            await _context.SaveChangesAsync();
        }


        public async Task<List<ClassDTO>> GetClasses()
        {
            var userId = await userService.GetUserIdAsync();


            var classes = await _context.Class.Where(c => c.UserId == userId).ToListAsync();

            var classesDTO = classes.Select(c => new ClassDTO
            {
                Name = c.Name,
                DaysIds = c.DaysIds,
                DaysNames = c.DaysIds.Select(dayId => _context.Days.FirstOrDefault(d => d.Id == dayId)?.Name).ToList(),
                UserId = c.UserId,
            }).ToList();


            return classesDTO;

        }
    }
}
