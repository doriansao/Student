using Student.DataAcces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAcces
{
  public interface IStudentRepository
  {
    void CreateStudent(StudentDto student);
    List<StudentDto> SearchStudents(StudentDto criteria);
    List<StudentDto> GetAllStudents();
  }

  public class StudentRepository : IStudentRepository
  {
    private readonly StudentsEntities _studentContext;

    public StudentRepository()
    {
      _studentContext = new StudentsEntities();
    }

    public void CreateStudent(StudentDto student)
    {
      _studentContext.Students.Add(new Student()
      {
        StudentType = student.StudentType,
        StudentName = student.StudentName,
        Gender = student.Gender,
        LastUpdate = student.LastUpdate
      });
      
      _studentContext.SaveChanges();      
    }

    public List<StudentDto> GetAllStudents()
    {
      return _studentContext.Students
        .Select(t => new StudentDto
        {
          Gender = t.Gender,
          StudentName = t.StudentName,
          StudentType = t.StudentType,
          LastUpdate = t.LastUpdate
        }).ToList();
    }

    public List<StudentDto> SearchStudents(StudentDto criteria)
    {
      return _studentContext.Students
        .Where(s => s.StudentType.Contains(criteria.StudentType)
         || s.StudentName.Contains(criteria.StudentName)
         || s.Gender.Contains(criteria.Gender))
        .Select(t => new StudentDto
        {
          Gender = t.Gender,
          StudentName = t.StudentName,
          StudentType = t.StudentType,
          LastUpdate = t.LastUpdate
        }).ToList();
    }
  }
}
