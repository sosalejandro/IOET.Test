using IOET.Test.Library.Exceptions;
using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.TestLibrary;
public class EmployeeTests
{
    [Fact]
    public void CreateFromInput_Should_CreateANewInstance()
    {
        // Arrange
        var input = "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00";
        var name = "RENE";

        Func<string, Employee> CreateEmployee = (input)
            => Employee.CreateFromInput(input);

        // Act
        var emp = CreateEmployee(input);

        // Assert
        Assert.NotNull(emp);
        Assert.Equal(name, emp.Name);
        Assert.Equal(5, emp.WorkShifts.Count);
    }

    [Theory]
    [InlineData("RENEMO10:00-12:00,TU10:0012:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00")]
    [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:000")]
    [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-1800,SU20:00-21:00")]
    [InlineData("RENE=10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00")]
    [InlineData("RENE=MO10:00-12:00,T10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00")]
    [InlineData("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:020:00-21:00")]
    public void CreateFromInput_Should_Throw_WhenInputIsInvalid(string input)
    {
        // Arrange
        Func<string, Employee> CreateEmployee = (input)
            => Employee.CreateFromInput(input);

        // Act & Assert
        Assert.Throws<InvalidInputException>(() => CreateEmployee(input));        
    }
}
