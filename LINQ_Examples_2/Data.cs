using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples_2
{
    public class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "Kobe",
                LastName = "Mancuyas",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 6,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 2,
                FirstName = "Sio",
                LastName = "Jeuong",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 3,
                FirstName = "Aran",
                LastName = "Jeong",
                AnnualSalary = 40000.1m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 4,
                FirstName = "Keena",
                LastName = "Song",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 5,
                FirstName = "Chris",
                LastName = "Mancuyas",
                AnnualSalary = 100000.2m,
                IsManager = false,
                DepartmentId = 6,
            };
            employees.Add(employee);
            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };

            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };

            departments.Add(department);

            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };

            departments.Add(department);

            return departments;
        }
    }
}
