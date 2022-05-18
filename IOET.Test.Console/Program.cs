// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using IOET.Test.Library;
using IOET.Test.Library.Models;

Welcome();
InitProgram();

public partial class Program 
{
    public static void InitProgram()
    {
        try
        {
            string textFile = GetUserInput("file path");

            using ScheduleComparator sc = new();
            List<string> scheduleInputs = sc.ParseIntoScheduleStringList(textFile);

            IEnumerable<Employee> employeesList = sc.CreateEmployeesFromInputs(scheduleInputs);

            var t1 = SortListAndGetFirst(employeesList);

            IEnumerable<string> results = sc.GetScheduleResults(t1.Item1, t1.Item2);

            Console.WriteLine("\nYour results are ready\n");

            PrintResults(results);           
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Tuple<IOrderedEnumerable<Employee>, Employee> SortListAndGetFirst(IEnumerable<Employee> employeesList)
    {
        if (employeesList.Count() == 0)
            throw new Exception("Empty collection, cannot continue.");

        IOrderedEnumerable<Employee> listSorted = employeesList.OrderBy(el => el.Name);

        Employee employee = listSorted.First();

        return new Tuple<IOrderedEnumerable<Employee>, Employee>(
            listSorted, 
            employee);
    }

    public static string GetUserInput(string prompt)
    {
        Console.WriteLine($"Enter {prompt}:");
        return Console.ReadLine();
    }

    public static void Welcome()
    {
        Console.WriteLine("Welcome to the ACME helper for calculating employees coincidences within the same timeframe in their schedule...\n");
        Console.WriteLine("In preparation, locate the file path for a .txt file to be evaluated.\n");        
    }

    public static void PressEnterToContinue()
    {
        Console.WriteLine("\n\nPress Enter to continue...\n");
        Console.ReadLine();
    }

    public static void PrintResults(IEnumerable<string> results)
    {
        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }
}