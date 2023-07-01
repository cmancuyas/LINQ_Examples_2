using LINQ_Examples_2;
using LINQ_Examples_2._helper;
using System.Collections;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments();

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Method Syntax                                                         *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
// Sorting Operations OrderBy, OrderByDescending, ThenBy, ThenByDescending
var results = employeeList
                .Join(departmentList,
                        e => e.DepartmentId,
                        d => d.Id,
                        (emp, dept) =>
                            new
                            {
                                Id = emp.Id,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                AnnualSalary = emp.AnnualSalary,
                                DepartmentId = emp.DepartmentId,
                                DepartmentName = dept.LongName
                            })
                            //.OrderBy(o=>o.DepartmentId);
                            //.OrderByDescending(o => o.DepartmentId);
                            //.OrderBy(o=>o.DepartmentId).ThenBy(o=>o.AnnualSalary);
                            .OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);

foreach (var item in results)
{
    Console.WriteLine($"Id: {item.Id,-5} FirstName: {item.FirstName,-10}\t LastName: {item.LastName,-10}\t Annual Salary: {item.AnnualSalary,10}\t Department Name: {item.DepartmentName}");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Query Syntax                                                          *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
var results2 = from emp in employeeList
               join dept in departmentList
               on emp.DepartmentId equals dept.Id
               orderby emp.DepartmentId, emp.AnnualSalary descending
               select new
               {
                   Id = emp.Id,
                   FirstName = emp.FirstName,
                   LastName = emp.LastName,
                   AnnualSalary = emp.AnnualSalary,
                   DepartmentId = emp.DepartmentId,
                   DepartmentName = dept.LongName
               };

foreach (var item in results2)
{
    Console.WriteLine($"Id: {item.Id,-5} FirstName: {item.FirstName,-10}\t LastName: {item.LastName,-10}\t Annual Salary: {item.AnnualSalary,10}\t Department Name: {item.DepartmentName}");
}


Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Grouping Operators                                                    *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
// Grouping Operators
// GroupBy

var groupResult = from emp in employeeList
                  orderby emp.DepartmentId descending
                  group emp by emp.DepartmentId;

foreach (var empGroup in groupResult)
{
    Console.WriteLine($"Department Id: {empGroup.Key}");

    foreach (Employee emp in empGroup)
    {
        Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
    }
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Grouping Operators: Lookup                                            *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
// ToLookup Operator
var groupResult2 = employeeList
    .OrderBy(o => o.DepartmentId) //
    .ToLookup(e => e.DepartmentId);

foreach (var empGroup in groupResult2)
{
    Console.WriteLine($"Department Id: {empGroup.Key}");

    foreach (Employee emp in empGroup)
    {
        Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
    }
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Quantifier Operators:                                                 *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

var annualSalaryCompare = 40000;
bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare); //All
if (isTrueAll)
{
    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
}
else
{
    Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
}

bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare); //Any
if (isTrueAny)
{
    Console.WriteLine($"At least one employee has an annual salary of {annualSalaryCompare}");
}
else
{
    Console.WriteLine($"No employee has an annual salary of {annualSalaryCompare}");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Quantifier Operators: Contains                                        *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

var searchEmployee = new Employee()
{
    Id = 6,
    FirstName = "Chris",
    LastName = "Mancuyas",
    AnnualSalary = 100000.2m,
    IsManager = false,
    DepartmentId = 3,
};

bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());

if (containsEmployee)
{
    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
}
else
{
    Console.WriteLine($"No employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Quantifier Operators: OfType Filter                                   *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
ArrayList mixedCollection = DataHelper.GetHeterogenousDataCollection();


var stringResult = from s in mixedCollection.OfType<string>()
                   select s;
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Data Type - String            *");
Console.WriteLine("*--------------------------------*");
foreach (var item in stringResult)
{
    Console.WriteLine(item);
}
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Data Type - Integer           *");
Console.WriteLine("*--------------------------------*");
var intResult = from i in mixedCollection.OfType<int>()
                select i;
foreach (var item in intResult)
{
    Console.WriteLine(item);
}
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Data Type - Object<Employee>  *");
Console.WriteLine("*--------------------------------*");
var employeeResults = from employee in mixedCollection.OfType<Employee>()
                      select employee;

foreach (var employee in employeeResults)
{
    Console.WriteLine($"{employee.Id,-5} {employee.FirstName,-10} {employee.LastName,-10} {employee.AnnualSalary}");
}
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Data Type - Object<Department>*");
Console.WriteLine("*--------------------------------*");
var deptResults = from department in mixedCollection.OfType<Department>()
                  select department;

foreach (var dept in deptResults)
{
    Console.WriteLine($"{dept.Id,-5} {dept.ShortName,-10} {dept.LongName,-10} ");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                                             Element Operators: Element at                                         *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
//ElementAt, ElementOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single and SingleOrDefault
//var employee2 = employeeList.ElementAt(8); // System.ArgumentOutOfRangeException if wrong index
var employee2 = employeeList.ElementAtOrDefault(6); // No Exception - can be nullable
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  ElementAt/ElementOrDefault    *");
Console.WriteLine("*--------------------------------*");
if (employee2 != null)
{
    Console.WriteLine($"{employee2.Id,-5} {employee2.FirstName,-10} {employee2.LastName,-10} {employee2.AnnualSalary}");
}
else
{
    Console.WriteLine("This employee record does not exists within the collection");
}

Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  First/FirstOrDefault          *");
Console.WriteLine("*--------------------------------*");
List<int> integerList = new List<int> { 3, 14, 23, 17, 28, 89 };

int result = integerList.First();
Console.WriteLine(result);
//int result2 = integerList.First(i => i % 2 == 0);
int result2 = integerList.FirstOrDefault(i => i % 2 == 0);

if (result2 != 0)
{
    Console.WriteLine(result2);
}
else
{
    Console.WriteLine("There are no even numbers in the collection");
}
Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Last/LastOrDefault            *");
Console.WriteLine("*--------------------------------*");
//int result3 = integerList.Last();
int result3 = integerList.LastOrDefault();
Console.WriteLine(result3);


Console.WriteLine("*--------------------------------*");
Console.WriteLine("*  Single/SingleOrDefault        *");
Console.WriteLine("*--------------------------------*");

//var employee3 = employeeList.Single(e => e.Id == 2); //Should have only 1 entry else it will throw an exception System.InvalidOperationException: 'Sequence contains more than one element'
var employee3 = employeeList.SingleOrDefault(e=>e.Id==2); //Can be nullable
if(employee3 != null)
{
    Console.WriteLine($"{employee3.Id,-5} {employee3.FirstName,-10} {employee3.LastName,-10} {employee3.AnnualSalary}");
}


Console.ReadKey();