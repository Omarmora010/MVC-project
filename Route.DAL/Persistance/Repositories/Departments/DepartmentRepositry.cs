using Microsoft.EntityFrameworkCore;
using Route.DAL.Entities.Departments;
using Route.DAL.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.DAL.Persistance.Repositories.Departments
{
    public class DepartmentRepositry : IDepartmentRepositry
    {

        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepositry(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking) {

                return _dbContext.Departments.AsNoTracking().ToList();
            }
                return _dbContext.Departments.ToList();

        }

        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IQueryable<Department> GetAllAsIQueryable()
        { 
            return _dbContext.Departments;
        }
    }
}
