using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.TestLibrary;
public class WorkShiftStructTests
{
    [Fact]
    public void CreateFromTime_CreatesANewInstance()
    {
        // Arrange
        string timeInput = "MO10:15-15:40";

        Func<string, WorkShiftStruct> CreateWorkShiftStruct = (input)
            => WorkShiftStruct.CreateFromTime(input);

        // Act
        var workShiftStruct = CreateWorkShiftStruct(timeInput);

        // Assert        
        Assert.Equal(TimeSpan.Parse("10:15".ToString()), workShiftStruct.Entry);
        Assert.Equal(TimeSpan.Parse("15:40".ToString()), workShiftStruct.Exit);

    }
}
