using Student.DataAcces;
using Student.DataAcces.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service
{
  public interface IStudentService
  {    
    List<StudentDto> SearchStudents(string command);
    void CreateStudent(string[] student);
    List<StudentDto> GetAllStudents();
  }

  public class StudentService : IStudentService
  {
    public IStudentRepository _studentRepository { get; }

    public StudentService(IStudentRepository studentRepository)
    {
      _studentRepository = studentRepository;
    }        

    public List<StudentDto> SearchStudents(string command)
    {
      string[] validSearchTypes = { "type", "name", "gender" };
      var criteria = new StudentDto();

      var parameters = command.Split(' ');
      foreach(var param in parameters)
      {
        var searchType = param.Split('=');

        if (validSearchTypes.Contains(searchType[0]))
        {
          switch(searchType[0])
          {
            case "type":
              criteria.StudentType = searchType[1];
              break;
            case "name":
              criteria.StudentName = searchType[1];
              break;
            case "gender":
              criteria.Gender = searchType[1];
              break;
          }
        }

      }

      return _studentRepository.SearchStudents(criteria);
    }

    public void CreateStudent(string[] student)
    {
      var lastUpdate = DateTime.ParseExact(student[3], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
     
      _studentRepository.CreateStudent(new StudentDto
      {
        StudentType = student[0],
        StudentName = student[1],
        Gender = student[2],
        LastUpdate = lastUpdate
      });
    }

    public List<StudentDto> GetAllStudents()
    {
      return _studentRepository.GetAllStudents();
    }
  }
}
