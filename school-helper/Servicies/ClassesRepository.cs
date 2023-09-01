using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using school_helper.DbContext;
using school_helper.DTOs;
using school_helper.Entities;

namespace school_helper.Servicies
{
    public interface IClassesRepository
    {
        Task CreateClass(ClassDTO classDTO);
        Task<bool> DeleteClass(int id);
        Task<bool> ExistClass(int id);
        Task<List<ClassDTO>> GetClasses();
        Task<bool> PutClass(int id, EditClassDTO editClassDTO);
        //Task<bool> PutClass(int id, EditClassDTO editClassDTO);
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
            string userId = await userService.GetUserIdAsync();

            classDTO.UserId = userId;

            var newclass = mapper.Map<Class>(classDTO);

            newclass.ClassSchedules = mapper.Map<List<ClassSchedule>>(classDTO.ClassSchedules);

            _context.Classes.Add(newclass);

            await _context.SaveChangesAsync();

        }

        public async Task<List<ClassDTO>> GetClasses()
        {
            string userId = await userService.GetUserIdAsync();

            var classesandschedules = await _context.Classes.Where(cs => cs.UserId == userId)
                .Include(c => c.ClassSchedules)
                .ToListAsync();

            /*deprecated two querys 1.- for classes 2.- schedules of each class
            
            var classes = await _context.Classes.Where(c => c.UserId == userId).ToListAsync();
            get all schedules of each class
            foreach(var cls in classes)
            {
                var schedules = await _context.ClassSchedules.Where(c => c.ClassId == cls.Id).ToListAsync();
                cls.ClassSchedules = schedules;
            }
            
            */

            return mapper.Map<List<ClassDTO>>(classesandschedules);
        }

        public async Task<bool> PutClass(int id, EditClassDTO editClassDTO)
        {
            bool exists = await ExistClass(id);

            if (exists)
            {
                string userId = await userService.GetUserIdAsync();
                Class classupdate = mapper.Map<Class>(editClassDTO);
                classupdate.Id = id;
                classupdate.UserId = userId;

                _context.Update(classupdate);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;

        }

        public async Task<bool> DeleteClass(int id)
        {
            var exists = await _context.Classes.AnyAsync(c => c.Id == id);

            if (exists)
            {
                _context.Remove(new Class() { Id = id });

                await RemoveClassSchedules(id);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task RemoveClassSchedules(int ClassId)
        {
            var csdules = await _context.ClassSchedules.Where(cs => cs.ClassId ==  ClassId).ToListAsync();

            _context.ClassSchedules.RemoveRange(csdules);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistClass(int id)
        {
            var classdB = await _context.Classes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (classdB == null)
            {
                return false;
            }

            return true;
        }


    }
}
