using System.Text.RegularExpressions;
using LINQ.Utils;
Console.WriteLine("Join.......");

var employees = Repository.LoadEmployees();
var dept = Repository.LoadDepartment();

//Join
var joinResult = employees.Join(
    dept,
    emp => emp.DepartmentId,
    dept => dept.Id,
    (emp, dept) => new EmployeeDto
    {
        FullName = emp.FullName,
        Department = dept.Name
    }
);
foreach (var item in joinResult)
{
    Console.WriteLine($"{item.FullName} [{item.Department}]");
}


//Group join
var groupJoin = dept.GroupJoin(
                                employees,
                                dept => dept.Id,
                                emps => emps.DepartmentId,
                                (dept, emps) => new Group
                                {
                                    Department = dept.Name,
                                    Employees = emps.Select(e => e.FullName).ToList()
                                }
                            );

#region University Example

var students = UniversityRepository.LoadStudents();
var courses = UniversityRepository.LoadCourses();

JoinOperator.InnerJoinExample(students,courses);
JoinOperator.GroupJoinExample(students,courses);



#endregion



