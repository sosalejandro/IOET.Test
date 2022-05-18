using IOET.Test.Library.Exceptions;
using IOET.Test.Library.Extensions;
using IOET.Test.Library.Helpers;
using System.Text.RegularExpressions;

namespace IOET.Test.Library.Models;
public record Employee
{
    private const string ValidationPattern = "[a-zA-Z]+=([a-zA-Z]{2}[0-9]{2}:[0-9]{2}-[0-9]{2}:[0-9]{2},?)+$";

    /// <summary>
    /// Employee Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Employee's Work Shifts Schedule
    /// </summary>
    public HashSet<EmployeeWorkShift> WorkShifts { get; private set; }

    /// <summary>
    /// Public constructor
    /// </summary>
    /// <param name="name">Employee Name</param>
    public Employee(string name)
    {
        Name = name;
        WorkShifts = new();
    }

    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="workShifts"></param>
    internal Employee(string name, ICollection<EmployeeWorkShift> workShifts)
    {
        Name = name;
        WorkShifts = workShifts.ToHashSet();
    }

    /// <summary>
    /// Factory method for creating an employee from a text input
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static Employee CreateFromInput(string input)
    {
        ValidateInput(input);

        string name = input.GetName();
        string namePattern = $"{name}=";
        input = input[(namePattern.Length)..];


        ICollection<EmployeeWorkShift> workShifts = new HashSet<EmployeeWorkShift>();
        var entries = TransformationHelper.ParseStringIntoInputList(input);

        foreach (string entry in entries)
        {
            workShifts.Add(TransformationHelper.ParseStringIntoEmployeeWorkShift(entry));
        }

        return new Employee(name, workShifts);
    }


    /// <summary>
    /// Validates the given input to parse
    /// </summary>
    /// <param name="input">Text needed to parse into a valid object</param>
    /// <exception cref="InvalidInputException">Invalid input error</exception>
    private static void ValidateInput(string input)
    {
        if (!Regex.Match(input, ValidationPattern).Success)
            throw new InvalidInputException(
                "Cannot parse an invalid input needed to create an Employee.");
    }

    /// <summary>
    /// Adds a work shift collection to the current employee
    /// </summary>
    /// <param name="workShifts">Work Shift</param>
    public void AddWorkShifts(ICollection<EmployeeWorkShift> workShifts)
    {
        WorkShifts.UnionWith(workShifts);
    }

    
}
