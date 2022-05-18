using IOET.Test.Library;
using IOET.Test.Library.Models;

namespace IOET.Test.TestLibrary;
public class ScheduleComparatorTests
{
    [Fact]
    public void ParseIntoScheduleStringList_Should_ReturnAListOfStrings()
    {
        // Skipping due to needed abstraction over StreamReader not previsted.
    }

    [Fact]
    public void CreateEmployeesFromInputs_Should_CreateACollectionOfEmployees()
    {
        // Arrange
        var sc = new ScheduleComparator();

        Func<List<string>,
            ScheduleComparator,
            IEnumerable<Employee>>
            CreateEmployeeList = (input, sc)
            => sc.CreateEmployeesFromInputs(input);

        List<string> inputList = new()
        {
            "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00",
            "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00",
            "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00"
        };

        // Act
        var results = CreateEmployeeList(inputList, sc);

        // Assert
        Assert.NotNull(results);
        Assert.Equal(3, results.Count());
    }

    [Fact]
    public void GetScheduleResults_Should_ReturnResultsFromTextInput()
    {
        // Arrange
        var sc = new ScheduleComparator();

        Func<List<string>, 
            ScheduleComparator, 
            IEnumerable<Employee>> 
            CreateEmployeeList = (input, sc)
            => sc.CreateEmployeesFromInputs(input);

        Func<IEnumerable<Employee>, 
            ScheduleComparator, 
            IEnumerable<string>> 
            GetScheduleResults = (employeesList, sc)
            => sc.GetScheduleResults(employeesList, employeesList.First());

        List<string> inputList = new()
        {
            "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00",
            "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00",
            "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00"
        };

        IEnumerable<Employee> employeeList = CreateEmployeeList(inputList, sc);

        // Act
        var results = GetScheduleResults(employeeList, sc);


        // Assert
        Assert.NotNull(results);
        Assert.Equal(3, results.Count());
    }

    [Fact]
    public void CompareWorkShifts_Should_CompareShiftsAndReturnInt()
    {
        // Arrange
        var sc = new ScheduleComparator();

        Func<List<string>,
           ScheduleComparator,
           IEnumerable<Employee>>
           CreateEmployeeList = (input, sc)
           => sc.CreateEmployeesFromInputs(input);

        Func<IEnumerable<EmployeeWorkShift>,
            IEnumerable<EmployeeWorkShift>,
            ScheduleComparator,
            int>
            CompareWorkShifts = (employee1, employee2, sc)
            => sc.CompareWorkShifts(employee1, employee2);

        List<string> inputList = new()
        {
            "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00",
            "ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00"
        };

        IEnumerable<Employee> employeeList = CreateEmployeeList(inputList, sc);

        // Act
        var result = CompareWorkShifts(
            employeeList.First().WorkShifts,
            employeeList.Last().WorkShifts,
            sc);

        // Assert
        Assert.Equal(2, result);
    }
}
