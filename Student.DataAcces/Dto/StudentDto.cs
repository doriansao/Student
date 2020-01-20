using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAcces.Dto
{
  public class StudentDto
  {
    public string StudentType { get; set; }
    public string StudentName { get; set; }
    public string Gender { get; set; }
    public DateTime LastUpdate { get; set; }
  }
}
