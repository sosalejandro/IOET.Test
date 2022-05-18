using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOET.Test.Library.Models;

public record EmployeeWorkShift(DayOfWeek DayOfWeek, TimeSpan Entry, TimeSpan Exit)
{
}

