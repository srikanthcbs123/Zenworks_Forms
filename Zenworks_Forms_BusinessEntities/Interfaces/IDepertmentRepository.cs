using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Models;

namespace Zenworks_Forms_BusinessEntities.Interfaces
{
    public  interface IDepertmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int DepartmentId);
        Task<bool> AddDepartment(Department Dept);
        Task<bool> UpdateDepartment(Department Dept);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
