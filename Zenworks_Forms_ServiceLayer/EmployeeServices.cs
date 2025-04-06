﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenworks_Forms_BusinessEntities.Dtos;
using Zenworks_Forms_BusinessEntities.Interfaces;
using Zenworks_Forms_BusinessEntities.Models;

namespace Zenworks_Forms_Service
{
    public class EmployeeServices : IEmployeeService
    {
        IEmployeeRepository _repository;
        public EmployeeServices(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empsalary = empdetail.empsalary;
            emp.empname = empdetail.empname;
            var res = await _repository.AddEmployes(emp);
            return res;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _repository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _repository.GetEmployeeById(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.empid = res.empid;
            empdto.empname = res.empname;
            empdto.empsalary = res.empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _repository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid = emp.empid;
                empdto.empsalary = emp.empsalary;
                empdto.empname = emp.empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;
        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empsalary = empdetail.empsalary;
            emp.empname = empdetail.empname;
            await _repository.UpdateEmploye(emp);
            return true;
        }
    }
}
