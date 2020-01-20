using Student.DataAcces;
using Student.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Student
{
  public static class IoC
  {
    public static UnityContainer GetContainer()
    {
      var container = new UnityContainer();
      container.RegisterType<IStudentRepository, StudentRepository>();
      container.RegisterType<IStudentService, StudentService>();
      return container;
    }
  }
}
