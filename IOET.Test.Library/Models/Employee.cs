using IOET.Test.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library.Models;
public record Employee
{
    public string Name { get; set; }
    public HashSet<EmployeeWorkShift> WorkShifts { get; private set; }

    public Employee(string name)
    {
        Name = name;
        WorkShifts = new();
    }

    internal Employee(string name, ICollection<EmployeeWorkShift> workShifts)
    {
        Name = name;
        WorkShifts = workShifts.ToHashSet();
    }

    public static Employee CreateFromInput(string input)
    {
        string name = input.GetName();
        string namePattern = $"{name}=";
        input = input[(namePattern.Length)..];


        ICollection<EmployeeWorkShift> workShifts = new HashSet<EmployeeWorkShift>();
        var entries = input.ParseIntoList();

        foreach (string entry in entries)
        {
            workShifts.Add(entry.ParseIntoEmployeeWorkShift());
        }

        return new Employee(name, workShifts);
    }

    public void AddWorkShifts(ICollection<EmployeeWorkShift> workShifts)
    {
        WorkShifts.UnionWith(workShifts);
    }
}
