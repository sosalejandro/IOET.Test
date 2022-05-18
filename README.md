# IOET.Test

## Findings

1. Given the input given the days of the week have a pattern to be named after the first 2 letters of the day, in capital casing. 

2. There should always be at the very least 2 entries in the input. That should be a constraint. 
Why should you be able to put only 1 entry if the idea is to compare, and you cannot compare a single item against nothing. 

3. The output must specify target 1 and target 2 and how many times they did coincide in the office.

## Solution thought process

1. Divide each string into segments. (Ex: "MO10:00-12:00") Preferably a DTO such as (Day: "MO", Entry: 10:00, Exit: 12:00)

2. Compare their days (MO) and time (10:00-12:00) returning a boolean

3. If true: add 1 point to count target1-target2. If false just skip, do nothing.

4. Repeat for every entry 

5. A clever way to avoid heavy repetation was to use dynamic programming with queues 
and hashsets to repeat per item but to avoid going into a infinite loop filtering with a hashset. 
Turning classes into records for in-built override of Equals and GetHashCode methods. 
Taking advantage of it's value based comparison rather than memory allocation comparison.

## Usage

The application starts and ask for a file path to be prompt. 

The file must be a .txt and it's value must match the RegEx based on the input given by email. 
Otherwise it will just throw an error into the console and finish the application.

## Information about the solution

The solution was built with a simple decoupling using a library class to hold it's core logic to be easily integrated with the application
(console application)

The test library suit was built using xUnit. 

The architecture tries to avoid too much coupling even though it depends heavily on 
internal helper statics methods to separete functions and make it readeable code.

The purpose of these statics methods is to avoid creating far more coupling with dependencies of classes internally 
and allow code re-usage within the application, but leaving the solution with a 
concrete implementation which cannot be overriden.