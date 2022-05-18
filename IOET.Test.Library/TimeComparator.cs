using IOET.Test.Library.Models;

namespace IOET.Test.Library;
public static class TimeComparator
{
    /// <summary>
    /// Compares a work shift from <paramref name="employee1"/> and <paramref name="employee2"/>
    /// checking for time overlapping within their timeframes.
    /// </summary>
    /// <param name="employee1">Employee 1 Work Shift</param>
    /// <param name="employee2">Employee 2 Work Shift</param>
    /// <returns></returns>
    public static bool Compare(
        EmployeeWorkShift employee1,
        EmployeeWorkShift employee2)
    {
        return employee1.Entry < employee2.Exit && employee2.Entry < employee1.Exit;
    }
}

