using IOET.Test.Library.Interfaces;
using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library;

public class ScheduleComparator : IScheduleComparator
{
    public List<string> ParseIntoScheduleStringList(string textFile)
    {
        List<string> inputs = new();

        using (StreamReader sr = new(textFile))
        {
            string ln;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            while ((ln = sr.ReadLine()) is not null)
            {
                inputs.Add(ln);
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            sr.Close();
        }

        return inputs;
    }

    public IEnumerable<string> GetScheduleResults(IEnumerable<Employee> employees, Employee start)
    {
        HashSet<string> visited = new();
        HashSet<Employee> queueVisited = new();

        int result;
        string resultPair;

        var queue = new Queue<Employee>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Check if the whole cycle has been made already
            if (queueVisited.Contains(current))
                continue;

            queueVisited.Add(current);

            foreach (var employee in employees)
            {
                if (ValidateNotRepeatedItems(employee.Name, current.Name))
                    continue;

                if (ValidateNotRepeatedItems(visited, current.Name, employee.Name))
                    continue;

                // Add to queue
                queue.Enqueue(employee);

                result = CompareWorkShifts(current.WorkShifts, employee.WorkShifts);
                resultPair = String.Format($"{current.Name}-{employee.Name}");

                if (result > 0)
                    yield return String.Format($"{resultPair}: {result}");

                visited.Add(resultPair);
            }
        }


    }

    public int CompareWorkShifts(
        IEnumerable<EmployeeWorkShift> employeeWorkShift1, 
        IEnumerable<EmployeeWorkShift> employeeWorkShift2)
    {
        int count = 0;

        foreach (var currentShift in employeeWorkShift1)
        {
            var employeeTwoShift = employeeWorkShift2
                .FirstOrDefault(e => 
                e.DayOfWeek == currentShift.DayOfWeek);

            if (employeeTwoShift is null)
                continue;

            if (TimeComparator.Compare(currentShift, employeeTwoShift))
                count++;
        }

        return count;
    }

    public IEnumerable<Employee> CreateEmployeesFromInputs(List<string> inputs)
    {
        foreach (string input in inputs)
        {
            yield return Employee.CreateFromInput(input);
        }
    }

    private bool ValidateNotRepeatedItems(string name1, string name2)
    {
        return string.
            Compare(name1, 
            name2, 
            StringComparison.InvariantCultureIgnoreCase) == 0;
    }

    private bool ValidateNotRepeatedItems(ICollection<string> visited, string name1, string name2)
    {
        string caseOne = String.Format($"{name1}-{name2}");
        string caseTwo = String.Format($"{name2}-{name1}");

        return visited.Contains(caseOne) || visited.Contains(caseTwo);
    }
}
