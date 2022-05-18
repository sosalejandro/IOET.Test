using IOET.Test.Library.Exceptions;
using System.Text.RegularExpressions;

namespace IOET.Test.Library.Models;

public struct WorkShiftStruct
{
    private const string ValidationPattern = "[0-9]{2}:[0-9]{2}-[0-9]{2}:[0-9]{2}$";

    public TimeSpan Entry;
    public TimeSpan Exit;

    internal WorkShiftStruct(ReadOnlySpan<char> entry, ReadOnlySpan<char> exit)
    {
        Entry = TimeSpan.Parse(entry.ToString());
        Exit = TimeSpan.Parse(exit.ToString());
    }

    /// <summary>
    /// Validates the <paramref name="input"/> and creates a <c>WorkShiftStruct</c>
    /// </summary>
    /// <param name="input">Timeframe</param>
    /// <returns></returns>
    /// <exception cref="InvalidInputException">Invalid input error</exception>
    public static WorkShiftStruct CreateFromTime(string input)
    {
        ValidateInput(input);

        var time = input[2..].AsSpan();

        var middle = time.IndexOf("-");

        var entry = time[..middle];

        var exit = time.Slice(middle + 1);

        return new WorkShiftStruct(entry, exit);
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
                "Cannot parse an invalid input needed to create a Work Shift.");
    }

}
