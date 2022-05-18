using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library;
public static class TimeComparator
{
    public static bool Compare(
        EmployeeWorkShift employee1,
        EmployeeWorkShift employee2)
    {
        return employee1.Entry < employee2.Exit && employee2.Entry < employee1.Exit;
    }
}

