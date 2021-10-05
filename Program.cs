﻿using System;
using System.Collections.Generic;

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
      // Our list of employees
      var employees = new List<Employee>();

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

          // Make a new variable to store the found employee, initializing
          // to null which will indicate no match found
          Employee foundEmployee = null;

          // Go through all the employees
          foreach(var employee in employees) {
            // If the name matches
            if (employee.Name == name) {
              // ... then store this employee in the foundEmployee variable
              foundEmployee = employee;
            }
          }

          // If the foundEmployee is still null, nothing was found
          if (foundEmployee == null) {
            Console.WriteLine("No match found");
          } else {
            // Otherwise print details of the found employee
            Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
          }
        } else if (choice == "S") {
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
          employees.Add(employee);
        }

        // end of the `while` statement
      }
    }
  }
}