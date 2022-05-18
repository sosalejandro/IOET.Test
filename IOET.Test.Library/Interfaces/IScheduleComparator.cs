using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library.Interfaces;
public interface IScheduleComparator
{
    int CompareWorkShifts(IEnumerable<EmployeeWorkShift> employeeWorkShift1, IEnumerable<EmployeeWorkShift> employeeWorkShift2);
    IEnumerable<Employee> CreateEmployeesFromInputs(List<string> inputs);
    IEnumerable<string> GetScheduleResults(IEnumerable<Employee> employees, Employee start);
    List<string> ParseIntoScheduleStringList(string textFile);
}
