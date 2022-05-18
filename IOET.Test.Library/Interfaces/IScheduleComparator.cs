using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library.Interfaces;
public interface IScheduleComparator
{
    /// <summary>
    /// Compares <paramref name="employeeWorkShift1"/> and <paramref name="employeeWorkShift2"/> 
    /// for how many times they coincide within the same timeframe overlapping each other
    /// </summary>
    /// <param name="employeeWorkShift1">Employee 1</param>
    /// <param name="employeeWorkShift2">Employee 2</param>
    /// <returns>Amount of coincidences</returns>
    int CompareWorkShifts(IEnumerable<EmployeeWorkShift> employeeWorkShift1, IEnumerable<EmployeeWorkShift> employeeWorkShift2);
    /// <summary>
    /// Takes a list of inputs and creates a collection of Employee
    /// </summary>
    /// <param name="inputs">List of inputs</param>
    /// <returns>Collection of <c>Employee</c></returns>
    IEnumerable<Employee> CreateEmployeesFromInputs(List<string> inputs);
    /// <summary>
    /// Takes a collection of employees and a employee to start with, 
    /// comparing them all and returning the results of the coincendes between them all
    /// </summary>
    /// <param name="employees">Employees list</param>
    /// <param name="start">Starting employee</param>
    /// <returns>Coincidences result report</returns>
    IEnumerable<string> GetScheduleResults(IEnumerable<Employee> employees, Employee start);
    /// <summary>
    /// Takes <paramref name="textFile"/> path and returns its content in a list.
    /// </summary>
    /// <param name="textFile">File path to TXT input file</param>
    /// <returns>List of inputs</returns>
    List<string> ParseIntoScheduleStringList(string textFile);
}
