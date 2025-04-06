using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Dtos;

namespace Zenworks_Forms_BusinessEntities.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int DepartmentId);
        Task<bool> AddDepartment(DepartmentDto Dept);
        Task<bool> UpdateDepartment(DepartmentDto Dept);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
