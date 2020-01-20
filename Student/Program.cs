using Student.DataAcces.Dto;
using Student.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Student
{
  class Program
  {
    static void Main(string[] args)
    {
      //Creating the Student Service
      var service = IoC.GetContainer().Resolve<IStudentService>();

      //Creating the records from CSV file
      using (var reader = new StreamReader("students.csv"))
      {        
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var student = line.Split(',');
          service.CreateStudent(student);
        }
      }

      //Perform Searching with Command line
      Console.WriteLine("Enter search criteria, 'all' for shwing all records or 'exit' to terminate");
      var command = Console.ReadLine();
      while (command != "exit")
      {
        List<StudentDto> results;
        if (command == "all")
          results = service.GetAllStudents();
        else
          results = service.SearchStudents(command);

        if (results.Any())
        {
          foreach (var student in results)
          {
            Console.WriteLine($"Student Type: {student.StudentType}");
            Console.WriteLine($"Student Name: {student.StudentName}");
            Console.WriteLine($"Gender: {student.Gender}");
            Console.WriteLine($"Last Update: {student.LastUpdate}");
            Console.WriteLine();
          }
        }
        else
          Console.WriteLine("No results were found with that criteria.");

        Console.WriteLine("Enter search criteria, 'all' for shwing all records or 'exit' to terminate");
        Console.WriteLine();

        command = Console.ReadLine();
      }
      Console.WriteLine("Bye Bye!");
    }
  }
}
