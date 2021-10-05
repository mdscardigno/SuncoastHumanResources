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
    }//end of MonthlySalary function
  }//end of employee class
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
      //a list of employees
      var employees = new List<Employee>();
      //MENU
      var keepGoing = true;
      //we display the greeting.
      DisplayGreeting();
      //while the user hasn't said quit yet
      while (keepGoing)
      {
        //insert a blank line then
        Console.WriteLine();
        //prompt them and get their answer (force uppercase)
        Console.WriteLine("What do you want to do? (A)dd an employee or (S)ow all the employees or (F)ind an employee or (Q)uit?: ");
        var choice = Console.ReadLine().ToUpper();
        if(choice == "Q"){
          //User says to quit therefore we set keepGoing to false.
          keepGoing = false;
        }else if(choice == "S"){
          //Loop through each employee
          foreach (var employee in employees)
          {
            //print all the details
            Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes {employee.Salary}.");
          }
        }else if(choice == "F"){
          //ask for the name of an employee
          var name = PromptForString("What name are you looking for? ");
          //Make a new variable to store the found employee, initializing to null which will indicate no match found
          Employee foundEmployee = null;
          //go through all the employees   
        }
        else
        {
          //make a new employee object
          var employee = new Employee();
          //Prompt for values and save them in the employees properties.
          employee.Name = PromptForString("What is your name?: ");
          employee.Department = PromptForInteger("What is your department number?: ");
          employee.Salary = PromptForInteger("What is your yearly salary?: ");
          Console.WriteLine($"Hello, {employee.Name} makes {employee.MonthlySalary()} dollars per month.");
          //Add it to the list
          employees.Add(employee);
        }
      }//end of while statement keepGoing
    }//end of main
  }//end of class Program
}
