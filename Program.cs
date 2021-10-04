using System;
using System.Collections.Generic;

namespace SuncoastHumanResources
{
  class Employee{
    public string Name {get; set;}
    public int Department {get; set;}
    public int Salary {get; set;}
    public int MonthlySalary(){
      return Salary / 12;
    }
  }
  class Program
  {
    static void DisplayGreeting(){
      Console.WriteLine("-------------------------------------------");
      Console.WriteLine("Welcome to Suncoast Human Resources.");
      Console.WriteLine("-------------------------------------------");
      Console.WriteLine();
      Console.WriteLine();
      }
      static string PromptForString(string prompt){
        Console.Write(prompt);
        var userInput = Console.ReadLine();
        return userInput;
      }
      static int PromptForInteger(string prompt){
        var userInput = 0;
        Console.Write(prompt);
        var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
        if(isThisGoodInput){
          return userInput;
        }
        else
        {
          Console.WriteLine("Sorry, that isn't a valid input. I am using 0 as your answer.");
          return 0;
        }
      }
    static void Main(string[] args)
    {
      var employees = new List<Employee>();
      var employee = new Employee();
      DisplayGreeting();
      //MENU
      var keepGoing = true;
      while (keepGoing)
      {
        Console.WriteLine();
        Console.WriteLine("What do you want to do? (A)dd an employee or (S)ow all the employees or (F)ind an employee or (Q)uit?: ");
        var choice = Console.ReadLine().ToUpper();
        if(choice == "Q"){
          //User says to quit therefore we set keepGoing to false.
          keepGoing = false;
        }
        else
        {
          employee.Name = PromptForString("What is your name?: ");
          employee.Department = PromptForInteger("What is your department number?: ");
          employee.Salary = PromptForInteger("What is your yearly salary?: ");
          Console.WriteLine($"Hello, {employee.Name} makes {employee.MonthlySalary()} dollars per month.");
          employees.Add(employee);
        }
      }
      
    }
  }
}
