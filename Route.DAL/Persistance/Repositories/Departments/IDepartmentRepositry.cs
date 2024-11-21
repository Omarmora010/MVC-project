﻿using Route.DAL.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.DAL.Persistance.Repositories.Departments
{
    public interface IDepartmentRepositry
    {
        IEnumerable<Department> GetAll( bool withAsNoTracking = true );

        IQueryable<Department> GetAllAsIQueryable();

        Department? GetById ( int id );

        int Add( Department entity );

        int Update(Department entity);


        int Delete(Department entity);

    }
}
