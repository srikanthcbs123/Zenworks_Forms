using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Dtos;
using Zenworks_Forms_BusinessEntities.Interfaces;
using Zenworks_Forms_BusinessEntities.Models;

namespace Zenworks_Forms_Service
{
    public  class DepartmentServices : IDepartmentService
    {
        public readonly IDepertmentRepository _Deptrepository;

        public DepartmentServices(IDepertmentRepository deptrepository)
        {
            _Deptrepository = deptrepository;
        }
        public async Task<bool> AddDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            var res = await _Deptrepository.AddDepartment(department);
            return res;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            await _Deptrepository.UpdateDepartment(department);
            return true;
        }

        public async Task<bool> DeleteDepartment(int deptId)
        {
            await _Deptrepository.DeleteDepartment(deptId);
            return true;
        }
        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            List<DepartmentDto> deptlist = new List<DepartmentDto>();
            var getdept = await _Deptrepository.GetAllDepartments();
            foreach (Department dept in getdept)
            {
                DepartmentDto deptobj = new DepartmentDto();
                deptobj.DepartmentId = dept.DepartmentId;
                deptobj.DepartmentName = dept.DepartmentName;
                deptobj.DepartmentLocation = dept.DepartmentLocation;
                deptlist.Add(deptobj);
            }
            return deptlist;
        }

        public async Task<DepartmentDto> GetDepartmentById(int DepartmentId)
        {

            var res = await _Deptrepository.GetDepartmentById(DepartmentId);
            DepartmentDto dept = new DepartmentDto();
            dept.DepartmentId = res.DepartmentId;
            dept.DepartmentName = res.DepartmentName;
            dept.DepartmentLocation = res.DepartmentLocation;
            return dept;
        }

    }
}
