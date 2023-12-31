﻿using Microsoft.EntityFrameworkCore;
using RESTfull.Domain.DTO;
using RESTfull.Domain.Model;
using RESTfull.Infrastructure.Data;

namespace RESTfull.Infrastructure.Repository
{
    public class EmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context) => _context = context;

        public async Task<List<EmployeeDTO>> GetEmploeyersListAsync()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();

            List<EmployeeDTO> dto = new();
            foreach (var employee in employees)
            {
                dto.Add(new EmployeeDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                });
            }
            return dto.ToList();
        }
        public async Task AddEmployee(String name)
        {
            Employee employee = new();
            employee.Name = name;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(string id)
        {
            Employee employeeToDelete = _context.Employees.FirstOrDefault(e => e.Id == new Guid(id));

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string> GetIdByName(string name) // для тестов
        {
            Employee employee = await _context.Employees
                .Where(e => e.Name == name)
                .FirstOrDefaultAsync();
            return employee.Id.ToString();
        }


    }
}
