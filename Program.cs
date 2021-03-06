using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
  class Employee
  {
    public string Name { get; set; }
    public int Department { get; set; }
    public int Salary { get; set; }
    public int MonthlySalary()
    {
      return Salary / 12;
    }
  }

  class EmployeeDatabase
  {
    // Keep a *private* copy of the employee list.
    //
    // We make this private since we don't want code from
    // outside this class to have access to it. All access
    // to this information comes through the methods of the
    // class.
    private List<Employee> employees = new List<Employee>();

    // Get a list of all the employees
    public List<Employee> GetAllEmployees()
    {
      return employees;
    }

    // Given an argument of an employee, add that employee
    // to the list of employees we are managing.
    public void AddEmployee(Employee newEmployee)
    {
      employees.Add(newEmployee);
    }

    // Given a name as a string, look through the list of
    // employees. If we find one with a matching name, return
    // the employee. If nothing is found, return a null.
    public Employee FindOneEmployee(string name)
    {
      // to null which will indicate no match found
      Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);

      // Return what we found (the employee or null)
      return foundEmployee;
    }
  }

  class Program
  {
    static void DisplayGreeting()
    {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("    Welcome to Our Employee Database    ");
      Console.WriteLine("----------------------------------------");
      Console.WriteLine();
      Console.WriteLine();
    }

    static string PromptForString(string prompt)
    {
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    static int PromptForInteger(string prompt)
    {
      Console.Write(prompt);
      int userInput;
      var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

      if (isThisGoodInput)
      {
        return userInput;
      }
      else
      {
        Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
        return 0;
      }
    }

    static void Main(string[] args)
    {
      // Our database
      var database = new EmployeeDatabase();

      // Should we keep showing the menu?
      var keepGoing = true;

      DisplayGreeting();

      // While the user hasn't said QUIT yet
      while (keepGoing) {
        // Insert a blank line then prompt them and get their answer (force uppercase)
        Console.WriteLine();
        Console.Write("What do you want to do? (A)dd an employee or (S)how all the employees or (F)ind an employee or (Q)uit: ");
        var choice = Console.ReadLine().ToUpper();

        if (choice == "Q") {
          // They said quit, so set our keepGoing to false
          keepGoing = false;
        } else if (choice == "F") {
          // Ask for the name of an employee
          var name = PromptForString("What name are you looking for? ");

          // Make a new variable to store the found employee, or null if not found
          Employee foundEmployee = database.FindOneEmployee(name);

          // If the foundEmployee is still null, nothing was found
          if (foundEmployee == null) {
            Console.WriteLine("No match found");
          } else {
            // Otherwise print details of the found employee
            Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
          }
        } else if (choice == "S") {
          var employees = database.GetAllEmployees();

          // Loop through each employee
          foreach(var employee in employees) {
            // And print details
            Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
          }
        } else {
          // Make a new employee object
          var employee = new Employee();

          // Prompt for values and save them in the employee's properties
          employee.Name = PromptForString("What is your name? ");
          employee.Department = PromptForInteger("What is your department number? ");
          employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

          // Add it to the list
          database.AddEmployee(employee);
        }

        // end of the `while` statement
      }
    }
  }
}