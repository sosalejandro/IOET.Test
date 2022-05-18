using IOET.Test.Library.Exceptions;
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
        Assert.Equal(TimeSpan.Parse("10:15"), workShiftStruct.Entry);
        Assert.Equal(TimeSpan.Parse("15:40"), workShiftStruct.Exit);
    }

    [Theory]
    [InlineData("MO10:00-12:00", "10:00", "12:00")]
    [InlineData("TU10:00-12:00", "10:00", "12:00")]
    [InlineData("TH01:00-03:00", "01:00", "03:00")]
    [InlineData("SA14:00-18:00", "14:00", "18:00")]
    [InlineData("SU20:00-21:00", "20:00", "21:00")]
    public void CreateFromTime_CreatesANewInstance_WhenInputIsValid(
        string timeInput, 
        string entryTime, 
        string exitTime)
    {
        // Arrange
        Func<string, WorkShiftStruct> CreateWorkShiftStruct = (input)
           => WorkShiftStruct.CreateFromTime(input);

        // Act
        var workShiftStruct = CreateWorkShiftStruct(timeInput);

        // Assert        
        Assert.Equal(TimeSpan.Parse(entryTime), workShiftStruct.Entry);
        Assert.Equal(TimeSpan.Parse(exitTime), workShiftStruct.Exit);
    }

    [Theory]
    [InlineData("M10:00-12:00")]
    [InlineData("MAA10:00-12:00")]
    [InlineData("0:00-12:00")]
    [InlineData("M10:0012:00")]
    [InlineData("M10:00-12000")]
    public void CreateFromTime_Should_Throw_WhenInputIsInvalid(string timeInput)
    {
        // Arrange
        Func<string, WorkShiftStruct> CreateWorkShiftStruct = (input)
           => WorkShiftStruct.CreateFromTime(input);

        // Act & Assert
        Assert.Throws<InvalidInputException>(
            () => CreateWorkShiftStruct(timeInput));        
    }
}
