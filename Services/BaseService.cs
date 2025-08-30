using CourseManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Services
{
    public class BaseService<T> where T : class 
    {
        // Initialization
        protected readonly AppDbContext _context;

        // Constructor
        public BaseService(AppDbContext context)
        {
            _context = context;
        }

        // CRUD Operations
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }

        public T? GetById(int id) => _context.Set<T>().Find(id);
        public List<T> GetAll() => _context.Set<T>().ToList();
    }
}
