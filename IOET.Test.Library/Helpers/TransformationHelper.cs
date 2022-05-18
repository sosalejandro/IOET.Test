using IOET.Test.Library.Exceptions;
using IOET.Test.Library.Models;
using System.Text.RegularExpressions;

namespace IOET.Test.Library.Helpers;
internal static class TransformationHelper
{
    /// <summary>
    /// Transform an <paramref name="input"/> into a list of <c>string</c> (inputs)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static List<string> ParseStringIntoInputList(string input)
    {
        var results = input.Split(",").ToList();

        return results;
    }

    /// <summary>
    /// Transform a string input into a <c>EmployeeWorkShift</c>
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static EmployeeWorkShift ParseStringIntoEmployeeWorkShift(string input)
    {
        try
        {
            var dayOfWeek = GetDayOfTheWeek(input);

            WorkShiftStruct workShiftStruct = WorkShiftStruct.CreateFromTime(input);

            EmployeeWorkShift empShift = new(dayOfWeek, workShiftStruct.Entry, workShiftStruct.Exit);

            return empShift;
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    /// <summary>
    /// Retrieves day of week found in input
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="InvalidInputException"></exception>
    private static DayOfWeek GetDayOfTheWeek(string input)
    {
        // NOTES: It could be simplified to use only the first two letters as the case but it would required as setup to 
        // create a variable with the sliced string before hand. It might run quicker, thought. 
        return input switch
        {
            string _ when Regex.Match(input, "MO").Success => DayOfWeek.Monday,
            string _ when Regex.Match(input, "TU").Success => DayOfWeek.Tuesday,
            string _ when Regex.Match(input, "WE").Success => DayOfWeek.Wednesday,
            string _ when Regex.Match(input, "TH").Success => DayOfWeek.Thursday,
            string _ when Regex.Match(input, "FR").Success => DayOfWeek.Friday,
            string _ when Regex.Match(input, "SA").Success => DayOfWeek.Saturday,
            string _ when Regex.Match(input, "SU").Success => DayOfWeek.Sunday,
            _ => throw new InvalidInputException("Invalid input. Day of Week couldn't be found.")
        };
    }
}
