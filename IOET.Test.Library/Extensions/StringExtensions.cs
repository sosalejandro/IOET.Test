using IOET.Test.Library.Exceptions;
using IOET.Test.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IOET.Test.Library.Extensions;

public static class StringExtensions
{    
    /// <summary>
    /// Gets the name from given input matching a Regex Pattern
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="InvalidInputException"></exception>
    public static string GetName(this string input)
    {
        string pattern = "[a-zA-Z]+=";
        if (!Regex.Match(input, pattern).Success)
            throw new InvalidInputException("Invalid input to parse name.");        

        var name = Regex.Match(input, pattern).Value;
        return name[..^1];
    }   
}
