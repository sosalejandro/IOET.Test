using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library.Models;

public struct WorkShiftStruct
{
    public TimeSpan Entry;
    public TimeSpan Exit;

    internal WorkShiftStruct(ReadOnlySpan<char> entry, ReadOnlySpan<char> exit)
    {
        Entry = TimeSpan.Parse(entry.ToString());
        Exit = TimeSpan.Parse(exit.ToString());
    }

    public static WorkShiftStruct CreateFromTime(string input)
    {
        var time = input[2..].AsSpan();

        var middle = time.IndexOf("-");

        var entry = time[..middle];

        var exit = time.Slice(middle + 1);

        return new WorkShiftStruct(entry, exit);
    }
}
