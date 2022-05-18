using IOET.Test.Library.Exceptions;
using IOET.Test.Library.Helpers;
using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.TestLibrary;
public class TransformationHelperTests
{
    [Fact]
    public void ParseStringIntoInputList_ReturnsAList()
    {
        // Arrange
        var input = "MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00";

        Func<string, List<string>> ParseStringIntoInputList = (input)
            => TransformationHelper.ParseStringIntoInputList(input);

        // Act
        var list = ParseStringIntoInputList(input);

        // Assert
        Assert.True(list.Any());
        Assert.Equal(5, list.Count);
    }

    [Fact]
    public void ParseStringIntoEmployeeWorkShift_Should_Return_ANewInstanceOfEmployeeWorkShift()
    {
        // Arrange
        var input = "MO10:00-12:00";

        Func<string, EmployeeWorkShift> CreateEmployeeWorkShiftFromInput = (input) 
            => TransformationHelper.ParseStringIntoEmployeeWorkShift(input);

        // Act
        var employeeWorkShift = CreateEmployeeWorkShiftFromInput(input);

        // Assert
        Assert.NotNull(employeeWorkShift);
        Assert.Equal(DayOfWeek.Monday, employeeWorkShift.DayOfWeek);
        Assert.Equal(TimeSpan.Parse("10:00"), employeeWorkShift.Entry);
        Assert.Equal(TimeSpan.Parse("12:00"), employeeWorkShift.Exit);
    }

    [Theory]
    [InlineData("M10:00-12:00")]
    [InlineData("MO0:00-12:00")]
    [InlineData("FR10:0012:00")]
    [InlineData("TU10:00-1200")]
    [InlineData("SA10:00- 12:00")]
    public void ParseStringIntoEmployeeWorkShift_Should_Throw_WhenInputIsInvalid(string input)
    {
        // Arrange
        //var input = "MO10:00-12:00";

        Func<string, EmployeeWorkShift> CreateEmployeeWorkShiftFromInput = (input)
            => TransformationHelper.ParseStringIntoEmployeeWorkShift(input);

        // Act & Assert
        Assert.Throws<InvalidInputException>(() => CreateEmployeeWorkShiftFromInput(input));        
    }



}
