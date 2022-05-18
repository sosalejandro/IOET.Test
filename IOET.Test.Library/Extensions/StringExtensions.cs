using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IOET.Test.Library.Extensions;

public static class StringExtensions
{
    public static List<string> ParseIntoList(this string input)
    {
        var results = input.Split(",").ToList();

        return results;
    }

    public static EmployeeWorkShift ParseIntoEmployeeWorkShift(this string input)
    {
        var dayOfWeek = GetDayOfTheWeek(input);
        WorkShiftStruct workShiftStruct = WorkShiftStruct.CreateFromTime(input);

        EmployeeWorkShift empShift = new(dayOfWeek, workShiftStruct.Entry, workShiftStruct.Exit);

        return empShift;
    }

    public static string GetName(this string input)
    {        
        var name = Regex.Match(input, "[a-zA-Z]+=").Value;
        return name[..^1];
    }

    private static DayOfWeek GetDayOfTheWeek(this string input)
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
            _ => throw new NotImplementedException()
        };
    }
}
